using System.Windows;
using Scheduler.Entities;
using Scheduler.Factories;
using Scheduler.Repositories;
using Scheduler.Services;
using XirzoDIContainer.Container;

namespace Scheduler.WPF;

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var container = new ContainerDi();
        
        container.BindType<Repository<User>>().AsSingleton();
        container.BindType<Repository<Labwork>>().AsSingleton();
        
        container.BindType<EntityFactory<User>>().AsSingleton();
        container.BindType<EntityFactory<Labwork>>().AsSingleton();
        
        container.BindType<UserSelector>().AsSingleton();

        var userFactory = container.Resolve<EntityFactory<User>>();
        var labworkFactory = container.Resolve<EntityFactory<Labwork>>();

        userFactory.Create(id => new User(
            identifier: id,
            name: "Aleksandr Hvastunov"
        ));
        
        userFactory.Create(id => new User(
            identifier: id,
            name: "Vlad Sergey"
        ));
        
        userFactory.Create(id => new User(
            identifier: id,
            name: "Fedor Kyrilov"
        ));

        var window = new MainWindow(container)
        {
            Title = "Labwork 2"
        };
        
        window.Show();
    }
}