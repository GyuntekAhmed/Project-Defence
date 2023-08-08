﻿namespace Vehicle2Go.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using Web.ViewModels.User;
    using Services.Data.Interfaces;

    using static Common.GeneralApplicationConstants;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = this.memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await this.userService.AllUsersAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration
                        (TimeSpan.FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UsersCacheKey ,users, cacheOptions);
            }

            return View(users);
        }
    }
}
