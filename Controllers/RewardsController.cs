using Microsoft.AspNetCore.Mvc;
using PatronPointsRewards.Models;
using PatronPointsRewards.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Controllers
{
    public class RewardsController : Controller
    {
        public IActionResult Index()
        {
            RewardsDAO rewards = new RewardsDAO();

            return View(rewards.GetAllRewards());
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult Create(RewardsModel reward)
        {
            RewardsDAO rewards = new RewardsDAO();
            rewards.Insert(reward);
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {
            RewardsDAO rewards = new RewardsDAO();
            List<RewardsModel> rewardsList = rewards.SearchRewards(searchTerm);
            return View("Index", rewardsList);
        }

        public IActionResult ShowDetails(int id)
        {
            RewardsDAO rewards = new RewardsDAO();
            RewardsModel foundReward = rewards.GetUserById(id);
            return View(foundReward);
        }

        public IActionResult Edit(int id)
        {
            RewardsDAO rewards = new RewardsDAO();
            RewardsModel foundReward = rewards.GetUserById(id);
            return View("ShowEdit", foundReward);
        }

        public IActionResult ProcessEdit(RewardsModel reward)
        {
            RewardsDAO rewards = new RewardsDAO();
            rewards.Update(reward);
            return View("Index", rewards.GetAllRewards());
        }

        public IActionResult Delete (int Id)
        {
            RewardsDAO rewards = new RewardsDAO();
            RewardsModel reward = rewards.GetUserById(Id);
            rewards.Delete(reward);
            return View("Index", rewards.GetAllRewards());
        }

        public IActionResult Message()
        {
            return View("message");
        }

        public IActionResult Welcome(string name, int secretNumber=13)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;
            return View();
        }
    }
}
