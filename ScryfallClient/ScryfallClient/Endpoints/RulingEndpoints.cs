using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class RulingEndpoints : BaseEndpoints
    {
        public RulingEndpoints(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Returns a List of rulings for a card with the given Multiverse ID.
        /// If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetByMultiverseIdAsync(RulingsByMultiverseIdRequest request)
            => await ExecuteRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns rulings for a card with the given MTGO ID (also known as the Catalog ID).
        /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetByMtgoIdAsync(RulingsByMtgoIdRequest request)
            => await ExecuteRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns rulings for a card with the given Magic: The Gathering Arena ID.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetByArenaIdAsync(RulingsByArenaIdRequest request)
            => await ExecuteRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns a List of rulings for the card with the given set code and collector number.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetByCollectorInfoAsync(RulingsByCollectorInfoRequest request)
            => await ExecuteRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns a List of rulings for a card with the given Scryfall ID.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetByScryfallIdAsync(RulingsByScryfallIdRequest request)
            => await ExecuteRequestAsync<ObjectList<Ruling>>(request);
    }
}
