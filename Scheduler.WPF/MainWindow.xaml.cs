using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Scheduler.Entities;
using Scheduler.Repositories;
using Scheduler.Services;
using XirzoDIContainer.Container;

namespace Scheduler.WPF;

public partial class MainWindow : Window, IDisposable
{
    private readonly List<RadioButton> _buttons = new();
    private readonly UserSelector _selector;
    
    public MainWindow(ContainerDi container)
    {
        InitializeComponent();

        var userResository = container.Resolve<Repository<User>>();
        _selector = container.Resolve<UserSelector>();

        if (FindName("UserStackPanel") is StackPanel userStackPanel)
        {
            foreach (var user in userResository)
            {
                var button = new RadioButton
                {
                    Content = user.Name,
                    Tag = user
                };
                
                _buttons.Add(button);

                button.Checked += (sender, args) => 
                {
                    if (sender is RadioButton { Tag: User selectedUser })
                    {
                        OnUserButtonChecked(selectedUser);
                    }
                };
                
                userStackPanel.Children.Add(button);
            }
            
            if (_buttons.Count > 0)
            {
                _buttons[0].IsChecked = true;
            }
        }
        
        
        if (FindName("LabworkStackPanel") is StackPanel labworkStackPanel)
        {
            Type labworkType = typeof(Labwork);

            foreach (PropertyInfo property in labworkType.GetProperties())
            {
                Label label = new Label();
                label.Content = property.Name;
                labworkStackPanel.Children.Add(label);
                
                TextBox textBox = new TextBox();
                labworkStackPanel.Children.Add(textBox);
            }
        }
    }
    
    private void OnUserButtonChecked(User user)
    {
        _selector.SelectUser(user);
    }
    
    public void Dispose()
    {
        foreach (var button in _buttons)
        {
            button.Checked -= null;
        }
                
        _buttons.Clear();
                
        if (_selector is IDisposable disposableSelector)
        {
            disposableSelector.Dispose();
        }
            
        GC.SuppressFinalize(this);
    }
}