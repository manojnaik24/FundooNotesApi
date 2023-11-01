using BussinessLayer.Interfaces;
using CommonLayer.Models;
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
    }
}
