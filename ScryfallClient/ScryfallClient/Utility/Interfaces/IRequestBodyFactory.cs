using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Utility.Interfaces
{
    internal interface IRequestBodyFactory
    {
        string Create(IRequest request);
    }
}