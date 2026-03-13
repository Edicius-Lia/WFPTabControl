using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WFPTabControl.ViewModels
{
    public partial class TabItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _Header = "New Tab";

        [ObservableProperty]
        private object _Content = new object();

        public TabItemViewModel(string header,Frame frame )
        {
            Header = header;
            Content = frame;
        }
        public TabItemViewModel() { }
        [RelayCommand]
        private void Close()
        {
            var parentViewModel = App.Current.Services.GetService<MainViewModel>();
            if (parentViewModel != null)
            {
                parentViewModel.Tabs.Remove(this);
                MainViewModel.ClearMemory();
            }
        }
    }
}
