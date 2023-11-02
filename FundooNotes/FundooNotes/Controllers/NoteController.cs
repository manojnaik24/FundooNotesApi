using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
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
        private readonly ILogger<NoteController> logger;
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

        [HttpPut]
        [Route("Update")]

        public IActionResult Updates(int noteid, NoteModel model) {

            int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var input = noteBussines.Upadate(noteid,userid, model);
            if (input!=null)
            {
                return Ok(new ResponseModel<string> { status = true, message = "data is update " });

            }
            else
            {
                return BadRequest(new ResponseModel<string> { status = false, message = "update Faild " });

            }
        }
        [HttpDelete]
        [Route("Deleting")]

        public IActionResult Delete(int noteid)
        {
            int result = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var delete=noteBussines.delete(noteid,result);
            if (delete != null)
            {
                return Ok(new ResponseModel<string> { status = true, message = "data deleted " });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { status = false, message = "data is not deleted " });
            }
        }
    }
}
