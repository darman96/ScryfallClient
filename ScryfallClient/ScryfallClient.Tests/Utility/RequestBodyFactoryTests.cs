// ReSharper disable UnusedAutoPropertyAccessor.Local
using Shouldly;
using System.Text.Json;
using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility;

namespace ScryfallClient.Tests.Utility;

public class RequestBodyFactoryTests
{
    private RequestBodyFactory requestBodyFactory;

    [SetUp]
    public void Setup()
    {
        requestBodyFactory = new RequestBodyFactory();
    }

    [Test]
    public void Create_WithValidRequest_ReturnsSerializedJson()
    {
        // Arrange
        var testObject = new TestObject { Value = "test value" };
        var request = new ValidRequest { Body = testObject };

        // Act
        var result = requestBodyFactory.Create(request);

        // Assert
        var expectedJson = JsonSerializer.Serialize(testObject);
        result.ShouldBe(expectedJson);
    }

    [Test]
    public void Create_WithMultipleBodyProperties_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new InvalidRequestWithMultipleBodyProperties
        {
            FirstBody = new TestObject { Value = "first" },
            SecondBody = new TestObject { Value = "second" }
        };

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => requestBodyFactory.Create(request))
            .Message.ShouldBe("Only one property can be marked with RequestBodyAttribute per request");
    }

    [Test]
    public void Create_WithComplexObject_ReturnsCorrectlySerializedJson()
    {
        // Arrange
        var complexObject = new ComplexTestObject
        {
            Id = 123,
            Name = "Complex Test",
            Items = ["Item1", "Item2", "Item3"]
        };
        var request = new ValidRequest { Body = complexObject };

        // Act
        var result = requestBodyFactory.Create(request);

        // Assert
        var expectedJson = JsonSerializer.Serialize(complexObject);
        result.ShouldBe(expectedJson);
    }

    private class TestObject
    {
        public required string Value { get; set; }
    }

    private class ComplexTestObject
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string[] Items { get; set; }
    }

    private class ValidRequest : IRequest
    {
        public string EndpointUri => "abc";
        public string Method => "POST";
        
        [RequestBody]
        public required object Body { get; set; }
    }

    private class InvalidRequestWithMultipleBodyProperties : IRequest
    {
        public string EndpointUri => "abc";
        public string Method => "POST";
        
        [RequestBody]
        public required object FirstBody { get; set; }

        [RequestBody]
        public required object SecondBody { get; set; }
    }
}