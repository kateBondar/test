using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Meetings.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Meetings
{
    public class MeetingModule : IModule
    {
        private IUnityContainer container;
        private IRegionManager manager;

        public MeetingModule(IUnityContainer container, IRegionManager manager)
        {
            this.container = container;
            this.manager = manager;
        }
        public void Initialize()
        {
            //manager.RegisterViewWithRegion(RegionsName.HeaderRegion, typeof(HeaderView));
            //manager.RegisterViewWithRegion(RegionsName.DetailsRegion, typeof(DetailsView));
        }
    }
}
