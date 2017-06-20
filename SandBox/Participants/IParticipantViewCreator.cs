using Participants.ViewModels;
using Participants.Views;

namespace Participants
{
    public interface IParticipantViewCreator
    {
        IParticipantViewModel Create();
    }
}