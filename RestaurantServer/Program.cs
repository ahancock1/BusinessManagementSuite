﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantServer.Data;

namespace RestaurantServer
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new RestaurantDbContext())
            {

                User user = new User
                {
                    FirstName = "Adam",
                    LastName = "Hancock",
                    EmailAddress = "a.hancock@hotmail.co.uk",
                    Password = "password",
                    PhoneNumber = "07891599243",
                    Username = "ahancock1"
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
