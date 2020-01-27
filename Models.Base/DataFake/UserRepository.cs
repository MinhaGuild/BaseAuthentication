using Model.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Base.DataFake
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin", Role = "manager", Actived = true });
            users.Add(new User { Id = 2, Username = "empregado", Password = "empregado", Role = "employee", Actived = true });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
