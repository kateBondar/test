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
    public class ChangeNotificationComplexProperty
    {
        [TestMethod]
        public void ShouldInitializeAddressProperty()
        {
            var participant = BuildParticipant();
            var wrapper =  new ParticipantWrapper(participant);

            Assert.IsNotNull(wrapper.Address);
            Assert.AreEqual(participant.Address, wrapper.Address.Model);

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
