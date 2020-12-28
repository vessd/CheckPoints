using CheckPoints.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace CheckPoints.Tests
{
    public class NameSpecs
    {
        [Fact]
        public void Name_cannot_be_null()
        {
            Action action = () => new Name(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Name_cannot_be_empty_or_whitespace()
        {
            Action action = () => new Name("    ");

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
