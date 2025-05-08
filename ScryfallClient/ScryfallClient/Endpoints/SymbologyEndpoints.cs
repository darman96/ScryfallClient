using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class SymbologyEndpoints : BaseEndpoints
    {
        public SymbologyEndpoints(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Returns a List of all Card Symbols.
        /// </summary>
        public async Task<ObjectList<CardSymbol>> GetAsync(SymbologyRequest request)
            => await ExecuteRequestAsync<ObjectList<CardSymbol>>(request);

        /// <summary>
        /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
        /// <br/><br/>
        /// The server understands most community shorthand for mana costs (such as 2WW for {2}{W}{W}).
        /// Symbols can also be out of order, lowercase, or have multiple colorless costs (such as 2{g}2 for {4}{G}).
        /// <br/><br/>
        /// If part of the string could not be understood, the server will return an Error object describing the problem.
        /// </summary>
        public async Task<ManaCost> ParseManaAsync(ParseManaRequest request)
            => await ExecuteRequestAsync<ManaCost>(request);
    }
}
