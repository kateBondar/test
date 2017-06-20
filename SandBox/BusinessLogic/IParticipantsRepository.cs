using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BusinessLogic
{
    public interface IParticipantsRepository
    {
        Participant GetParticipant(int ID);

        IEnumerable<Participant> GetParticipants();
    }
}
