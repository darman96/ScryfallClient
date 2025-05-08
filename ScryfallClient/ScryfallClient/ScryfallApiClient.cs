using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ScryfallClient.Converters;
using ScryfallClient.Models;
using ScryfallClient.Requests;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility;
using ScryfallClient.Utility.Interfaces;

namespace ScryfallClient
{
    public class ScryfallApiClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly IRequestUriFactory uriFactory = new RequestUriFactory(new PathSegementParser());
        private readonly IRequestBodyFactory bodyFactory = new RequestBodyFactory();
        private readonly Uri baseUri = new Uri("https://api.scryfall.com/");
        
        public ScryfallApiClient()
        {
            this.httpClient = httpClient ?? new HttpClient
            {
                BaseAddress = baseUri,
            };
            
            this.httpClient
                .DefaultRequestHeaders
                .UserAgent
                .Add(new ProductInfoHeaderValue("ScryfallClient", "1.0.0"));
            
            this.httpClient
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

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
        public async Task<ObjectList<Card>> GetCardsSearchAsync(CardSearchRequest request)
            => await executeRequestAsync<ObjectList<Card>>(request);

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
        public async Task<Card> GetCardByNameAsync(CardNamedSearchRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a Catalog object containing up to 20 full English card names that could be autocompletions of the given string parameter.
        /// <br/><br/>
        /// This method is designed for creating assistive UI elements that allow users to free-type card names.
        /// <br/><br/>
        /// The names are sorted with the nearest match first, highly favoring results that begin with your given string.
        /// <br/><br/>
        /// Spaces, punctuation, and capitalization are ignored.
        /// <br/><br/>
        /// If q is less than 2 characters long, or if no names match, the Catalog will contain 0 items (instead of returning any errors).
        /// </summary>
        public async Task<Catalog> GetCardAutocompletionAsync(CardAutocompleteRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a single random Card object.
        /// <br/><br/>
        /// The optional parameter q supports the same fulltext search system that the main site uses.
        /// Providing q will filter the pool of cards before returning a random entry.
        /// </summary>
        public async Task<Card> GetRandomCardAsync(CardRandomRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Accepts a JSON array of card identifiers, and returns a List object with the collection of requested cards.
        /// A maximum of 75 card references may be submitted per request.
        /// The request must be posted with Content-Type as application/json.
        /// </summary>
        public async Task<ObjectList<Card>> GetCardsCollectionAsync(CardCollectionRequest request)
            => await executeRequestAsync<ObjectList<Card>>(request);

        /// <summary>
        /// Returns a single card with the given set code and collector number.
        /// You may optionally also append a lang part to the URL to retrieve a non-English version of the card.
        /// </summary>
        public async Task<Card> GetCardByCollectorInfoAsync(CardCollectorRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Multiverse ID.
        /// If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        public async Task<Card> GetCardByMultiverseIdAsync(CardMultiverseRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given MTGO ID (also known as the Catalog ID).
        /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        public async Task<Card> GetCardByMtgoIdAsync(CardMtgoRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Magic: The Gathering Arena ID.
        /// </summary>
        public async Task<Card> GetCardByArenaIdAsync(CardArenaRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given tcgplayer_id or tcgplayer_etched_id,
        /// also known as the productId on TCGplayer’s API.
        /// </summary>
        public async Task<Card> GetCardByTcgPlayerIdAsync(CardTcgPlayerRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given cardmarket_id, 
        /// also known as the idProduct" or the Product ID on Cardmarket’s APIs.
        /// </summary>
        public async Task<Card> GetCardByCardMarketIdAsync(CardCardMarketRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a single card with the given Scryfall ID.
        /// </summary>
        public async Task<Card> GetCardByScryfallIdAsync(CardByIdRequest request)
            => await executeRequestAsync<Card>(request);

        /// <summary>
        /// Returns a List of rulings for a card with the given Multiverse ID.
        /// If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetRulingsByMultiverseIdAsync(RulingsByMultiverseIdRequest request)
            => await executeRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns rulings for a card with the given MTGO ID (also known as the Catalog ID).
        /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetRulingsByMtgoIdAsync(RulingsByMtgoIdRequest request)
            => await executeRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns rulings for a card with the given Magic: The Gathering Arena ID.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetRulingsByArenaIdAsync(RulingsByArenaIdRequest request)
            => await executeRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns a List of rulings for the card with the given set code and collector number.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetRulingsByCollectorInfoAsync(RulingsByCollectorInfoRequest request)
            => await executeRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns a List of rulings for a card with the given Scryfall ID.
        /// </summary>
        public async Task<ObjectList<Ruling>> GetRulingsByScryfallIdAsync(RulingsByScryfallIdRequest request)
            => await executeRequestAsync<ObjectList<Ruling>>(request);

        /// <summary>
        /// Returns a list of all nontoken English card names in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCardNamesCatalogAsync(CatalogCardNamesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a list of all canonical artist names in Scryfall’s database.
        /// This catalog won’t include duplicate, misspelled, or funny names for artists.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetArtistNamesCatalogAsync(CatalogArtistNamesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all English words, of length 2 or more, that could appear in a card name.
        /// Values are drawn from cards currently in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetWordBankCatalogAsync(CatalogWordBankRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Magic card supertypes.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetSupertypesCatalogAsync(CatalogSupertypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Magic card types.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCardTypesCatalogAsync(CatalogCardTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all artifact types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetArtifactTypesCatalogAsync(CatalogArtifactTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Battle types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetBattleTypesCatalogAsync(CatalogBattleTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all creature types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCreatureTypesCatalogAsync(CatalogCreatureTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all enchantment types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetEnchantmentTypesCatalogAsync(CatalogEnchantmentTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Land types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetLandTypesCatalogAsync(CatalogLandTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Planeswalker types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetPlaneswalkerTypesCatalogAsync(CatalogPlaneswalkerTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all spell types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetSpellTypesCatalogAsync(CatalogSpellTypesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s power in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetPowersCatalogAsync(CatalogPowersRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s toughness in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetToughnessesCatalogAsync(CatalogToughnessesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a Planeswalker’s loyalty in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetLoyaltiesCatalogAsync(CatalogLoyaltiesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all keyword abilities in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetKeywordAbilitiesCatalogAsync(CatalogKeywordAbilitiesRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all keyword actions in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetKeywordActionsCatalogAsync(CatalogKeywordActionsRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all ability words in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetAbilityWordsCatalogAsync(CatalogAbilityWordsRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all flavor words in Scryfall’s database.
        /// </summary>
        public async Task<Catalog> GetFlavorWordsCatalogAsync(CatalogFlavorWordsRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all card watermarks in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetWatermarksCatalogAsync(CatalogWatermarksRequest request)
            => await executeRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a List object of all Sets on Scryfall.
        /// </summary>
        public async Task<ObjectList<Set>> GetSetsAsync(SetsRequest request)
            => await executeRequestAsync<ObjectList<Set>>(request);

        /// <summary>
        /// Returns a Set with the given set code.
        /// The code can be either the code or the mtgo_code for the set.
        /// </summary>
        public async Task<Set> GetSetByCodeAsync(SetByCodeRequest request)
            => await executeRequestAsync<Set>(request);

        /// <summary>
        /// Returns a Set with the given Scryfall id.
        /// </summary>
        public async Task<Set> GetSetByIdAsync(SetByIdRequest request)
            => await executeRequestAsync<Set>(request);

        /// <summary>
        /// Returns a Set with the given tcgplayer_id, also known as the groupId on TCGplayer’s API.
        /// </summary>
        public async Task<Set> GetSetByTcgPlayerIdAsync(SetByTcgPlayerIdRequest request)
            => await executeRequestAsync<Set>(request);

        /// <summary>
        /// Returns a List of all Card Symbols.
        /// </summary>
        public async Task<ObjectList<CardSymbol>> GetSymbologyAsync(SymbologyRequest request)
            => await executeRequestAsync<ObjectList<CardSymbol>>(request);

        /// <summary>
        /// Returns a List of all Bulk Data items on Scryfall.
        /// </summary>
        public async Task<ObjectList<BulkData>> GetBulkDataAsync(BulkDataRequest request)
            => await executeRequestAsync<ObjectList<BulkData>>(request);

        /// <summary>
        /// Returns a single Bulk Data object with the given id.
        /// </summary>
        public async Task<BulkData> GetBulkDataByIdAsync(BulkDataByIdRequest request)
            => await executeRequestAsync<BulkData>(request);

        /// <summary>
        /// Returns a single Bulk Data object with the given type.
        /// </summary>
        public async Task<BulkData> GetBulkDataByTypeAsync(BulkDataByTypeRequest request)
            => await executeRequestAsync<BulkData>(request);

        /// <summary>
        /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
        /// <br/><br/>
        /// The server understands most community shorthand for mana costs (such as 2WW for {2}{W}{W}).
        /// Symbols can also be out of order, lowercase, or have multiple colorless costs (such as 2{g}2 for {4}{G}).
        /// <br/><br/>
        /// If part of the string could not be understood, the server will return an Error object describing the problem.
        /// </summary>
        public async Task<ManaCost> GetParsedManaCostsAsync(ParseManaRequest request)
            => await executeRequestAsync<ManaCost>(request);

        private async Task<T> executeRequestAsync<T>(IRequest request)
        {
            var response = request.Method switch
            {
                "GET" => await httpClient.GetAsync(uriFactory.Create(request)),
                "POST" => await httpClient.PostAsync(uriFactory.Create(request), new StringContent(bodyFactory.Create(request))),
                _ => throw new InvalidOperationException()
            };
            
            response.EnsureSuccessStatusCode();
            
            var result = await response.Content.ReadFromJsonAsync<T>(getJsonSerializerOptions());
            return result ?? throw new InvalidOperationException();
        }

        private JsonSerializerOptions getJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                Converters =
                {
                    new ScryfallObjectTypeJsonConverter(),
                    new ScryfallImageVersionJsonConverter()
                }
            };
        }
        
        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}