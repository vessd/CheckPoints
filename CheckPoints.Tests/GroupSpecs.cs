using CheckPoints.Logic;
using FluentAssertions;
using Xunit;

namespace CheckPoints.Tests
{
    public class GroupSpecs
    {
        [Fact]
        public void Group_can_add_CheckPoint()
        {
            var group = new Group(new Name("Группа 1"), 1);

            var result = group.AddCheckPoint(new Name("Контрольная точка 1"));

            result.Should().BeTrue();
            group.CheckPoints.Count.Should().Be(1);
        }
    }
}
