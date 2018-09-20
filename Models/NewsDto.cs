using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NewsDemo.Models
{
    [DataContract()]
    public class NewsDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "by")]
        public string By { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "parent")]
        public int Parent { get; set; }
        [DataMember(Name = "kids")]
        public int [] Kids { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "descendants")]
        public int Descendants { get; set; }     

    }
}
