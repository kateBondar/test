using System;
using System.Runtime.Remoting;
using Common.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Participants.ViewModels;
using Prism.Events;

namespace ParticipantsTests.ViewModel
{
    [TestClass]
    public class NavigationItemViewModelTests
    {
        private NavigationItemViewModel _viewModel;
        private Mock<OpenPatientViewEvent> _eventMock;

        [TestMethod]
        public void ShouldPublicOpenParticipantViewItem()
        {
            const int participantId = 7;

            _eventMock = new Mock<OpenPatientViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();

            eventAggregatorMock.Setup(x => x.GetEvent<OpenPatientViewEvent>()).Returns(_eventMock.Object);

            _viewModel = new NavigationItemViewModel(participantId, "Random NAME", eventAggregatorMock.Object);
            _viewModel.OpenParticipantViewCommand.Execute(null);

            _eventMock.Verify(e => e.Publish(participantId), Times.Once);

        }

    }
}
