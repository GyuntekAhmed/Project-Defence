﻿namespace Vehicle2Go.Services.Data.Interfaces
{
    using Models.Vehicle;
    using Web.ViewModels.Vehicle;

    public interface IMotorcycleService
    {
        Task CreateAsync(VehicleFormModel formModel, string agentId);
        Task<AllVehiclesFilteredAndPagedServiceModel> AllAsync(AllVehiclesQueryModel queryModel);
        Task<IEnumerable<VehicleAllViewModel>> AllByAgentIdAsync(string agentId);
        Task<IEnumerable<VehicleAllViewModel>> AllByUserIdAsync(string userId);
    }
}
