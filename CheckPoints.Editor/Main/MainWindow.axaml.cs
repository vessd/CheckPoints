using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace CheckPoints.Editor.Main
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
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
            AvaloniaXamlLoader.Load(this);

            this.WhenActivated(disposables =>
            {
                //this.OneWayBind(ViewModel, x => x.Projects, x => x.NavigationTree.Items).DisposeWith(disposables);
            });
        }
    }
}
