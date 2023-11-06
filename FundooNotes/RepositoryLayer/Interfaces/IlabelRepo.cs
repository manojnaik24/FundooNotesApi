using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IlabelRepo
    {
        public LabelEntity Addlabel(string name, int noteId, int id);
        public List<LabelEntity> PrintAllDetail();
        public bool UpdateLabel(string label, int noteId, int Id);
        public bool deleteLabel(string label, int noteId, int Id);

        public List<LabelEntity> getlabel(int columnsid);
    }
}
