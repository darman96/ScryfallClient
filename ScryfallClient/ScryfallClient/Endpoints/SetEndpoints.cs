using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class SetEndpoints : BaseEndpoints
    {
        public SetEndpoints(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Returns a List object of all Sets on Scryfall.
        /// </summary>
        public async Task<ObjectList<Set>> GetAsync(SetsRequest request)
            => await ExecuteRequestAsync<ObjectList<Set>>(request);

        /// <summary>
        /// Returns a Set with the given set code.
        /// The code can be either the code or the mtgo_code for the set.
        /// </summary>
        public async Task<Set> GetByCodeAsync(SetByCodeRequest request)
            => await ExecuteRequestAsync<Set>(request);

        /// <summary>
        /// Returns a Set with the given Scryfall id.
        /// </summary>
        public async Task<Set> GetByIdAsync(SetByIdRequest request)
            => await ExecuteRequestAsync<Set>(request);

        /// <summary>
        /// Returns a Set with the given tcgplayer_id, also known as the groupId on TCGplayer’s API.
        /// </summary>
        public async Task<Set> GetByTcgPlayerIdAsync(SetByTcgPlayerIdRequest request)
            => await ExecuteRequestAsync<Set>(request);
    }
}
