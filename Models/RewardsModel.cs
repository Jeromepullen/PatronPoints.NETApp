using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Models
{
    public class RewardsModel
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }
        [DisplayName("Customer Name")]
        public string Name { get; set; }
        [DisplayName("Rewards Amount")]
        public int Rewards { get; set; }
        [DisplayName("Rewards Type")]
        public string RewardsType { get; set; }
    }
}
