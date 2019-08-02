using System;
using System.Collections.Generic;
using System.Text;
using MerchantGalaxy;
using Xunit;

namespace MerchantGalaxy.Tests
{
    public class ProcessorTests
    {
        private Processor _processor = new Processor();
        [Fact]
        public void ProcessAssignedLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            var AssignedConstants = _processor.AssignedConstants;
            AssignedConstants.TryGetValue("glob", out string Glob);
            Assert.Equal("I", Glob);
        }

        [Fact]
        public void ProcessInvalidAssignedLineTest()
        {
            _processor.ProcessAssignedLine("is glob I");
            var AssignedConstants = _processor.AssignedConstants;
            Assert.False(AssignedConstants.ContainsKey("glob"));

        }
        [Fact]
        public void ProcessCreditsLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            var ComputedLiterals = _processor.ComputedLiterals;
            ComputedLiterals.TryGetValue("Silver", out string Silver);
            Assert.Equal("17", Silver);
        }

        [Fact]
        public void ProcessInvalidCreditsLineTest()
        {
            _processor.ProcessAssignedLine("glob is V");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            var ComputedLiterals = _processor.ComputedLiterals;
            ComputedLiterals.TryGetValue("Silver", out string Silver);
            Assert.NotEqual("17", Silver);

        }
        [Fact]
        public void ProcessQuestionHowManyLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            _processor.ProcessAssignedLine("prok is V");
            _processor.ProcessAssignedLine("pish is X");
            _processor.ProcessAssignedLine("tegj is L");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            _processor.ProcessQuestionHowManyLine("how many Credits is glob prok Silver ?");
            var output = _processor.Output;
            Assert.Equal("glob prok Silver is 68 Credits", output[0]);
        }

        [Fact]
        public void ProcessInvalidQuestionHowManyLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            _processor.ProcessAssignedLine("prok is V");
            _processor.ProcessAssignedLine("pish is X");
            _processor.ProcessAssignedLine("tegj is L");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            _processor.ProcessQuestionHowManyLine("how much wood could a woodchuck chuck if a woodchuck could chuck wood");
            var output = _processor.Output;
            Assert.Equal(0, output.Count);

        }
        [Fact]
        public void ProcessQuestionHowMuchLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            _processor.ProcessAssignedLine("prok is V");
            _processor.ProcessAssignedLine("pish is X");
            _processor.ProcessAssignedLine("tegj is L");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            _processor.ProcessQuestionHowMuchLine("how much is pish tegj glob glob ?");
            var output = _processor.Output;
            Assert.Equal("pish tegj glob glob is 42", output[0]);
        }

        [Fact]
        public void ProcessInvalidQuestionHowMuchLineTest()
        {
            _processor.ProcessAssignedLine("glob is I");
            _processor.ProcessAssignedLine("prok is V");
            _processor.ProcessAssignedLine("pish is X");
            _processor.ProcessAssignedLine("tegj is L");
            _processor.ProcessCreditsLine("glob glob Silver is 34 Credits");
            _processor.ProcessQuestionHowMuchLine("how much wood could a woodchuck chuck if a woodchuck could chuck wood");
            var output = _processor.Output;
            Assert.Equal(0, output.Count);

        }

    }
}
