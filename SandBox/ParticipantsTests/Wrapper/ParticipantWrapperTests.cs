using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participants.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Models;

namespace Participants.Wrapper.Tests
{
    [TestClass()]
    public class ParticipantWrapperTests
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

        [TestMethod()]
        public void ParticipantWrapperTest()
        { 
            var wrapper = new ParticipantWrapper(_participant);
            Assert.AreEqual(_participant, wrapper.Model);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrownArgumentExceptionIfModelIsNull()
        {
            try
            {
                var wrapper = new ParticipantWrapper(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("model", e.ParamName);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void ShouldThrowArgumentNullException_AddressIsNull()
        {
            try
            {
                _participant.Address = null;
                var wrapper = new ParticipantWrapper(_participant);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Address cannot be null", e.Message);
                throw;
            }
        }

        [TestMethod]
        public void ShouldSetValueOfunderlyingModelProperty()
        {
            var expectedName = "New Name";

            var wrapper = new ParticipantWrapper(_participant);
            wrapper.FirstName = expectedName;

            Assert.AreEqual(expectedName, wrapper.Model.FirstName);
        }

        [TestMethod]
        public void ShouldGetValueOfunderlyingModelProperty()
        {
            var wrapper = new ParticipantWrapper(_participant);

            Assert.AreEqual(_participant.FirstName, wrapper.Model.FirstName);
        }
    }
}