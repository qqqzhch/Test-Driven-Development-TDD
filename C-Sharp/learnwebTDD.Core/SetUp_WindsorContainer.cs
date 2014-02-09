using Castle.Windsor;
using Castle.Windsor.Installer;
using learnwebTDD.Core.Plugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace learnwebTDD.Core
{
public    class SetUp_WindsorContainer
    {
        private static IWindsorContainer container;

        public static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
