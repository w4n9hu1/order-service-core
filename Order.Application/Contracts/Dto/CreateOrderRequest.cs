using Order.Domain.Order;
using System.ComponentModel.DataAnnotations;

namespace Order.Application.Contracts.Dto
{
    public class CreateOrderRequest
    {
        public string OrderCode { get; set; } = string.Empty;

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int CreatedBy { get; set; }
    }
}
