using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WFPTabControl.Pages;

namespace WFPTabControl.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {
        // 将字段声明为可为 null
        private TabItemViewModel? _draggedItem;
     
        [ObservableProperty]
        ObservableCollection<TabItemViewModel> _tabs = [];

        [ObservableProperty]
        private TabItemViewModel? _selectedTab=new();

        private readonly Dictionary<string, Page> _pageCache = new();

        [RelayCommand]
        void OpenPage1() => NewTab("Page1",  new Page1());

        [RelayCommand]
        void OpenPage2() => NewTab("Page2",  new Page2());

        private void NewTab(string header, Page page)
        {
            var existing = Tabs.FirstOrDefault(t => t.Header == header);
            if (existing != null)
            {
                SelectedTab = existing;
                return;
            }
            Page loadedPage;
            if (_pageCache.ContainsKey(header))
            {
                loadedPage = _pageCache[header];
            }
            else
            {
                loadedPage = page;
                _pageCache[header] = loadedPage;
            }
            var newTab = new TabItemViewModel ( header,new Frame() {Content=loadedPage });
            Tabs.Add(newTab);
            SelectedTab = newTab;
        }
        #region 释放内存
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

    }
}
