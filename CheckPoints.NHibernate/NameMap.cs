using CheckPoints.Logic;
using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace CheckPoints.NHibernate
{
    public class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            Map(Reveal.Member<Name>("_name")).Column("name");
        }
    }
}
