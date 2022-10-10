using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTO
{
    public class CreateHotelDTO
    {
       
        [Required]
        [StringLength(maximumLength:150, ErrorMessage = "Hotel name too long")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public double Ratings { get; set; }
        [Required]
        public int CountryId { get; set; }
     
    }
    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public CreateCountryDTO Country { get; set; }
    }
}
