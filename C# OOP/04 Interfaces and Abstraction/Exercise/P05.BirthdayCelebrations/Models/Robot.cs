using System;
using System.Collections.Generic;
using System.Text;
using P05.BirthdayCelebrations.Interfaces;

namespace P05.BirthdayCelebrations.Models
{
    public class Robot : IIdentable
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; private set; }
    }
}
