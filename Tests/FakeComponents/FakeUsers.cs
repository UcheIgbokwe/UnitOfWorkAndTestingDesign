using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Tests.FakeComponents
{
    public static class FakeUsers
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            for (int i=1; i <10; i++)
            {
                var user = new User()
                {
                    Name = "FirstName" + i,
                    Email = "FirstName" + i + "@gmail.com"
                };
                users.Add(user);
            }
            return users;
        }
    }
}