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
        private readonly ILogger<LabelController> logger;

        public LabelController(IlabelBussines ilabelBussines,ILogger<LabelController> logger)
        {
            this.ilabelBussines = ilabelBussines;
            this.logger = logger;
        }

        [HttpPost]
        [Route("add Label")]

        public IActionResult lable(int noteId,string label)
        {
            logger.LogInformation("label is started.....");
            var id=Convert.ToInt32(User.Claims.FirstOrDefault(m=>m.Type=="Id").Value);
            var lable = ilabelBussines.Addlabel(noteId, label,id);

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

        public IActionResult Updatelabel(int noteid,string label)
        {

            logger.LogInformation("update");
            var lable = ilabelBussines.UpdateLabel(noteid,label);
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

        public IActionResult Delete(int note, string label)
        {
            logger.LogInformation("deleting");
            var delete = ilabelBussines.deleteLabel(note, label);
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
        public IActionResult getlables(string label )
        {
            logger.LogInformation("Print label");
           List< LabelEntity >mt = ilabelBussines.getlabel(label);

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
