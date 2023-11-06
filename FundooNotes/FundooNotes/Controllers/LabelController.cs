using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly IlabelBussines ilabelBussines;
        private readonly ILogger<NoteController> logger;

        public LabelController(IlabelBussines ilabelBussines)
        {
            this.ilabelBussines = ilabelBussines;
        }

        [HttpPost]
        [Route("add Label")]

        public IActionResult lable(string label)
        {
            logger.LogInformation("label is started.....");
            var id = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "Id" && m.Type == "noteId"));
            // var noteid = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "noteId"));
            var lable = ilabelBussines.Addlabel(label, id);

            if (label != null)
            {
                logger.LogInformation("lable is add successfull");
                return Ok(new ResponseModel<LabelEntity> { status = true, message = "label Add SuccessFull" });
            }
            else
            {
                logger.LogError("failed to add lable");
                return BadRequest(new ResponseModel<LabelEntity> { status = false, message = " Faild to add label" });
            }
        }

        [HttpGet]
        [Route("Print all the label")]
        public IActionResult Printlabel()
        {
            logger.LogInformation("Print all the note");
            List<LabelEntity> result = ilabelBussines.PrintAllDetail();

            if (result != null)
            {
                logger.LogInformation("all labels are printing");
                return Ok(new ResponseModel<List<LabelEntity>> { status = true, message = "All label", data = result });
            }
            else
            {
                logger.LogError("label are not printed");
                return BadRequest(new ResponseModel<List<LabelEntity>> { status = false, message = "label are not printed" });
            }
        }

        [HttpPut]
        [Route("Update label")]

        public IActionResult Updatelabel(string label)
        {

            logger.LogInformation("update");
            var re = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "Id"));
            var noteid = Convert.ToInt32(Note.Claims.FirstOrDefault(m => m.Type == "noteId"));
            var lable = ilabelBussines.UpdateLabel(label, re, noteid);
            if (lable != null)
            {
                logger.LogInformation("label is update");
                return Ok(new ResponseModel<string> { status = true, message = "label is updated " });

            }
            else
            {
                logger.LogError("label update faild");
                return BadRequest(new ResponseModel<string> { status = false, message = " label update Faild " });

            }
        }
        [HttpDelete]
        [Route("Deleting label")]

        public IActionResult Delete(string label)
        {
            logger.LogInformation("deleting");
            int result = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id"));
            var noteid = Convert.ToInt32(Note.Claims.FirstOrDefault(m => m.Type == "noteId"));
            var delete = ilabelBussines.deleteLabel(label, result, noteid);
            if (delete != null)
            {
                logger.LogInformation("label the label");
                return Ok(new ResponseModel<string> { status = true, message = "label deleted " });
            }
            else
            {
                logger.LogError("label is not deleted");
                return BadRequest(new ResponseModel<string> { status = false, message = "label is not deleted " });
            }
        }
        [HttpGet]
        [Route("Print label")]
        public IActionResult Print(int noteId)
        {
            logger.LogInformation("Print label");
            int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Value == "Id"));
            var noteid = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "noteId"));
            LabelEntity mt = ilabelBussines.getlabel(noteId, noteid, id);

            if (mt != null)
            {
                logger.LogInformation("print label");
                return Ok(new ResponseModel<LabelEntity> { status = true, message = "label" });
            }
            else
            {
                logger.LogError("no label");
                return BadRequest(new ResponseModel<LabelEntity> { status = false, message = "no label" });
            }
        }
    }
    }
