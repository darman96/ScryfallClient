using ScryfallClient.Utility.Structs;

namespace ScryfallClient.Utility.Interfaces
{
    public interface IPathSegementParser
    {
        PathSegment Parse(string segment);
    }
}