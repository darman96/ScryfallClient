using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Utility.Interfaces
{
    internal interface IRequestUriFactory
    {
        string Create(IRequest request);
    }
}