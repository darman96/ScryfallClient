using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class CardEndpoints : BaseEndpoints
    {
        public CardEndpoints(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Returns a List object containing Cards found using a fulltext search string.
        /// This string supports the same fulltext search system that the main site uses.
        /// <br/><br/>
        /// This method is paginated, returning 175 cards at a time.
        /// Review the documentation for paginating the List type and the Error type to understand
        /// all the possible output from this method.
        /// <br/><br/>
        /// If only one card is found, this method will still return a List.
        /// </summary>
        public async Task<ObjectList<Card>> SearchAsync(CardSearchRequest request)
            => await ExecuteRequestAsync<ObjectList<Card>>(request);

        /// <summary>
        /// Returns a Card based on a name search string. 
        /// This method is designed for building chat bots, forum bots, 
        /// and other services that need card details quickly.
        /// <br/><br/>
        /// If you provide the exact parameter, a card with that exact name is returned.
        /// Otherwise, a 404 Error is returned because no card matches.
        /// <br/><br/>
        /// If you provide the fuzzy parameter and a card name matches that string, then that card is returned.
        /// If not, a fuzzy search is executed for your card name. 
        /// The server allows misspellings and partial words to be provided. For example: jac bele will match Jace Beleren.
        /// <br/><br/>
        /// When fuzzy searching, a card is returned if the server is confident that you unambiguously identified a unique name with your string.
        /// Otherwise, you will receive a 404 Error object describing the problem: either more than 1 one card matched your search, or zero cards matched.
        /// <br/><br/>
        /// You may also provide a set code in the set parameter,
        /// in which case the name search and the returned card print will be limited to the specified set.
        /// <br/><br/>
        /// For both exact and fuzzy, card names are case-insensitive and punctuation is optional (you can drop apostrophes and periods etc).
        /// For example: fIReBALL is the same as Fireball and smugglers copter is the same as Smuggler's Copter.
        /// </summary>
        public async Task<Card> GetByNameAsync(CardNamedSearchRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a random Card.
        /// The optional parameter q supports the same fulltext search system that the main site uses.
        /// Providing q will filter the pool of cards before returning a random entry.
        /// </summary>
        public async Task<Card> GetRandomAsync(CardRandomRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Accepts a JSON array of card identifiers, and returns a List object with the collection of requested cards.
        /// A maximum of 75 card references may be submitted per request.
        /// The request must be posted with Content-Type as application/json.
        /// </summary>
        public async Task<ObjectList<Card>> GetCollectionAsync(CardCollectionRequest request)
            => await ExecuteRequestAsync<ObjectList<Card>>(request);

        /// <summary>
        /// Returns a single card with the given set code and collector number.
        /// You may optionally also append a lang part to the URL to retrieve a non-English version of the card.
        /// </summary>
        public async Task<Card> GetByCollectorInfoAsync(CardCollectorRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Multiverse ID.
        /// If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        public async Task<Card> GetByMultiverseIdAsync(CardMultiverseRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given MTGO ID (also known as the Catalog ID).
        /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        public async Task<Card> GetByMtgoIdAsync(CardMtgoRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Magic: The Gathering Arena ID.
        /// </summary>
        public async Task<Card> GetByArenaIdAsync(CardArenaRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given tcgplayer_id or tcgplayer_etched_id,
        /// also known as the productId on TCGplayer’s API.
        /// </summary>
        public async Task<Card> GetByTcgPlayerIdAsync(CardTcgPlayerRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given cardmarket_id, 
        /// also known as the idProduct" or the Product ID on Cardmarket’s APIs.
        /// </summary>
        public async Task<Card> GetByCardMarketIdAsync(CardCardMarketRequest request)
            => await ExecuteRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Scryfall ID.
        /// </summary>
        public async Task<Card> GetByScryfallIdAsync(CardByIdRequest request)
            => await ExecuteRequestAsync<Card>(request);
    }
}
