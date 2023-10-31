using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBussines : IUserBussines
    {
        private readonly IUserRepo userRepo;

        public UserBussines(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public UserEntity UserRegisteration(RegisterModel model)
        {
            return userRepo.UserRegisteration(model);
        }


        public string UserLogin(LoginModel login)
        {
            return userRepo.UserLogin(login);
        }

        public bool IsEmailExisting(string email)
        {
            return userRepo.IsEmailExisting(email);
        }

        public List<UserEntity> PrintAllDetail()
        {
            return userRepo.PrintAllDetail(); 
        }

        public UserEntity EmailEmailExicting(string Email)
        {
            return userRepo.EmailEmailExicting(Email);
        }
        public string ForgetPassword(string Email)
        {
            return userRepo.ForgetPassword(Email);
        }

        public bool ResetPassword(string Email, resetPassword reset)
        {
            return userRepo.ResetPassword(Email, reset);
        }


    }
}
