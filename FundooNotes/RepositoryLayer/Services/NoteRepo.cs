using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRepo : INoteRepo
    {
        private readonly FundoDbContext fundooContext;

        public NoteRepo(FundoDbContext fundooContext)
        {
           this.fundooContext = fundooContext;
        }

        public NoteEntity noteInput(NoteModel model,int Id)
        {

        NoteEntity entity = new NoteEntity();
            
            entity.Title = model.Title;
            entity.Note = model.Note;
            entity.UpdatedAt = model.UpdateAt;
            entity.CreatedAt = model.CreatedAt;
            entity.Color = model.Color;
            entity.Image = model.Image;
            entity.IsArchieve = model.IsArchieve;
            entity.IsPin = model.IsPin;
            entity.IsTrash = model.IsTrash;
            entity.Reminder= model.Reminder;
            entity.Id = Id; 
           fundooContext.Note.Add(entity);
           
                var result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return entity;
                }
                else
                {
                    return null;
                }
            
            
        }
        public List<NoteEntity> PrintAllDetail()
        {
            List<NoteEntity> result = (List<NoteEntity>)fundooContext.Note.ToList();
            return result;
        }

        public bool Upadate(int NoteId,int Id,NoteModel note)
        {
            var result=fundooContext.Note.FirstOrDefault(x=>x.NoteId == NoteId && x.Id==Id);

            if (result != null)
            {
                if (note.Title != null)
                {
                    result.Title = note.Title;
                }
                if (note != null)
                {
                  result.Note = note.Note;
                }
                if (note.Color != null)
                {
                    result.Color = note.Color;
                }
                if (note.Image != null)
                {
                    result.Image = note.Image;
                }
               
                result.Modifieder=DateTime.Now;
                fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool delete(int NoteId,int Id) { 

            var result=fundooContext.Note.FirstOrDefault(x=>x.NoteId==NoteId && x.Id==Id);
            if (result != null)
            {
                fundooContext.Note.Remove(result);
                fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isPin(int NoteId,int Id) { 
         
            var result=fundooContext.Note.FirstOrDefault(y=>y.NoteId==NoteId);
            if(result != null)
            {
                if (result.IsPin == true)
                {
                    result.IsPin = false;
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    result.IsPin = true;
                    fundooContext.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool isArchieve(int NoteId, int Id)
        {

            var result = fundooContext.Note.FirstOrDefault(y => y.NoteId == NoteId);
            if (result != null)
            {
                if (result.IsArchieve == true)
                {
                    result.IsArchieve = false;
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    result.IsArchieve = true;
                    fundooContext.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool isTrash(int NoteId, int Id)
        {

            var result = fundooContext.Note.FirstOrDefault(y => y.NoteId == NoteId);
            if (result != null)
            {
                if (result.IsTrash == true)
                {
                    result.IsTrash = false;
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    result.IsTrash = true;
                    fundooContext.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
