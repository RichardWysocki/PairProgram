﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace universalwindows.library.Models
{
    [DataContract]
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public PersonModel(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}
