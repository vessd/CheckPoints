using CheckPoints.Logic;
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
            HasMany(x => x.Sets).Access.CamelCaseField(Prefix.Underscore).KeyColumn("id_project").Cascade.All().Not.LazyLoad();
        }
    }
}
