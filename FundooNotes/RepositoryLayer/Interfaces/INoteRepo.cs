using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepo
    {
        public NoteEntity noteInput(NoteModel model, int Id);

        public List<NoteEntity> PrintAllDetail();

    }
}