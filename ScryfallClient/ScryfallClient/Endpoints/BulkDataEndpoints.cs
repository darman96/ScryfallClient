using System.Net.Http;
using System.Threading.Tasks;
using ScryfallClient.Models;
using ScryfallClient.Requests;

namespace ScryfallClient.Endpoints
{
    public class BulkDataEndpoints : BaseEndpoints
    {
        public BulkDataEndpoints(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Returns a List of all Bulk Data items on Scryfall.
        /// </summary>
        public async Task<ObjectList<BulkData>> GetAsync(BulkDataRequest request)
            => await ExecuteRequestAsync<ObjectList<BulkData>>(request);

        /// <summary>
        /// Returns a single Bulk Data object with the given id.
        /// </summary>
        public async Task<BulkData> GetByIdAsync(BulkDataByIdRequest request)
            => await ExecuteRequestAsync<BulkData>(request);

        /// <summary>
        /// Returns a single Bulk Data object with the given type.
        /// </summary>
        public async Task<BulkData> GetByTypeAsync(BulkDataByTypeRequest request)
            => await ExecuteRequestAsync<BulkData>(request);
    }
}
