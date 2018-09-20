using NewsDemo.Interfaces;
using NewsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NewsDemo.Data
{
    public class HackerNewsProvider: INewsProvider
    {
        private const string _baseUrl = "https://hacker-news.firebaseio.com/v0/";
        private static readonly HttpClient _client;

        static HackerNewsProvider()
        {
            _client = new HttpClient();
        }

        public async Task<NewsDto> GetNewsByIdAsync(int id)
        {
            var streamTask = _client.GetStreamAsync(_baseUrl + "item/"+id+".json?print=pretty");

            var serializer = new DataContractJsonSerializer(typeof(NewsDto));

            var result = serializer.ReadObject(await streamTask) as NewsDto;

            return result;
        }
        public async Task<List<NewsListItemDto>> List()
        {
            var newsList = new List<NewsListItemDto>();

            List<Task<NewsDto>> tasks = new List<Task<NewsDto>>();

            List<int> idList = await GetHackerNewsListIds();

            foreach (int id in idList)
            {
                tasks.Add(GetNewsByIdAsync(id));
            }

            var newsItems = await Task.WhenAll(tasks);

            foreach (var newsDto in newsItems)
            {
                newsList.Add(new NewsListItemDto
                {
                    Id = newsDto.Id,
                    Title = newsDto.Title,
                    By = newsDto.By,
                    Type = newsDto.Type,
                    Url = newsDto.Url
                });
            }
            return newsList;

        }
        public int GetMaxItemId()
        {
            //Not implemented
            //This method can be used to retrieve the Max Item ID from HackerNews
            //https://hacker-news.firebaseio.com/v0/maxitem.json?print=pretty
            //which in turn can be used to retrieve a specific valid range of news items
            var result = 100;

            return result;

        }

        private async Task<List<int>> GetHackerNewsListIds()
        {
            var stringTask = _client.GetStreamAsync(_baseUrl + "topstories.json?print=pretty");

            var serializer = new DataContractJsonSerializer(typeof(List<int>));

            var result = serializer.ReadObject(await stringTask) as List<int>;
            return result;
        }        
    }
}
