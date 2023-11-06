using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface IlabelBussines
    {
        LabelEntity Addlabel(string name, int noteId, int id);

        public List<LabelEntity> PrintAllDetail();
        public bool UpdateLabel(string label, int noteId, int Id);
        public bool deleteLabel(string label, int noteId, int Id);

        public List<LabelEntity> getlabel(int columnsid);
    }
}