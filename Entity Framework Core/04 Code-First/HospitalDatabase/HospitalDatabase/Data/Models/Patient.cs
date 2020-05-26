using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using  static  P01_HospitalDatabase.Data.DataValidations.Patient;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }
    }
}
