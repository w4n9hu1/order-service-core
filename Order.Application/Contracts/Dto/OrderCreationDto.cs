using System.ComponentModel.DataAnnotations;
using Order.Domain.Order;

namespace Order.Application.Contracts.Dto
{
    /**
     * A DTO is a simple object that is used to transfer state (data) between the Application and Presentation Layers.
       So, Application Service methods gets and returns DTOs.
     */
    public class OrderCreationDto
    {
        [Required]
        [StringLength(20)]
        public string OrderCode { get; set; } = string.Empty;

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [Range(0, 99999)]
        public int CreatedBy { get; set; }
    }
}
