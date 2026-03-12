# WFPTabControl Demo

本项目是一个基于 WPF 的标签页控件演示，采用 MVVM 架构，使用 `CommunityToolkit.Mvvm` 实现数据绑定与命令。项目目标是展示如何在 WPF 应用中动态管理标签页，包括新增、关闭和切换标签页。

## 主要功能

- 动态添加标签页：通过命令添加新的标签页，避免重复标题。
- 关闭标签页：支持关闭当前选中的标签页，自动切换到最后一个标签页。
- 标签页切换：通过 `SelectedTab` 属性实现标签页切换。
- MVVM 架构：所有业务逻辑均在 ViewModel 层实现，界面与逻辑分离。

## 核心代码分析

### MainViewModel

- `Tabs`：标签页集合，类型为 `ObservableCollection<TabItemViewModel>`，支持动态增删。
- `SelectedTab`：当前选中的标签页。
- `NewTab(string header)`：新增标签页命令，避免重复标题。
- `CloseTab(TabItemViewModel tab)`：关闭指定标签页命令，关闭后自动切换到最后一个标签页。

### TabItemViewModel

- `Header`：标签页标题，默认值为 "New Tab"。

## 依赖

- .NET 8
- C# 12
- WPF
- CommunityToolkit.Mvvm

## 使用方法

1. 克隆项目并在 Visual Studio 2022 打开。
2. 运行项目，主窗口展示标签页控件。
3. 点击按钮或通过界面操作添加、关闭标签页。

## 结构说明

- `ViewModels/MainViewModel.cs`：主视图模型，管理标签页集合与命令。
- `ViewModels/TabItemViewModel.cs`：标签页视图模型，包含标题属性。
- `MainWindow.xaml`：主窗口界面，绑定 ViewModel。
## 展示
<img width="545" height="242" alt="image" src="https://github.com/user-attachments/assets/cd77fc1e-6539-48db-a62f-25ac7da63e96" />

## 参考

- [CommunityToolkit.Mvvm 文档](https://docs.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/)
