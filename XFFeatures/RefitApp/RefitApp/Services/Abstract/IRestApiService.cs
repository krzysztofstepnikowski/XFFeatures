using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RefitApp.Models;

namespace RefitApp.Services.Abstract
{
    public interface IRestApiService
    {
        [Get("/todos")]
        Task<List<UserResponse>> FetchAll();
    }
}