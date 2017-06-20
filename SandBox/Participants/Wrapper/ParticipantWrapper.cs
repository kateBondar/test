using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Models;

namespace Participants.Wrapper
{
    public class ParticipantWrapper : ModelWrapper<Participant>
    {
        public ParticipantWrapper(Participant model) : base(model)
        {
            InitializeComplexProperty(model);
        }

        private void InitializeComplexProperty(Participant model)
        {
            if (model.Address == null)
            {
                throw new ArgumentException("Address cannot be null");
            }

            Address = new AddressWrapper(model.Address);
            RegisterComplex(Address);
        }


        public string FirstName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value, nameof(FirstName));
            }
        }

        public string NameOriginalValue => GetOriginalValue<string>(nameof(FirstName));

        public bool NameIsChanged => GetIsChanged(nameof(FirstName));

        public int ID
        {
            get { return GetValue<int>(); }
            set
            {
                SetValue(value, nameof(ID));
            }
        }


        public string Comment
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value, nameof(Comment));
            }
        }

        public bool IsRegistered
        {
            get { return GetValue<bool>(); }
            set
            {
                SetValue(value, nameof(IsRegistered));
            }
        }

        public AddressWrapper Address { get; private set; }
    }
}
