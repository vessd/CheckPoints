using CheckPoints.Logic;
using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace CheckPoints.NHibernate
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("project_list");
            Id(x => x.Id).Column("project_id");

            Component(x => x.Name);
            HasMany<Set>(Reveal.Member<Project>("_sets")).KeyColumn("id_project").Cascade.All().Not.LazyLoad();
            HasMany(x => x.Sets).KeyColumn("id_project").ReadOnly().Not.LazyLoad();
        }
    }
}
