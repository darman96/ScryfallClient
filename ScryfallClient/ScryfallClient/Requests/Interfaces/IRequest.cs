namespace ScryfallClient.Requests.Interfaces
{
    internal interface IRequest
    {
        public string EndpointUri { get; }
        public string Method { get; }
    }
}