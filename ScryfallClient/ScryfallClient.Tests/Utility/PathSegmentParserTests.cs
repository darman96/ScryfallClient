using ScryfallClient.Utility;
using Shouldly;

namespace ScryfallClient.Tests.Utility;

[TestFixture]
public class PathSegmentParserTests
{
    private PathSegementParser parser;

    [SetUp]
    public void Setup()
    {
        parser = new PathSegementParser();
    }

    [Test]
    public void Parse_ShouldReturnCorrectPathSegment_WhenSegmentIsRegular()
    {
        // Arrange
        var segment = "cards";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("cards");
        result.IsParameter.ShouldBeFalse();
        result.IsOptional.ShouldBeFalse();
    }

    [Test]
    public void Parse_ShouldReturnCorrectPathSegment_WhenSegmentIsRequiredParameter()
    {
        // Arrange
        var segment = "<id>";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("id");
        result.IsParameter.ShouldBeTrue();
        result.IsOptional.ShouldBeFalse();
    }

    [Test]
    public void Parse_ShouldReturnCorrectPathSegment_WhenSegmentIsOptionalParameter()
    {
        // Arrange
        var segment = "<?format>";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("format");
        result.IsParameter.ShouldBeTrue();
        result.IsOptional.ShouldBeTrue();
    }

    [Test]
    public void Parse_ShouldReturnCorrectPathSegment_WhenSegmentIsOptionalParameterWithQuestionMarkInName()
    {
        // Arrange
        var segment = "<?query?>"; // This case might be ambiguous based on current implementation, let's test

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("query?"); // Based on `TrimStart('?')`
        result.IsParameter.ShouldBeTrue();
        result.IsOptional.ShouldBeTrue();
    }

    [Test]
    public void Parse_ShouldReturnNonParameter_WhenSegmentHasOnlyOpeningBracket()
    {
        // Arrange
        var segment = "<segment";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("<segment");
        result.IsParameter.ShouldBeFalse();
        result.IsOptional.ShouldBeFalse();
    }

    [Test]
    public void Parse_ShouldReturnNonParameter_WhenSegmentHasOnlyClosingBracket()
    {
        // Arrange
        var segment = "segment>";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("segment>");
        result.IsParameter.ShouldBeFalse();
        result.IsOptional.ShouldBeFalse();
    }

    [Test]
    public void Parse_ShouldReturnNonParameter_WhenSegmentIsEmpty()
    {
        // Arrange
        var segment = "";

        // Act
        var result = parser.Parse(segment);

        // Assert
        result.Name.ShouldBe("");
        result.IsParameter.ShouldBeFalse();
        result.IsOptional.ShouldBeFalse();
    }
}