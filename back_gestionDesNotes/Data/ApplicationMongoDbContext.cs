using back_gestionDesNotes.Models;
using MongoDB.Driver;

namespace back_gestionDesNotes.Data
{
    public class ApplicationMongoDbContext
    {
        private IMongoDatabase _database;
        public ApplicationMongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            if (client != null)
            {
                _database = client.GetDatabase(databaseName);
            }
        }
        public IMongoCollection<Note> Notes => _database.GetCollection<Note>("notes");
    }
}
