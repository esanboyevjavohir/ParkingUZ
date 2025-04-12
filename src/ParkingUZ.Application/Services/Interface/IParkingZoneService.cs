using ParkingUZ.Application.Models;
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
        Task<ApiResult<ParkingZoneResponceModel>> GetByIdAsync(Guid id);
        Task<ApiResult<List<ParkingZoneResponceModel>>> GetAllAsync();
        Task<ApiResult<CreateParkingZoneResponceModel>> CreateAsync(CreateParkingZoneModel create);
        Task<ApiResult<UpdateParkingZoneResponceModel>> UpdateAsync(Guid id, UpdateParkingZoneModel update);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
