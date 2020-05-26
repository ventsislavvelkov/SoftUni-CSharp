using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Text;

using static P01_HospitalDatabase.Data.DataValidations.Diagnose;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        [MaxLength(NameMaxLength)]
        public  string Name { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; }

        public ICollection<Patient> Patient { get; set; }
    
    }
}
