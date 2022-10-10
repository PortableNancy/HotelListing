using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Double Ratings { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
