﻿using ParkingUZ.Core.Common;
using ParkingUZ.Core.Enums;

namespace ParkingUZ.Core.Entities
{
    public class Payment : BaseEntity, IAuditedEntity
    {
        public decimal Amount { get; set; }
        public CardType CardType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
