using CommonLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class labelRepo:IlabelRepo
    {
        public readonly FundoDbContext fundoDb;
         
        public labelRepo(FundoDbContext fundoDb)
        {
            this.fundoDb = fundoDb;
        }


        public LabelEntity Addlabel(int noteId, string labelName,int Id)
        {

            LabelEntity label = new LabelEntity();
            label.labelName=labelName;
            label.NoteId=noteId;
            label.Id = Id;
           
            fundoDb.Label.Add(label);
            var re = fundoDb.SaveChanges();

            if (re >0)
            {
                return label;
            }
            else
            {
                return null;
            }

            
        }

        public List<LabelEntity> PrintAllDetail()
        {
            List<LabelEntity> result = (List<LabelEntity>)fundoDb.Label.ToList();
            return result;
        }

        public bool UpdateLabel(int noteId, string label)
        {
            var result=fundoDb.Label.FirstOrDefault(v=> v.NoteId==noteId );
            if (result.labelName != null)
            {
                result.labelName=label;
                fundoDb.SaveChanges();
                return true;
            }
          
            return false;

        }
        public bool deleteLabel(int noteId, string label) {

            var result = fundoDb.Label.FirstOrDefault(v =>  v.NoteId == noteId && v.labelName==label);
            if (result != null) {
            fundoDb.Label.Remove(result);
                fundoDb.SaveChanges() ;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<LabelEntity> getlabel(string label)
        {
            List<LabelEntity> result = (List<LabelEntity>)fundoDb.Label.Where(m=>m.labelName==label );
            return result;
        }

    }
}
