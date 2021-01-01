using CheckPoints.Logic;
using FluentNHibernate.Mapping;

namespace CheckPoints.NHibernate
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Table("doc_kt_groups");
            Id(x => x.Id).Column("doc_kt_group_id").GeneratedBy.Sequence("doc_kt_group_id_seq");

            References(x => x.Set).Column("id_doc_kt_set").Not.LazyLoad();
            Component(x => x.Name);
            Map(x => x.Position).Column("position");
        }
    }
}
