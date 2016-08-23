using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Arguments.Tests
{
    [TestFixture]
    public class ArgumentProcessorTests
    {
        [Test]
        public void Process_Should_ProcessArguments_When_NoAction()
        {
            var subject = ArgumentProcessor.Initialize(new[] {"a:123456789"});

            subject.AddArgument("a");

            var processedArguments = subject.Process().ToList();

            processedArguments.Should().HaveCount(1);
            processedArguments.First().Value.Should().Be("123456789");
        }

        [Test]
        public void Process_Should_ProcessArguments_When_NoDefaultArguments()
        {
            var subject = new ArgumentProcessor();

            var processedArguments = subject.Process();

            processedArguments.Should().BeEmpty();
        }

        [Test]
        public void Process_Should_ProcessArguments_When_SingleArgumentWithAction()
        {
            string value = null;
            var subject = ArgumentProcessor.Initialize(new[] {"a:123456789"});

            subject.AddArgument("a").WithAction(x => value = x);

            subject.Process();

            value.Should().Be("123456789");
        }
    }
}