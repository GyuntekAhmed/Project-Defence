﻿namespace Vehicle2Go.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Vehicle;
    using static Common.NotificationMessagesConstants;

    public class CarController : BaseController
    {
        private readonly ICarService carService;
        private readonly IAgentService agentService;

        public CarController(ICarService carService, IAgentService agentService)
        {
            this.carService = carService;
            this.agentService = agentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isAgent = await agentService.AgentExistByUserIdAsync(this.GetUserId());

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You need become an agent to add new cars!";

                return RedirectToAction("Become", "Agent");
            }

            AddVehicleViewModel model = new AddVehicleViewModel()
            {
                Categories = await carService.AllCategoriesAsync()
            };

            return View(model);
        }
    }
}
