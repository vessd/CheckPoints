using CheckPoints.NHibernate;
using CheckPoints.NHibernate.Common;
using Xunit;

namespace CheckPoints.Tests
{
    public class TemporaryTest
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init("Server=localhost;port=5432;Database=tronix;User Id=postgres;Password=postgres;");

            var repository = new SetRepository();
            /*var set = new Set(new Name("ТЗ по 303"));
            set.AddGroup(new Name("НПКБ"), 1);
            set.AddGroup(new Name("Контрагенты"), 2);
            var saveTask = repository.Save(set);
            saveTask.Wait();*/
            var setTask = repository.GetByIdAsync(2);
            setTask.Wait();
            var set = setTask.Result;
        }
    }
}
