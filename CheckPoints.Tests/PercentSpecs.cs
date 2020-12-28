using CheckPoints.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace CheckPoints.Tests
{
    public class PercentSpecs
    {
        [Fact]
        public void Percent_cannot_be_less_than_0()
        {
            Action action = () => new Percent(-0.01f);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Percent_cannot_be_greater_than_1()
        {
            Action action = () => new Percent(1.01f);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
