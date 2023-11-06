using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class labelBussines : IlabelBussines
    {
        public readonly IlabelRepo labelRepo;
        public labelBussines(IlabelRepo labelRepo)
        {
            this.labelRepo = labelRepo;
        }

        public LabelEntity Addlabel(string name, int noteId, int id)
        {
            return labelRepo.Addlabel(name, noteId, id);
        }
        public List<LabelEntity> PrintAllDetail()
        {
           return labelRepo.PrintAllDetail();
        }
        public bool UpdateLabel(string label, int noteId, int Id)
        {
            return labelRepo.UpdateLabel(label, noteId, Id);
        }
        public bool deleteLabel(string label, int noteId, int Id)
        {
            return labelRepo.deleteLabel(label, noteId, Id);
        }

        public List<LabelEntity> getlabel(int columnsid)
        {
            return labelRepo.getlabel(columnsid);
        }
    }
}
