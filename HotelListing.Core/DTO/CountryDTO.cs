using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTO
{
    public class CreateCountryDTO
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Shortname i s too long")]
        public string ShortName { get; set; }
    }
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public virtual IList<HotelDTO> Hotel { get; set; }
    }

}
