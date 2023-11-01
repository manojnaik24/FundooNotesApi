using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NoteController:ControllerBase
    {
        private readonly INoteBussiness noteBussines;

        public NoteController(INoteBussiness noteBussines)
        {
            this.noteBussines = noteBussines;
        }
        [Authorize]
        [HttpPost]
        [Route("Add Note")]
        public IActionResult addNote(NoteModel model) 
        {
            int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var result = noteBussines.noteInput(model, userid);

                if (result != null)
                {
                    return Ok(new ResponseModel<NoteEntity> { status = true, message = "Note Add SuccessFull",data=result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { status = false, message = " Faild" });
                }

        }
        [HttpGet]
        [Route("Print")]
        public IActionResult Print()
        {
            List<NoteEntity> result = noteBussines.PrintAllDetail();

            if (result != null)
            {
                return Ok(new ResponseModel<List<NoteEntity>> { status = true, message = "All deatil", data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<List<NoteEntity>> { status = false, message = "not extists" });
            }
        }
        

    }
}
