using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RefitApp.Models;
using RefitApp.Services.Abstract;

namespace RefitApp.Services.Concrete
{
    public class RestApiService
    {
        private readonly IRestApiService _restApiService;

        public RestApiService()
        {
            _restApiService = RestService.For<IRestApiService>("https://jsonplaceholder.typicode.com");
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var users = await _restApiService.FetchAll();

            return users;
        }
    }
}
