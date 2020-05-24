using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public static class DataValidations
    {
        public static class Patient
        {
            public const int NameMaxLength = 50;
            public const int AddressMaxLength = 250;
            public const int EmailMaxLength = 80;
        }

        public static class Visitation
        {
            public const int CommentsMaxLength = 250;
        }

        public  static class Diagnose
        {
            public const int NameMaxLength = 50;

            public const int CommentsMaxLength = 250;
        }
        public  static class Medicament
        {
            public  const int NameMaxLength = 50;
        }
    }
}
