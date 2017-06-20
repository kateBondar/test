using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participants.Wrapper;

namespace ParticipantsTests
{
    [TestClass]
    public class ChangeTrackingComplexProperty
    {
        [TestMethod]
        public void ShouldSetIsChangedOfFriendWrapper()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);

            wrapper.Address.Place = "New Place";
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.Address.Place = "Place";
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventOfParticipantWrapper()
        {
            var fired = false;
            var participant = BuildParticipant();

            var wrapper = new ParticipantWrapper(participant);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.Address.Place = "New place";
            Assert.AreEqual(fired, true);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);
            var newPlace = "New Place";

            wrapper.Address.Place = newPlace;

            Assert.AreEqual(newPlace, wrapper.Address.Place);
            Assert.AreEqual("Place", wrapper.Address.PlaceOriginalValue);

            wrapper.AcceptChanges();

            Assert.AreEqual(newPlace, wrapper.Address.Place);
            Assert.AreEqual(newPlace, wrapper.Address.PlaceOriginalValue);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRevertChanges()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);
            var newPlace = "New Place";

            wrapper.Address.Place = newPlace;

            Assert.AreEqual(newPlace, wrapper.Address.Place);
            Assert.AreEqual("Place", wrapper.Address.PlaceOriginalValue);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges(); ;

            Assert.AreEqual("Place", wrapper.Address.Place);
            Assert.AreEqual("Place", wrapper.Address.PlaceOriginalValue);
            Assert.IsFalse(wrapper.IsChanged);

        }

        private Participant BuildParticipant()
        {
            return new Participant()
            {
                FirstName = "Name",
                ID = 3,
                Address = new Address { Place = "Place" }
            };
        }
    }
}
