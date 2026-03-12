using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFPTabControl.ViewModels
{
    public partial class TabItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _header = "New Tab";
    }
}
