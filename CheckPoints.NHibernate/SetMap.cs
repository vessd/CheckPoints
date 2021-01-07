using CheckPoints.Logic;
using FluentNHibernate.Mapping;

namespace CheckPoints.NHibernate
{
    public class SetMap : ClassMap<Set>
    {
        public SetMap()
        {
            Table("doc_kt_sets");
            Id(x => x.Id).Column("doc_kt_set_id").GeneratedBy.Sequence("doc_kt_set_id_seq");

            References(x => x.Project).Column("id_project").Not.LazyLoad();
            Component(x => x.Name);
            HasMany(x => x.Groups).Access.CamelCaseField(Prefix.Underscore)
                                         .KeyColumn("id_doc_kt_set")
                                         .Cascade.All()
                                         .Not.LazyLoad();
        }
    }
}
