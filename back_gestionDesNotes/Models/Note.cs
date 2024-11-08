using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_gestionDesNotes.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int patId { get; set; }
        public string? patient { get; set; } = null!;
        public string? note { get; set; } = null!;
    }
}
