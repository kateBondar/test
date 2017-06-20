using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Participants.DataProvider;
using Participants.Views;

namespace Participants.ViewModels
{
    public class ParticipantViewModel : ViewModelBase, IParticipantViewModel
    {
        private INavigationDataProvider _provider;

        public ParticipantViewModel(IParticipantView view, INavigationDataProvider provider) : base(view)
        {
            _provider = provider;
        }

        public void Load(int participant)
        {
            var part = _provider.GetParticipant(participant);
            Participant = part;
        }

        public Participant Participant { get; set; }
    }
}
