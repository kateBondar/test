using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using Common;
using Common.Models;

namespace Participants.DataProvider
{
    public class NavigationDataProvider : INavigationDataProvider
    {
        private IParticipantService _participantService;

        public NavigationDataProvider(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        public IEnumerable<LookupItem> GetParticipants()
        {
            return _participantService.GetParticipants();
        }

        public Participant GetParticipant(int id)
        {
            var look = _participantService.GetParticipants().FirstOrDefault(x => x.Id == id);
            return new Participant() {ID = look.Id, FirstName = look.DisplayName};
        }
    }
}