using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Models;

namespace Participants.DataProvider
{
    public interface INavigationDataProvider
    {
        IEnumerable<LookupItem> GetParticipants();

        Participant GetParticipant(int id);
    }
}
