using Autofac;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.UI.Data;
using FriendOrganizer.DataAccess;
using Prism.Events;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<NavigationViewModel>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            return builder.Build();
        }
    }
}
