using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participants.Wrapper;

namespace ParticipantsTests
{
    [TestClass]
    public class ChangeTrackingSimplePropertyTests
    {
        [TestMethod]
        public void ShouldStoreOriginalValue()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);

            Assert.AreEqual(participant.FirstName, wrapper.NameOriginalValue);

            wrapper.FirstName = "New Name";

            Assert.AreEqual("Name", wrapper.NameOriginalValue);
        }

        [TestMethod]
        public void ShouldSetIsChanged()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);

            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.FirstName = "New Name";
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldNotSetIsChanged()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);

            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.FirstName = "New Name";
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.FirstName = "Name";
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);
            var newName = "New Name";

            wrapper.FirstName = newName;

            Assert.AreEqual(newName, wrapper.FirstName);
            Assert.AreEqual("Name", wrapper.NameOriginalValue);
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.AcceptChanges();

            Assert.AreEqual(newName, wrapper.FirstName);
            Assert.AreEqual(newName, wrapper.NameOriginalValue);
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

        }

        [TestMethod]
        public void ShouldRevertChanges()
        {
            var participant = BuildParticipant();
            var wrapper = new ParticipantWrapper(participant);
            var newName = "New Name";
            var originalName = "Name";

            wrapper.FirstName = newName;

            Assert.AreEqual(newName, wrapper.FirstName);
            Assert.AreEqual(originalName, wrapper.NameOriginalValue);
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges();;

            Assert.AreEqual(originalName, wrapper.FirstName);
            Assert.AreEqual(originalName, wrapper.NameOriginalValue);
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

        }

        private Participant BuildParticipant()
        {
            return new Participant()
            {
                FirstName = "Name",
                ID = 3, 
                Address = new Address()
            };
        }
    }
}
