using AutoMapper;
using ParkingUZ.Application.Models.QRCode;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.MappingProfiles
{
    public class QRCodeMapping : Profile
    {
        public QRCodeMapping()
        {
            CreateMap<CreateQRCodeModel, QRCode>();

            CreateMap<UpdateQRCodeModel, QRCode>().ReverseMap();

            CreateMap<QRCode, QRCodeResponceModel>();
        }
    }
}
