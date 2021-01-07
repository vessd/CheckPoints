using CheckPoints.Editor.Common;
using CheckPoints.Logic;
using DynamicData.Binding;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace CheckPoints.Editor.Main
{
    internal class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private readonly IProjectRepository _projectRepository;

        private readonly ObservableAsPropertyHelper<ObservableCollectionExtended<Project>> _projects;
        public ObservableCollectionExtended<Project> Projects => _projects.Value;
        public ReactiveCommand<Unit, IList<Project>> LoadProjects { get; }

        public MainWindowViewModel()
        {
            _projectRepository = Locator.Current.GetService<IProjectRepository>();

            LoadProjects = ReactiveCommand.CreateFromTask(_projectRepository.GetWithSets);
            _projects = LoadProjects.Select(list => new ObservableCollectionExtended<Project>(list))
                                    .ToProperty(this, x => x.Projects, scheduler: RxApp.MainThreadScheduler);
            LoadProjects.ThrownExceptions.Subscribe(exception =>
            {
                this.Log().Error("Error!", exception);
            });
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}
