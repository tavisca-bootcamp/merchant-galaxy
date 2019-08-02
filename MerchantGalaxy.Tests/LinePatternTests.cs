using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MerchantGalaxy.Conversations;

namespace MerchantGalaxy.Tests
{
    public class LinePatternTests
    {
        private ConversationLine _conversationLine = new ConversationLine();
        [Fact]
        public void ValidAssignmentLineTest()
        {
            Assert.Equal(LineType.Assigned, _conversationLine.GetLineType("glob is I"));
        }

        [Fact]
        public void InvalidAssignmentLineTest()
        {
            Assert.NotEqual(LineType.Assigned, _conversationLine.GetLineType("how much is I"));
        }

        [Fact]
        public void ValidAssignmentCreditsLineTest()
        {
            Assert.Equal(LineType.Credits, _conversationLine.GetLineType("glob glob Silver is 34 Credits"));
        }

        [Fact]
        public void InvalidAssignmentCreditsLineTest()
        {
            Assert.NotEqual(LineType.Assigned, _conversationLine.GetLineType("glob glob Gold can 100 credits"));
        }

        [Fact]
        public void ValidHowMuchQuestionLineTest()
        {
            Assert.Equal(LineType.Question_How_Much, _conversationLine.GetLineType("how much is pish tegj glob glob ?"));
        }

        [Fact]
        public void InvalidHowMuchQuestionLineTest()
        {
            Assert.NotEqual(LineType.Question_How_Much, _conversationLine.GetLineType("glob prok Gold is 57800 Credits"));
        }

        [Fact]
        public void ValidHowManyQuestionLineTest()
        {
            Assert.Equal(LineType.Question_How_Many, _conversationLine.GetLineType("how many Credits is glob prok Gold ?"));
        }

        [Fact]
        public void InvalidHowManyQuestionLineTest()
        {
            Assert.NotEqual(LineType.Question_How_Many, _conversationLine.GetLineType("how much is pish tegj glob glob ?"));
        }

        [Fact]
        public void InvalidLineTest()
        {
            Assert.Equal(LineType.Nomatch, _conversationLine.GetLineType("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
        }
    }
}
