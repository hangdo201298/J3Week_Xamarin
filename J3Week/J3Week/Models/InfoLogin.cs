﻿using System;
using System.Collections.Generic;
using System.Text;

namespace J3Week.Models
{
    class InfoLogin
    {
        public string Email { get; set; }
        public string Passwords { get; set; }

    }

    public class Datum
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
    }

    public class ResponseLogin
    {
        public int code { get; set; }
        public List<Datum> data { get; set; }
    }
}
