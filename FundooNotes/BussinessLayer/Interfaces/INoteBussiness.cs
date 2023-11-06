using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface INoteBussiness
    {
        NoteEntity noteInput(NoteModel model, int Id);

        public List<NoteEntity> PrintAllDetail();
        public bool Upadate(int NoteId, int Id, NoteModel model);

        public bool delete(int NoteId, int Id);

        public bool isPin(int NoteId,int Id);

        public bool isArchieve(int NoteId, int Id);

        public bool isTrash(int NoteId, int Id);

        public bool DeleteAll(int NoteId);

        public NoteEntity Colour(int NoteId, string Colour);

        public NoteEntity Reminder(int NoteId, DateTime re);

        public string uploadImage(int noteId, int id, IFormFile file);

        public NoteEntity display(int noteId, int id);
    }
}