namespace ScryfallClient.Requests.Interfaces
{
    public interface IRequest
    {
        public string EndpointUri { get; }
        public string Method { get; }
    }
}