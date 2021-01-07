using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DynamicData.Binding;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace CheckPoints.Editor.Main
{
    internal class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public TreeView NavigationTree => this.FindControl<TreeView>("NavigationTree");

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.WhenPropertyChanged(x => x.ViewModel)
                    .Where(x => x.Value != null)
                    .InvokeCommand(this, x => x.ViewModel.LoadProjects)
                    .DisposeWith(disposables);
            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
