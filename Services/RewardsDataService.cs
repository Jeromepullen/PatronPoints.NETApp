using PatronPointsRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Services
{
    interface RewardsDataService
    {
        List<RewardsModel> GetAllRewards();

        List<RewardsModel> SearchRewards(string searchTerm);

        RewardsModel GetUserById(int id);

        int Insert(RewardsModel rewards);
        int Delete(RewardsModel rewards);
        int Update(RewardsModel rewards);


    }
}
