using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepo
    {
        public UserEntity UserRegisteration(RegisterModel model);

        public string UserLogin(LoginModel login);

        public bool IsEmailExisting(string email);

        public UserEntity EmailEmailExicting(string Email);

        public List<UserEntity> PrintAllDetail();

        public string ForgetPassword(string Email);

        public bool ResetPassword(string Email, resetPassword reset);

       public UserTicket CreateTick(string Email, String token);

        public List<UserEntity> userdetails(int id);

        public bool UpadteUserdetail(int id, RegisterModel model);


    }
}