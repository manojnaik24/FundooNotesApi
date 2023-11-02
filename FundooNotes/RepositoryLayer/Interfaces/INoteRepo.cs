using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepo
    {
        public NoteEntity noteInput(NoteModel model, int Id);

        public List<NoteEntity> PrintAllDetail();

        public bool Upadate(int NoteId, int Id, NoteModel note);

        public bool delete(int NoteId, int Id);

    }
}