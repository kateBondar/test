using Participants.DataProvider;
using Participants.ViewModels;
using Participants.Views;

namespace Participants
{
    public class ParticipantViewCreator : IParticipantViewCreator
    {
        private IParticipantView _view;
        private INavigationDataProvider _provider;

        public ParticipantViewCreator(IParticipantView view, INavigationDataProvider provider)
        {
            _view = view;
            _provider = provider;
        }

        public IParticipantViewModel Create()
        {
            return new ParticipantViewModel(_view, _provider);
        }
    }
}