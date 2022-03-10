using BeatToSnareConverter;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class ConvertBeatToIntsTests
    {
        // [1, 1, 1, 1]  # => "sn4 sn4 sn4 sn4"
        [Fact]
        public void WHEN_Four_Beats_Are_Provided_THEN_Four_Snares_SHOULD_Be_Output()
        {
            // arrange
            List<int> inputBeats = new List<int>(){ 1,1,1,1 };
            List<int> expectedBeats = new List<int>(){ 4,4,4,4 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1, 0, 1, 1]  # => "sn2 sn4 sn4"
        [Fact]
        public void WHEN_Three_Beats_Are_Provided_THEN_Three_Snares_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>() { 2,4,4 };
            List<int> inputBeats = new List<int>(){ 1,0,1,1 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1, 0] # => "sn1"
        [Fact]
        public void WHEN_OneLong_Beat_is_Provided_THEN_One_Snare_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>(){ 1 };
            List<int> inputBeats = new List<int>() { 1,0 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1,0,1,0,1,0,1,0] # => "sn4 sn4 sn4 sn4"
        [Fact]
        public void WHEN_FourLong_Beats_Are_Provided_THEN_Four_Snares_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>() { 4,4,4,4 };
            List<int> inputBeats = new List<int>() { 1, 0, 1, 0, 1, 0, 1, 0 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1,0,0,0,1,0,0,0] # => "sn2 sn2"
        [Fact]
        public void WHEN_TwoLong_Beats_Are_Provided_THEN_Two_Snares_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>() { 4,4,4,4 };
            List<int> inputBeats = new List<int>() { 1, 0, 1, 0, 1, 0, 1, 0 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1,0,0,0] # => "sn1"
        [Fact]
        public void WHEN_OneExtraLong_Beat_Is_Provided_THEN_One_Extra_Long_Snare_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>() { 1 };
            List<int> inputBeats = new List<int>(){ 1, 0, 0, 0 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }

        // [1,0,0,0,1,1,1,1] # => "sn2 sn8 sn8 sn8 sn8"
        [Fact]
        public void WHEN_OneHalfLength_Beat_AND_Four_Short_Beats_Are_Provided_THEN_Two_Snares_AND_Four_Short_Snares_SHOULD_Be_Output()
        {
            // arrange
            List<int> expectedBeats = new List<int>() { 2,8,8,8,8 };
            List<int> inputBeats = new List<int>() { 1,0,0,0,1,1,1,1 };

            // act
            IBeatConverter converter = new BeatConverter();
            var result = converter.ConvertBeatToInts(inputBeats);

            // assert
            result.Should().Equal(expectedBeats);
        }
    }
}
