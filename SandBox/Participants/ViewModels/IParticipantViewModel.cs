using Common;
using Common.Models;

namespace Participants.ViewModels
{
    public interface IParticipantViewModel : IViewModel
    {
        Participant Participant { get; set; }

        void Load(int participant);
    }
}