using System;
using System.Collections.Generic;
using System.Text;
using P04.BorderControl.Interfaces;

namespace P04.BorderControl.Models
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
