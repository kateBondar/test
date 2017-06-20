using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Events;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Participants;
using Participants.DataProvider;
using Participants.ViewModels;
using Participants.Views;
using Prism.Events;

namespace ParticipantsTests.ViewModel
{
    [TestClass]
    public class ParticipantNavigationViewModelTersts
    {
        private Mock<INavigationDataProvider> _mockDataProvider;
        private Mock<IParticipantNavigationView> _mockView;
        private Mock<IEventAggregator> _mockEventAggregator;
        private List<Mock<IParticipantViewModel>> _partViews;
        private Mock<IParticipantViewCreator> _mockCreator;
        private ParticipantNavigationViewModel _navViewModel;
        private Mock<OpenPatientViewEvent> _mockEvent;

        [TestInitialize]
        public void Setup()
        {
            _mockDataProvider = new Mock<INavigationDataProvider>();
            _mockDataProvider.Setup(x => x.GetParticipants()).Returns(new List<LookupItem>
            {
                new LookupItem {Id = 1, DisplayName = "Monika"},
                new LookupItem {Id = 12,DisplayName  = "Ross"},
                new LookupItem {Id = 123,DisplayName = "Joey"},
                new LookupItem {Id = 1234, DisplayName  = "Phoeby"},
                new LookupItem {Id = 12345,DisplayName  = "Chandler"}
            });

            _mockView = new Mock<IParticipantNavigationView>();

            _mockEventAggregator = new Mock<IEventAggregator>();

            _mockEvent = new Mock<OpenPatientViewEvent>();
            _mockEventAggregator.Setup(x => x.GetEvent<OpenPatientViewEvent>()).Returns(_mockEvent.Object);

            _partViews = new List<Mock<IParticipantViewModel>>();

            _mockCreator = new Mock<IParticipantViewCreator>();
            _navViewModel = new ParticipantNavigationViewModel(_mockDataProvider.Object, _mockView.Object, _mockEventAggregator.Object, _mockCreator.Object);
            CreateParticipantViewModel();
        }

        [TestMethod]
        public void ShouldLoadParticipants()
        {
            var viewModel = new ParticipantNavigationViewModel(_mockDataProvider.Object, _mockView.Object, _mockEventAggregator.Object, _mockCreator.Object);
            viewModel.Load();

            Assert.AreEqual(5, viewModel.Participants.Count);

            var participant = viewModel.Participants.FirstOrDefault(x => x.ID == 123);
            Assert.IsNotNull(participant);
            Assert.AreEqual(participant?.DisplayName, "Joey");

            participant = viewModel.Participants.FirstOrDefault(x => x.ID == 123);
            Assert.IsNotNull(participant);
            Assert.AreEqual(participant?.DisplayName, "Joey");
        }

        [TestMethod]
        public void ShouldLoadParticipantsOnlyOnce()
        {
            var viewModel = new ParticipantNavigationViewModel(_mockDataProvider.Object, _mockView.Object, _mockEventAggregator.Object, _mockCreator.Object);
            viewModel.Load();
            viewModel.Load();
            Assert.AreEqual(5, viewModel.Participants.Count);
        }

        [TestMethod]
        public void ShouldLoadandSelectIt()
         {
            var navViewModel = new ParticipantNavigationViewModel(_mockDataProvider.Object, _mockView.Object, _mockEventAggregator.Object, _mockCreator.Object);
            const int participant = 7;
          
            _mockEvent.Object.Publish(participant);


            Assert.AreEqual(1, navViewModel.ViewModels.Count);

            var participantsViewModels = navViewModel.ViewModels.First();
            Assert.AreEqual(navViewModel.SelectedParticipantViewModel, participantsViewModels);

            _partViews.First().Verify(x=>x.Load(participant), Times.Once);

        }

        [TestMethod]
        public void ShouldAddViewModelONlyOnce()
        {
           _navViewModel = new ParticipantNavigationViewModel(_mockDataProvider.Object, _mockView.Object, _mockEventAggregator.Object, _mockCreator.Object);

            var openParticipant = new OpenPatientViewEvent();
            openParticipant.Publish(5);
            openParticipant.Publish(5);
           Assert.AreEqual(1, _navViewModel.ViewModels.Count);
        }



        private IParticipantViewModel CreateParticipantViewModel()
        {
            var participantViewModelMock = new Mock<IParticipantViewModel>();
            participantViewModelMock.Setup(vm => vm.Load(It.IsAny<int>())).Callback<int>(p =>
            {
                participantViewModelMock.Setup(vm => vm.Participant).Returns(new Participant() {ID = p});
            });
            _partViews.Add(participantViewModelMock);
            return participantViewModelMock.Object;
        }
    }
}
