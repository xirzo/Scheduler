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
        container.BindType<Repository<Subject>>().AsSingleton();
        
        container.BindType<CloneableFactory<User>>().AsSingleton();
        container.BindType<CloneableFactory<Labwork>>().AsSingleton();
        container.BindType<CloneableFactory<Subject>>().AsSingleton();

        container.BindType<UserSelector>().AsSingleton();

        var userFactory = container.Resolve<CloneableFactory<User>>();
        var subjectFactory = container.Resolve<CloneableFactory<Subject>>();

        userFactory.Create(id => new User(
            identifier: id,
            name: "Aleksandr Hvastunov"
        ));
        
        var vladSergey = userFactory.Create(id => new User(
            identifier: id,
            name: "Vlad Sergey"
        ));
        
        userFactory.Create(id => new User(
            identifier: id,
            name: "Fedor Kyrilov"
        ));

        subjectFactory.Create(id => new Subject(
            identifier: id,
            name: "OP",
            labworks: [],
            lectureMaterials: [],
            finalsType: FinalsType.Test,
            author: vladSergey,
            parentIdentifier: null,
            minTestScore:20));

        var window = new MainWindow(container)
        {
            Title = "Labwork 2"
        };
        
        window.Show();
    }
}