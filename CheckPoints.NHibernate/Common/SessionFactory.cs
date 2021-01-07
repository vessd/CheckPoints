using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Logging.Serilog;
using System.Reflection;

namespace CheckPoints.NHibernate.Common
{
    public static class SessionFactory
    {
        private static ISessionFactory _factory;

        internal static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);
        }

        private static ISessionFactory BuildSessionFactory(string connectionString)
        {
            NHibernateLogger.SetLoggersFactory(new SerilogLoggerFactory());

            return Fluently.Configure()
                           .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                           .BuildSessionFactory();
        }
    }
}
