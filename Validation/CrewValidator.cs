using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Models;

namespace Airhub.Validator
{
    public class CrewValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var plane = (Plane) validationContext.ObjectInstance;


            if (plane.Seats == 0)
            {
                return new ValidationResult("Seats number is required.");
            }

            //var isCrewNumberValid = ((int) value) > (plane.Seats / 50);
            var isCrewNumberValid = validateRequiredCrewNumber((int) value, plane.Seats);

            return (isCrewNumberValid)
                ? ValidationResult.Success
                : new ValidationResult("Crew number should be at least 5 times smaller than seats number.");
        }

        public Boolean validateRequiredCrewNumber(int CrewNumber, int Seats)
        {
            return CrewNumber > (Seats / 50);
        }
    }
}
