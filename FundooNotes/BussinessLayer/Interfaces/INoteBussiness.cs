using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface INoteBussiness
    {
        NoteEntity noteInput(NoteModel model, int Id);

        public List<NoteEntity> PrintAllDetail();
        public bool Upadate(int NoteId, int Id, NoteModel model);

        public bool delete(int NoteId, int Id);

    }
}