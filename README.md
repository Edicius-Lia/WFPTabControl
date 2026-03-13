# WFPTabControl Demo

本项目是一个基于 WPF 的标签页控件演示，采用 MVVM 架构，并集成了依赖注入（DI）机制，使用 `CommunityToolkit.Mvvm` 实现数据绑定与命令。项目目标是展示如何在 WPF 应用中动态管理标签页，包括新增、关闭和切换标签页。

## 主要功能

- 动态添加标签页：通过命令添加新的标签页，避免重复标题。
- 关闭标签页：支持关闭当前选中的标签页，自动切换到最后一个标签页。
- 标签页切换：通过 `SelectedTab` 属性实现标签页切换。
- MVVM 架构：所有业务逻辑均在 ViewModel 层实现，界面与逻辑分离。
- 依赖注入：通过 .NET 的 DI 容器管理 ViewModel 和主窗口实例。

## 核心代码分析

### 依赖注入与应用启动

`App.xaml.cs` 中通过 `Microsoft.Extensions.DependencyInjection` 配置 DI 容器：

- `Services` 属性保存 DI 容器实例。
- `ConfigureServices()` 方法注册 `MainViewModel` 和 `MainWindow`，并将 `MainViewModel` 作为 `MainWindow` 的数据上下文。
- 启动时自动注入依赖，保证 ViewModel 生命周期和依赖管理。

### MainViewModel

- `Tabs`：标签页集合，类型为 `ObservableCollection<TabItemViewModel>`，支持动态增删。
- `SelectedTab`：当前选中的标签页。
- `NewTab(string header)`：新增标签页命令，避免重复标题。
- `CloseTab(TabItemViewModel tab)`：关闭指定标签页命令，关闭后自动切换到最后一个标签页。

### TabItemViewModel

- `Header`：标签页标题。

## 依赖

- .NET 8
- C# 12
- WPF
- CommunityToolkit.Mvvm
- Microsoft.Extensions.DependencyInjection


## 结构说明

- `App.xaml.cs`：应用入口，配置依赖注入。
- `ViewModels/MainViewModel.cs`：主视图模型，管理标签页集合与命令。
- `ViewModels/TabItemViewModel.cs`：标签页视图模型，包含标题属性。
- `MainWindow.xaml`：主窗口界面，绑定 ViewModel。

## 参考

- [CommunityToolkit.Mvvm 文档](https://docs.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/)
- [Microsoft.Extensions.DependencyInjection 文档](https://learn.microsoft.com/zh-cn/dotnet/core/extensions/dependency-injection)

## 展示
<img width="465" height="295" alt="image" src="https://github.com/user-attachments/assets/4daf1233-e9b6-4c97-aba2-fe3e4328fba7" />

