using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WFPTabControl.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {
        // 将字段声明为可为 null
        private TabItemViewModel? _draggedItem;
     
        [ObservableProperty]
        private ObservableCollection<TabItemViewModel> _tabs = [];

        [ObservableProperty]
        private TabItemViewModel? _selectedTab;


        [RelayCommand]
        private void NewTab(string header)
        {
            var existing = Tabs.FirstOrDefault(t => t.Header == header);
            if (existing != null)
            {
                SelectedTab = existing;
                return;
            }

            var newTab = new TabItemViewModel { Header = header };
            Tabs.Add(newTab);
            SelectedTab = newTab;
        }

        [RelayCommand]
        private void CloseTab(TabItemViewModel tab)
        {
            Tabs.Remove(tab);
            if (SelectedTab == tab)
                SelectedTab = Tabs.LastOrDefault();
        }
    }
}
