using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class CatalogEndpoints : BaseEndpoints
    {
        public CatalogEndpoints(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Returns a Catalog of all English card names in Scryfall’s database.
        /// Values are drawn from cards currently in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCardNamesAsync(CatalogCardNamesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all English words, of length 2 or more, that are shared between 10 or more card names.
        /// Values are drawn from cards currently in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetWordBankAsync(CatalogWordBankRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Magic card supertypes.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetSupertypesAsync(CatalogSupertypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Magic card types.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCardTypesAsync(CatalogCardTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all artifact types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetArtifactTypesAsync(CatalogArtifactTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Battle types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetBattleTypesAsync(CatalogBattleTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all creature types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetCreatureTypesAsync(CatalogCreatureTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all enchantment types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetEnchantmentTypesAsync(CatalogEnchantmentTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Land types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetLandTypesAsync(CatalogLandTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all Planeswalker types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetPlaneswalkerTypesAsync(CatalogPlaneswalkerTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all spell types in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetSpellTypesAsync(CatalogSpellTypesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s power in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetPowersAsync(CatalogPowersRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s toughness in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetToughnessesAsync(CatalogToughnessesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all possible values for a Planeswalker’s loyalty in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetLoyaltiesAsync(CatalogLoyaltiesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all keyword abilities in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetKeywordAbilitiesAsync(CatalogKeywordAbilitiesRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all keyword actions in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetKeywordActionsAsync(CatalogKeywordActionsRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all ability words in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetAbilityWordsAsync(CatalogAbilityWordsRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all flavor words in Scryfall’s database.
        /// </summary>
        public async Task<Catalog> GetFlavorWordsAsync(CatalogFlavorWordsRequest request)
            => await ExecuteRequestAsync<Catalog>(request);

        /// <summary>
        /// Returns a Catalog of all card watermarks in Scryfall’s database.
        /// Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        public async Task<Catalog> GetWatermarksAsync(CatalogWatermarksRequest request)
            => await ExecuteRequestAsync<Catalog>(request);
    }
}
