using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using Common.Models;
using Microsoft.Practices.Unity;
using Participants.DataProvider;
using Participants.ViewModels;
using Participants.Views;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Participants
{
    public class ParticipantsModule : IModule
    {
        private IUnityContainer container;
        private IRegionManager manager;

        public ParticipantsModule(IUnityContainer container, IRegionManager manager)
        {
            this.container = container;
            this.manager = manager;
        }
        public void Initialize()
        {
            container.RegisterType(typeof(IParticipantViewCreator), typeof(ParticipantViewCreator));
            container.RegisterType(typeof(IParticipantNavigationView), typeof(ParticipantNavigationView));
            container.RegisterType(typeof(IParticipantNavigationViewModel), typeof(ParticipantNavigationViewModel));

            container.RegisterType(typeof(IParticipantView), typeof(ParticipantView));
            //container.RegisterType(typeof(IParticipantViewModel), typeof(ParticipantViewModel));
            container.RegisterType(typeof(IParticipantService), typeof(ParticipantService));
            container.RegisterType(typeof(INavigationDataProvider), typeof(NavigationDataProvider));

            var vm = container.Resolve<ParticipantNavigationViewModel>();
            
            IRegion region = manager.Regions[RegionsName.LeftContentRegion];
            region.Add(vm.View);
            var vm2 = container.Resolve<ParticipantViewModel>();

            region = manager.Regions[RegionsName.RightContentRegion];
            region.Add(vm2.View);

        }
    } 
}
