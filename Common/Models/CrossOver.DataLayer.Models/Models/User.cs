using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CompanyName.DataLayer.Models.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ObjectId[] Books { get; set; }

    }

}
