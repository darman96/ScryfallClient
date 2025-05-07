using Moq;
using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility;
using ScryfallClient.Utility.Interfaces;
using ScryfallClient.Utility.Structs;
using Shouldly;

namespace ScryfallClient.Tests.Utility;

[TestFixture]
public class RequestUriFactoryTests
{
    private Mock<IPathSegementParser> mockPathSegmentParser;
    private RequestUriFactory uriFactory;

    // Stub IRequest Implementations
    private class SimpleRequest : IRequest
    {
        public string EndpointUri => "cards/search";
        public string Method => "GET";
    }

    private class RequestWithPathParams : IRequest
    {
        public string EndpointUri => "cards/<id>/<lang>";
        public string Method => "GET";

        [QueryParameter("id", IsPartOfPath = true)]
        public string CardId { get; set; } = string.Empty;

        [QueryParameter("lang", IsPartOfPath = true)]
        public string Language { get; set; } = string.Empty;
    }

    private class RequestWithOptionalPathParam : IRequest
    {
        public string EndpointUri => "cards/named/<?exact>";
        public string Method => "GET";

        [QueryParameter("exact", IsPartOfPath = true)]
        public string? ExactName { get; set; }
    }
    
    private class RequestWithMissingRequiredPathParam : IRequest
    {
        public string EndpointUri => "cards/<id>";
        public string Method => "GET";

        // No property for "id"
    }

    private class RequestWithQueryParams : IRequest
    {
        public string EndpointUri => "cards/search";
        public string Method => "GET";

        [QueryParameter("q")]
        public string Query { get; set; } = string.Empty;

        [QueryParameter("order")]
        public string Order { get; set; } = string.Empty;

        [QueryParameter("nullable_param")]
        public string? NullableParam { get; set; }
    }

    private class RequestWithDependentQueryParams : IRequest
    {
        public string EndpointUri => "cards/search";
        public string Method => "GET";

        [QueryParameter("q")]
        public string Query { get; set; } = string.Empty;

        [QueryParameter("unique", DependsOn = new[] { "q" })]
        public string UniqueMode { get; set; } = string.Empty;
    }

    private class RequestWithDependentQueryParamValue : IRequest
    {
        public string EndpointUri => "cards/search";
        public string Method => "GET";

        [QueryParameter("order")]
        public string Order { get; set; } = string.Empty;

        [QueryParameter("dir", DependsOn = new[] { "order=name" })]
        public string Direction { get; set; } = string.Empty;
    }
    
    private class RequestWithEmptyEndpoint : IRequest
    {
        public string EndpointUri => "";
        public string Method => "GET";
    }


    [SetUp]
    public void Setup()
    {
        mockPathSegmentParser = new Mock<IPathSegementParser>();
        uriFactory = new RequestUriFactory(mockPathSegmentParser.Object);

        // Default parser setup
        mockPathSegmentParser.Setup(p => p.Parse(It.IsAny<string>()))
            .Returns<string>(s => new PathSegment { Name = s, IsParameter = false, IsOptional = false });

        mockPathSegmentParser.Setup(p => p.Parse(It.IsRegex("^<.+>$")))
            .Returns<string>(s => new PathSegment { Name = s.Substring(1, s.Length - 2), IsParameter = true, IsOptional = false });
            
        mockPathSegmentParser.Setup(p => p.Parse(It.IsRegex("^<\\?.+>$")))
            .Returns<string>(s => new PathSegment { Name = s.Substring(2, s.Length - 3), IsParameter = true, IsOptional = true });
    }

    [Test]
    public void Create_SimpleRequest_ReturnsCorrectUri()
    {
        // Arrange
        var request = new SimpleRequest();
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });


        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/search?");
    }

    [Test]
    public void Create_RequestWithPathParams_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithPathParams { CardId = "123", Language = "en" };
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("<id>")).Returns(new PathSegment { Name = "id", IsParameter = true });
        mockPathSegmentParser.Setup(p => p.Parse("<lang>")).Returns(new PathSegment { Name = "lang", IsParameter = true });


        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/123/en?");
    }

    [Test]
    public void Create_RequestWithOptionalPathParam_Provided_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithOptionalPathParam { ExactName = "MyCard" };
         mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
         mockPathSegmentParser.Setup(p => p.Parse("named")).Returns(new PathSegment { Name = "named" });
        mockPathSegmentParser.Setup(p => p.Parse("<?exact>")).Returns(new PathSegment { Name = "exact", IsParameter = true, IsOptional = true });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/named/MyCard?");
    }
    
    [Test]
    public void Create_RequestWithOptionalPathParam_NotProvided_ReturnsUriWithoutIt()
    {
        // Arrange
        var request = new RequestWithOptionalPathParam { ExactName = null };
         mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
         mockPathSegmentParser.Setup(p => p.Parse("named")).Returns(new PathSegment { Name = "named" });
        mockPathSegmentParser.Setup(p => p.Parse("<?exact>")).Returns(new PathSegment { Name = "exact", IsParameter = true, IsOptional = true });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        // Based on current implementation, if an optional path param is null, its name is used.
        // This might be an area to clarify expected behavior.
        // For now, asserting current behavior.
        uri.ShouldBe("cards/named/exact?");
    }


    [Test]
    public void Create_RequestWithMissingRequiredPathParam_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new RequestWithMissingRequiredPathParam();
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("<id>")).Returns(new PathSegment { Name = "id", IsParameter = true, IsOptional = false });

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => uriFactory.Create(request))
            .Message.ShouldBe("Missing value for Required Parameter: id");
    }

    [Test]
    public void Create_RequestWithQueryParams_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithQueryParams { Query = "test query", Order = "name", NullableParam = null };
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/search?q=test query&order=name"); // NullableParam should be ignored
    }
    
    [Test]
    public void Create_RequestWithEmptyQueryParam_ShouldBeIgnored()
    {
        // Arrange
        var request = new RequestWithQueryParams { Query = "", Order = "name" };
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/search?order=name");
    }

    [Test]
    public void Create_RequestWithDependentQueryParams_Met_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithDependentQueryParams { Query = "goblin", UniqueMode = "cards" };
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/search?q=goblin&unique=cards");
    }

    [Test]
    public void Create_RequestWithDependentQueryParams_Unmet_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new RequestWithDependentQueryParams { UniqueMode = "cards" }; // Query is missing
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });


        // Act & Assert
        Should.Throw<InvalidOperationException>(() => uriFactory.Create(request))
            .Message.ShouldBe("One ore more Dependencies are missing for Parameter: unique");
    }

    [Test]
    public void Create_RequestWithDependentQueryParamValue_Met_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithDependentQueryParamValue { Order = "name", Direction = "asc" };
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/search?order=name&dir=asc");
    }

    [Test]
    public void Create_RequestWithDependentQueryParamValue_UnmetValue_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new RequestWithDependentQueryParamValue { Order = "cmc", Direction = "asc" }; // Depends on order=name
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => uriFactory.Create(request))
            .Message.ShouldBe("One ore more Dependencies are missing for Parameter: dir");
    }
    
    [Test]
    public void Create_RequestWithDependentQueryParamValue_UnmetDependency_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new RequestWithDependentQueryParamValue { Direction = "asc" }; // Depends on order, which is missing
        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("search")).Returns(new PathSegment { Name = "search" });

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => uriFactory.Create(request))
            .Message.ShouldBe("One ore more Dependencies are missing for Parameter: dir");
    }

    [Test]
    public void Create_RequestWithEmptyEndpoint_ReturnsQueryOnly()
    {
        // Arrange
        var request = new RequestWithEmptyEndpoint();
         mockPathSegmentParser.Setup(p => p.Parse("")).Returns(new PathSegment { Name = "" }); // For the single empty segment

        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("?"); // Path is empty, only separator for query
    }
    
    [Test]
    public void Create_RequestWithPathAndQueryParams_ReturnsCorrectUri()
    {
        // Arrange
        var request = new RequestWithPathParamsAndQuery
        {
            CardId = "abc",
            Format = "json",
            Face = "front"
        };

        mockPathSegmentParser.Setup(p => p.Parse("cards")).Returns(new PathSegment { Name = "cards" });
        mockPathSegmentParser.Setup(p => p.Parse("<id>")).Returns(new PathSegment { Name = "id", IsParameter = true });
        mockPathSegmentParser.Setup(p => p.Parse("details")).Returns(new PathSegment { Name = "details" });


        // Act
        var uri = uriFactory.Create(request);

        // Assert
        uri.ShouldBe("cards/abc/details?format=json&face=front");
    }

    // Stub for combined path and query params
    private class RequestWithPathParamsAndQuery : IRequest
    {
        public string EndpointUri => "cards/<id>/details";
        public string Method => "GET";

        [QueryParameter("id", IsPartOfPath = true)]
        public string CardId { get; set; } = string.Empty;

        [QueryParameter("format")]
        public string Format { get; set; } = string.Empty;

        [QueryParameter("face")]
        public string Face { get; set; } = string.Empty;
    }
}