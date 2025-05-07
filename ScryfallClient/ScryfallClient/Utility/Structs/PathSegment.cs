namespace ScryfallClient.Utility.Structs
{
    public struct PathSegment
    {
        public string Name { get; set; }
        public string? Value { get; set; }
        public bool IsOptional { get; set; }
        public bool IsParameter { get; set; }
    }
}