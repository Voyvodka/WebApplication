﻿using System;
using System.Collections.Generic;
using System.Text;
using webapplication.core.Entity.Abstract;

namespace webapplication.core.Entity.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }


    }
}
