using NewsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsDemo.Interfaces
{
    public interface INewsProvider
    {
        Task<NewsDto> GetNewsByIdAsync(int id);
        Task<List<NewsListItemDto>> List();
        int GetMaxItemId();
    }
}
