using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsDemo.Models
{
    public class NewsListItemDto
    {
        public int Id { get; set; }
        public string By    { get; set; }
        public string Type  { get; set; }
        public string Title { get; set; }
        public string Url   { get; set; }
    }
}
