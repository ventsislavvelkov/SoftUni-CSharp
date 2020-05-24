using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using  static P01_HospitalDatabase.Data.DataValidations.Medicament;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public int MedicamentId { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

    }
}
