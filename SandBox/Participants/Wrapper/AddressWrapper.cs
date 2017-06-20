using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Participants.Wrapper
{
    public class AddressWrapper : ModelWrapper<Address>
    {
        public AddressWrapper(Address model) : base(model)
        {
        }

        #region Oblast
        public string Oblast
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string OblastOriginalValue => GetOriginalValue<string>(nameof(Oblast));

        public bool OblastIsChanged => GetIsChanged(nameof(Oblast));

        #endregion

        #region Region
        public string Region
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string RegionOriginalValue => GetOriginalValue<string>(nameof(Region));

        public bool RegionIsChanged => GetIsChanged(nameof(Region));
        #endregion
        
        #region Place
        public string Place
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string PlaceOriginalValue => GetOriginalValue<string>(nameof(Place));

        public bool PlaceIsChanged => GetIsChanged(nameof(Place));
        #endregion

        #region PostCode
        public string PostCode
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string PostCodeOriginalValue => GetOriginalValue<string>(nameof(PostCode));

        public bool PostCodeIsChanged => GetIsChanged(nameof(PostCode));
        #endregion

        #region Street
        public string Street
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string StreetOriginalValue => GetOriginalValue<string>(nameof(Street));

        public bool StreetIsChanged => GetIsChanged(nameof(Street));

        #endregion
    }
}
