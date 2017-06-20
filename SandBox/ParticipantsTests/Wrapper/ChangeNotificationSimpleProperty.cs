using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participants.Wrapper;

namespace ParticipantsTests
{
    [TestClass()]
    public class ChangeNotificationSimpleProperty
    {
        private Participant _participant;

        [TestInitialize]
        public void Initialize()
        {
            _participant = new Participant
            {
                ID = 999,
                FirstName = "JustName",
                Comment = "just for testing", 
                Address = new Address()
            };
        }


        [TestMethod]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            
            var wrapper = new ParticipantWrapper(_participant);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.FirstName))
                {
                    fired = true;
                }
            };

            wrapper.FirstName = "New name";
            Assert.AreEqual(fired, true);
        }

        [TestMethod]
        public void ShouldNotRaisePropertyChangedEventOnPropertyDidNotChange()
        {
            var fired = false;

            var wrapper = new ParticipantWrapper(_participant);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.FirstName))
                {
                    fired = true;
                }
            };

            wrapper.FirstName = _participant.FirstName;
            Assert.IsFalse(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForNameWasChanged()
        {
            var fired = false;

            var wrapper = new ParticipantWrapper(_participant);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.FirstName = "New name";
            Assert.AreEqual(fired, true);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChanged()
        {
            var fired = false;

            var wrapper = new ParticipantWrapper(_participant);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.FirstName = "New name";
            Assert.AreEqual(fired, true);
        }
    }
}
