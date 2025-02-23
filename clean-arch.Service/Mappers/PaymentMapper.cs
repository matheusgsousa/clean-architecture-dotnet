using clean_arch.Domain.DTOs;
using clean_arch.Domain.Entities;
using clean_arch.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Service.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentDTO ToMapper(this Payment payment)
        {
            var dto = new PaymentDTO
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Date = payment.Date
            };

            return dto;
        }

        public static Payment ToMapper(this PaymentDTO dto)
        {
            var payment = new Payment
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Date = dto.Date
            };
            return payment;
        }
    }
}
