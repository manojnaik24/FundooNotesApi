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
        public NoteController(INoteBussiness noteBussines, ILogger<NoteController> logger)
        {
            this.noteBussines = noteBussines;
            this.logger = logger;
        }
        [Authorize]
        [HttpPost]
        [Route("Add Note")]
        public IActionResult addNote(NoteModel model) 
        {
            logger.LogInformation("Note is add");
            int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var result = noteBussines.noteInput(model, userid);

                if (result != null)
                {
                logger.LogInformation("Note is add successfull");
                    return Ok(new ResponseModel<NoteEntity> { status = true, message = "Note Add SuccessFull",data=result });
                }
                else
                {
                logger.LogError("failed to add note");
                    return BadRequest(new ResponseModel<NoteEntity> { status = false, message = " Faild to add note" });
                }

        }
        [HttpGet]
        [Route("Print all the Note")]
        public IActionResult Print()
        {
            logger.LogInformation("Print all the note");
            List<NoteEntity> result = noteBussines.PrintAllDetail();

            if (result != null)
            {
                logger.LogInformation("all deatil");
                return Ok(new ResponseModel<List<NoteEntity>> { status = true, message = "All detail", data = result });
            }
            else
            {
                logger.LogError("not detail");
                return BadRequest(new ResponseModel<List<NoteEntity>> { status = false, message = "not detail" });
            }
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Updates(int noteid, NoteModel model) {

            logger.LogInformation("update");
            int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var input = noteBussines.Upadate(noteid,userid, model);
            if (input!=null)
            {
                logger.LogInformation("data is update");
                return Ok(new ResponseModel<string> { status = true, message = "data is update " });

            }
            else
            {
                logger.LogError("update faild");
                return BadRequest(new ResponseModel<string> { status = false, message = "update Faild " });

            }
        }
        [HttpDelete]
        [Route("Deleting")]

        public IActionResult Delete(int noteid)
        {
            logger.LogInformation("deleting");
            int result = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var delete=noteBussines.delete(noteid,result);
            if (delete != null)
            {
                logger.LogInformation("delet the note");
                return Ok(new ResponseModel<string> { status = true, message = "data deleted " });
            }
            else
            {
                logger.LogError("data is not deleted");
                return BadRequest(new ResponseModel<string> { status = false, message = "data is not deleted " });
            }
        }
        [HttpPost]
        [Route("Ispin")]
        public IActionResult IsPin(int noteid) {

            logger.LogInformation("Ispin started");
            int result=Convert.ToInt32(User.Claims.FirstOrDefault(x=>x.Type == "Id").Value);
            var ispin = noteBussines.isPin(noteid,result);
            if (ispin != null)
            {
                logger.LogInformation("ispin");
                return Ok(new ResponseModel<string> { status = true, message = "Ispin is done " });
            }
            else
            {
                logger.LogError("ispin error");
                return BadRequest(new ResponseModel<string> { status = false, message = "Pin is undone " });
            }
        }

        [HttpPost]
        [Route("IsArchieve")]
        public IActionResult IsArchieve(int noteid)
        {

            logger.LogInformation("Ispin started");
            int result = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var IsArch = noteBussines.isPin(noteid, result);
            if (IsArch != null)
            {
                logger.LogInformation("IsArchieve");
                return Ok(new ResponseModel<string> { status = true, message = "IsArchieve is done " });
            }
            else
            {
                logger.LogError("IsArchieve error");
                return BadRequest(new ResponseModel<string> { status = false, message = "IsArchieve is undone " });
            }
        }
        [HttpPost]
        [Route("IsTrashs")]
        public IActionResult IsTrashs(int noteid)
        {

            logger.LogInformation("IsTrashs started");
            int result = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            var IsTrash = noteBussines.isPin(noteid, result);
            if (IsTrash != null)
            {
                logger.LogInformation("IsTrashs");
                return Ok(new ResponseModel<string> { status = true, message = "IsTrashs is done " });
            }
            else
            {
                logger.LogError("IsTrashs error");
                return BadRequest(new ResponseModel<string> { status = false, message = "IsTrashs is undone " });
            }
        }

    }
}
