using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.Annotations;
using Common.Models;

namespace Participants.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public IView View { get; set; }

        public ViewModelBase(IView view)
        {
            View = view;
            View.ViewModel = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
