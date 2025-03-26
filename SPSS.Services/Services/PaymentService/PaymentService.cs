using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.PaymentService
{
    public class PaymentService(IUnitOfWork _unitOfWork, ILogger<PaymentService> _logger) : IPaymentService
    {
        public async Task AddPaymentAsync(Payment payment)
        {
            try
            {
                _logger.LogInformation("Adding a new payment: {PaymentId}", payment.Id);
                await _unitOfWork.Payments.AddPaymentAsync(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding payment: {PaymentId}", payment.Id);
                throw;
            }
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all paymments.");
                return await _unitOfWork.Payments.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all payments.");
                throw new Exception("An error occurred while retrieving payments.", ex);
            }
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching payments with ID {Id}", id);
                var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(id);

                if (payment == null)
                {
                    _logger.LogWarning("Payments with ID {Id} not found.", id);
                    throw new KeyNotFoundException($"Payment with ID {id} not found.");
                }

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching payment with ID {Id}", id);
                throw;
            }
        }

        public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Fetching payment for Order ID {OrderId}", orderId);
                var payment = await _unitOfWork.Payments.GetPaymentByOrderIdAsync(orderId);

                if (payment == null)
                {
                    _logger.LogWarning("Payment with Order ID {OrderId} not found.", orderId);
                    return null;
                }

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payment for Order ID {OrderId}", orderId);
                throw;
            }
        }

        public async Task UpdatePaymentAsync(int id, Payment p)
        {
            try
            {
                _logger.LogInformation("Updating payment ID {paymentID}", p.Id );
                var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(id);
                if (payment == null)
                {
                    _logger.LogWarning("Payment with ID {Id} not found.", id);
                    throw new KeyNotFoundException($"Payment with ID {id} not found.");
                }
                await _unitOfWork.Payments.UpdatePaymentAsync(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating payment ID {Id}", p.Id);
                throw;
            }
        }
    }
}
