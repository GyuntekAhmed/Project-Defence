﻿namespace Vehicle2Go.Services.Data.Interfaces
{
    using Web.ViewModels.Category;
    using Web.ViewModels.Home;

    public interface IYachtService
    {
        Task<IEnumerable<IndexViewModel>> AllCarsAsync();
        Task<IEnumerable<VehicleSelectCategoryViewModel>> AllCategoriesAsync();
    }
}
