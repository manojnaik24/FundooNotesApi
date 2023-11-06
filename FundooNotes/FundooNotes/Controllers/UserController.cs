using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBussines userBuissnes;
        private readonly ILogger<UserController> logger;
        public UserController(IUserBussines userBuissnes,ILogger<UserController> logger)
        {
            this.userBuissnes = userBuissnes;
            this.logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Registration(RegisterModel model)
        {
            logger.LogInformation("Registration started");
            var IsEmailExists = userBuissnes.IsEmailExisting(model.Email);
            if (IsEmailExists)
            {
                return Ok(new ResponseModel<string> { status = true, message = "Email Already exists", data = model.Email });
            }
            else
            {
                var result = userBuissnes.UserRegisteration(model);
                if (result != null)
                {
                    logger.LogInformation("Registration is done Successfull.");

                    return Ok(new ResponseModel<UserEntity> { status = true, message = "Registration successfull", data = result });
                }
                else
                {
                    logger.LogError("Registration is faild.");

                    return BadRequest(new ResponseModel<UserEntity> { status = false, message = "registraion failed" });
                }
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel login)
        {
            logger.LogInformation("Login started");
            var result = userBuissnes.UserLogin(login);
            if (result !=null)
            {
                logger.LogInformation("Login SuccessFull");

                return Ok( new ResponseModel<string> { status=true,message="Login SuccessFull",data=result});
            }
            else
            {
                logger.LogError("Login Faild");
                return BadRequest(new ResponseModel<string> { status = false, message = "Login Faild" });
            }
        }
        [HttpGet]
        [Route("UserInfo")]

        public IActionResult  GetUserData(){
            logger.LogInformation("User Info");
            List<UserEntity> result = userBuissnes.PrintAllDetail();

            if (result != null)
            {
                logger.LogInformation("User detail");
                return Ok(new ResponseModel<List<UserEntity>> {status=true,message="user details",data=result});  
            }
            else
            {
                logger.LogError("No detail");
                return BadRequest(new ResponseModel<List<UserEntity>> { status = false, message = "no details" });
            }
        }

        [HttpPost]
        [Route("ForgetPassword")]

        public IActionResult ForGetPassword(string Email) {
            logger.LogInformation("Forget password");
            var result = userBuissnes.ForgetPassword(Email);

            if (result != null)
            {
                logger.LogInformation("Message sent");
                return Ok(new ResponseModel<string> { status = true, message = "Message sent", data = result });
            }
            else
            {
                logger.LogError("Message sent failed");
                return BadRequest(new ResponseModel<string> { status = false, message = "Message sent Failed " });
            }

        }
        [Authorize]
        [HttpPut]
        [Route("Reset Password")]

        public IActionResult ResetPassword(resetPassword reset)
        {
            logger.LogInformation("Reset password");
            string email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            var result = userBuissnes.ResetPassword(email,reset);

            if (result != null)
            {
                logger.LogInformation("Password is Reset");
                return Ok(new ResponseModel<string> { status = true, message = "Password is Reset "});
            }
            else
            {
                logger.LogError("Password is not Reset");
                return BadRequest(new ResponseModel<string> { status = false, message = "Password is not Reset " });
            }

        }
        [HttpGet]
        [Route("User Detail")]

        public IActionResult Detail(int id)
        {
            logger.LogInformation("User Info");
            List<UserEntity> result = userBuissnes.userdetails(id);

            if (result != null)
            {
                logger.LogInformation("User detail");
                return Ok(new ResponseModel<List<UserEntity>> { status = true, message = "user details", data = result });
            }
            else
            {
                logger.LogError("No detail");
                return BadRequest(new ResponseModel<List<UserEntity>> { status = false, message = "no details" });
            }
        }
        [HttpPut]
        [Route("Updated Detail")]

        public IActionResult update( int id,RegisterModel model)
        {
            logger.LogInformation("Updated Detail");

            var result = userBuissnes.UpadteUserdetail(id,model);

            if (result != null)
            {
                logger.LogInformation("Update.....");
                return Ok(new ResponseModel<string> { status = true, message = "user Updated successfull" });
            }
            else
            {
                logger.LogError("not update");
                return BadRequest(new ResponseModel<string> { status = false, message = "data is not updated" });
            }
        }
    }

   
}