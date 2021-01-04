using CheckPoints.Editor.Common;
using CheckPoints.Logic;
using CheckPoints.NHibernate;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace CheckPoints.Editor.Main
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private readonly IProjectRepository _projectRepository;

        private bool _isInitialized;

        public bool IsInitialized
        {
            get => _isInitialized;
            private set => this.RaiseAndSetIfChanged(ref _isInitialized, value);
        }

        private IReadOnlyList<Project> _projects;

        public IReadOnlyList<Project> Projects
        {
            get => _projects;
            private set => this.RaiseAndSetIfChanged(ref _projects, value);
        }

        public MainWindowViewModel()
        {
            _projectRepository = new ProjectRepository();

            this.WhenActivated(disposables =>
            {
                LoadProjects().DisposeWith(disposables);
            });
        }

        private IDisposable LoadProjects()
        {
            return Observable.StartAsync(_projectRepository.GetWithSets)
                .Subscribe(projects =>
                {
                    Projects = new List<Project>(projects);
                    IsInitialized = true;
                });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}
