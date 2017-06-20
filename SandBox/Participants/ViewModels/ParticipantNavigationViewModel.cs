using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Events;
using Common.Models;
using Participants.DataProvider;
using Participants.Views;
using Prism.Events;

namespace Participants.ViewModels
{
    public class ParticipantNavigationViewModel : ViewModelBase, IParticipantNavigationViewModel
    {
        private INavigationDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;
        private IParticipantViewModel _selectedParticipantViewModel;
        private IParticipantViewCreator _creator;

        public ParticipantNavigationViewModel(INavigationDataProvider dataProvider, IParticipantNavigationView view, IEventAggregator eventAggregator, IParticipantViewCreator creator) : base(view)
        {
            Participants = new ObservableCollection<NavigationItemViewModel>();
            ViewModels = new ObservableCollection<IParticipantViewModel>();
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            _creator = creator;
            _eventAggregator.GetEvent<OpenPatientViewEvent>().Subscribe(OnOpenPatientViewEvent);
            Load();
        }

        private void OnOpenPatientViewEvent(int participantId)
        {
            var vm = _creator.Create();
            this.ViewModels.Add(vm);
            vm.Load(participantId);
            SelectedParticipantViewModel = vm;
        }

        public void Load()
        {
            Participants.Clear();
            foreach (var participant in _dataProvider.GetParticipants())
            {
                Participants.Add(new NavigationItemViewModel(participant.Id, participant.DisplayName, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Participants { get; set; }

        public ObservableCollection<IParticipantViewModel> ViewModels { get; private set; }

        public IParticipantViewModel SelectedParticipantViewModel
        {
            get { return _selectedParticipantViewModel; }
            set { _selectedParticipantViewModel = value; }
        }

    }
}
