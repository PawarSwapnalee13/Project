using System.ComponentModel.DataAnnotations;

namespace Etour.Model
{
    public class Customer_Master
    {

        [Key]
        public int Cust_Id { get; set; }
        public string? Cust_Name { get; set; }
        public string? Cust_Details { get; set; }
        public ICollection<Booking_Header_Master>? Booking_Header_Master { get; set; }
    }
}
