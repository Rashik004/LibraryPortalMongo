using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Web.UI;
using CrossOver.DataLayer.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace CrossOver.DataAccessLayer.DBModel
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
