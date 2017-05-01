using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrossOver.DataAccessLayer.DBModel
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
