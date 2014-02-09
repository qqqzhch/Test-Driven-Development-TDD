using Castle.MicroKernel.Registration;
using DataRepository;
using DataRepository.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnwebTDD.Core.Installers
{
    public class DataRepositoriesInstaller : IWindsorInstaller
    {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {

            container.Register(
               Component.For<DataRepository.IO.Iquestion>()
               .ImplementedBy<DataRepository.DO.questionR>()
               .LifestyleSingleton()
                        );
            container.Register(
                   Component.For<DataRepository.IO.Ianswer>()
                   .ImplementedBy<DataRepository.DO.answerR>()
                   .LifestyleSingleton()
                            );
            container.Register(
                         Component.For<DataRepository.IO.Iquestiontag>()
                         .ImplementedBy<DataRepository.DO.questiontagR>()
                         .LifestyleSingleton()
                                  );
            container.Register(
                                   Component.For<DataRepository.IO.Itag>()
                                   .ImplementedBy<DataRepository.DO.tagR>()
                                   .LifestyleSingleton()
                                            );
            container.Register(
                                           Component.For<DataRepository.IO.Iurlinfo>()
                                           .ImplementedBy<DataRepository.DO.urlinfoR>()
                                           .LifestyleSingleton()
                                                    );

            container.Register(
                                        Component.For<DataRepository.IO.Iuserinfo>()
                                        .ImplementedBy<DataRepository.DO.userinfoR>()
                                        .LifestyleSingleton()
                                                 );
            container.Register(
                                                    Component.For<DataRepository.IO.ISite>()
                                                    .ImplementedBy<DataRepository.DO.siteR>()
                                                    .LifestyleSingleton()
                                                             );


        }
    }
}
