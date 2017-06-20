using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;

namespace Participants.Wrapper
{
    public class ModelWrapper<T> : Observable, IRevertibleChangeTracking
    {
        private Dictionary<string, object> _originalValues;

        private List<IRevertibleChangeTracking> _trackingObjects;

        public ModelWrapper(T model)
        {
            _originalValues = new Dictionary<string, object>();
            _trackingObjects = new List<IRevertibleChangeTracking>();

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model = model;
        }

        public T Model { get; set; }

        public bool IsChanged => _originalValues.Any() || _trackingObjects.Any(x => x.IsChanged);

        public void AcceptChanges()
        {
            _originalValues.Clear();
            foreach (var item in _trackingObjects)
            {
                item.AcceptChanges();
            }

            OnPropertyChanged("");
        }

        public void RejectChanges()
        {
            foreach (var item in _originalValues)
            {
                typeof(T).GetProperty(item.Key).SetValue(Model, item.Value); 
            }

            foreach (var item in _trackingObjects)
            {
                item.RejectChanges();
            }

            AcceptChanges();
        }

        protected void SetValue<TNewValue>(TNewValue value, [CallerMemberName]string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);

            var currentValue = propertyInfo.GetValue(Model);

            if (!Equals(currentValue, value))
            {
                UpdateOriginalValue(currentValue, value, propertyName);
                propertyInfo.SetValue(Model, value);
                OnPropertyChanged(propertyName);
                OnPropertyChanged($"{propertyName}IsChanged");
                OnPropertyChanged(nameof(IsChanged));
            }
        }

        private void UpdateOriginalValue(object currentValue, object newValue,  string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, currentValue);
            }
            else
            {
                if (Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                }
            }
        }

        protected T GetValue<T>([CallerMemberName]string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);

            return (T)propertyInfo.GetValue(Model);
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName)
                ? (TValue)_originalValues[propertyName]
                : GetValue<TValue>(propertyName);
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);
        }


        protected void RegisterComplex<TModel>(ModelWrapper<TModel> wrapper)
        {
            if (!_trackingObjects.Contains(wrapper))
            {
                _trackingObjects.Add(wrapper);
                wrapper.PropertyChanged += TrackingObjectChangedEvent;
            }
        }

        private void TrackingObjectChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChanged))
            {
                OnPropertyChanged(nameof(IsChanged));
            }
        }
    }
}
