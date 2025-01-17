﻿using back_gestionDesNotes.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace back_gestionDesNotes.Service
{
    public class NotesService
    {
        private readonly IMongoCollection<Note> _notesCollection;

        public NotesService(IOptions<NoteDatabaseSettings> noteDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                noteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                noteDatabaseSettings.Value.DatabaseName);

            _notesCollection = mongoDatabase.GetCollection<Note>(
                noteDatabaseSettings.Value.CollectionName);
        }
        public async Task<List<Note>> GetAsync() =>
        await _notesCollection.Find(_ => true).ToListAsync();

        public async Task<List<Note>> GetPatientAsync(int id) =>
            await _notesCollection.Find(p => p.patId == id).ToListAsync();

        public async Task<Note?> GetAsync(string id) =>
            await _notesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Note newNote) =>
            await _notesCollection.InsertOneAsync(newNote);

        public async Task UpdateAsync(string id, Note updatedNote) =>
            await _notesCollection.ReplaceOneAsync(x => x.Id == id, updatedNote);

        public async Task RemoveAsync(string id) =>
            await _notesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
