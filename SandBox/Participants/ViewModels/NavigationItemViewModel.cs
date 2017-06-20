using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Events;
using Prism.Commands;
using Prism.Events;

namespace Participants.ViewModels
{
    public class NavigationItemViewModel
    {
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            ID = id;
            DisplayName = displayMember;
            OpenParticipantViewCommand = new DelegateCommand(OnOpenParticipantViewExecute);
            _eventAggregator = eventAggregator;
        }

        private void OnOpenParticipantViewExecute()
        {
            _eventAggregator.GetEvent<OpenPatientViewEvent>().Publish(ID);
        }

        public string DisplayName { get; set; }

        public int ID { get; set; }

        public ICommand OpenParticipantViewCommand { get; private set; }
    }
}
