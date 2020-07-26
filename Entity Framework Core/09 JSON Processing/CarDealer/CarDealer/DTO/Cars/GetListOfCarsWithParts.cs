using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CarDealer.DTO.Cars
{
   public class GetListOfCarsWithParts
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public GetListOfParts[] Parts { get; set; }

    }
}
