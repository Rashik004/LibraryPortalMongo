using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CompanyName.DataLayer.Models.Models
{
    [BsonIgnoreExtraElements]
    public class Book
    {

        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
        //public int Test { get; set; }
    }

}
