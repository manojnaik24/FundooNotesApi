using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class NoteBussiness : INoteBussiness
    {
        private readonly INoteRepo noteRepo;

        public NoteBussiness(INoteRepo noteRepo)
        {
            this.noteRepo = noteRepo;
        }
        public NoteEntity noteInput(NoteModel model, int Id)
        {
            return noteRepo.noteInput(model, Id);
        }
        public List<NoteEntity> PrintAllDetail()
        {
            return noteRepo.PrintAllDetail();
        }
        public bool Upadate(int NoteId, int Id, NoteModel note)
        {
            return noteRepo.Upadate(NoteId, Id, note);
        }
        public bool delete(int NoteId, int Id)
        {
            return noteRepo.delete(NoteId, Id);
        }
        public bool isPin(int NoteId,int Id)
        {
            return noteRepo.isPin(NoteId,Id);
        }


        public bool isArchieve(int NoteId, int Id)
        {
            return noteRepo.isArchieve(NoteId,Id);
        }
        public bool isTrash(int NoteId, int Id)
        {
            return noteRepo.isTrash(NoteId,Id);
        }

        public bool DeleteAll(int NoteId)
        {
            return noteRepo.DeleteAll(NoteId);
        }

        public NoteEntity Colour(int NoteId, string Colour)
        {
            return noteRepo.Colour(NoteId, Colour);
        }

        public NoteEntity Reminder(int NoteId, DateTime re,int id)
        {
            return noteRepo.Reminder(NoteId, re,id);
        }

        public string uploadImage(int noteId, int id, IFormFile file)
        {
            return noteRepo.uploadImage(noteId, id, file);
        }
    }
}
