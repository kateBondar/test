using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Models;

namespace BusinessLogic
{
    public class ParticipantService : IParticipantService
    {
        public IEnumerable<LookupItem> GetParticipants()
        {
            return this.GetAllParticipants().Select(p => new LookupItem() {Id = p.ID, DisplayName = $"{p.FirstName} {p.FamilyName}"});
        }

        private IEnumerable<Participant> GetAllParticipants()
        {
            return new List<Participant>
            {
                new Participant {FirstName = "Monika", FamilyName = "Geller"},
                new Participant {FirstName = "Ross", FamilyName = "Geller"},
                new Participant { FirstName = "Joey", FamilyName = "Tribiani"},
                new Participant { FirstName = "Phoeby", FamilyName = "Buffe"},
                new Participant { FirstName = "Chandler", FamilyName = "Bing"}
            };
        }
    }
}
