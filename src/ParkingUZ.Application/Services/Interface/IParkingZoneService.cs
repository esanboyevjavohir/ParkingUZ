using ParkingUZ.Application.Models.ParkingZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingUZ.Application.Services.Interface
{
    public interface IParkingZoneService
    {
        Task<ParkingZoneResponceModel> GetByIdAsync(Guid id);
        Task<List<ParkingZoneResponceModel>> GetAllAsync();
        Task<CreateParkingZoneResponceModel> CreateAsync(CreateParkingZoneModel create,
            CancellationToken cancellationToken = default);
        Task<UpdateParkingZoneResponceModel> UpdateAsync(Guid id, UpdateParkingZoneModel update,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id);
    }
}
