using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Models
{
    public class PointsModel
    {
        [Required]
        [StringLength(20, MinimumLength =4)]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Joined")]
        public DateTime JoinDate { get; set; }


        [DisplayName("Points")]
        public int Points { get; set; }
    }
}
