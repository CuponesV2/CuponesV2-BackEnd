using System.ComponentModel.DataAnnotations;

namespace Cupones.Dtos
{
    public class CouponHistoryDto
    {
     
        public int Id { get; set; }

    
        public int? CouponId { get; set; }

        public CouponDto? CouponDto { get; set; }

        public DateOnly? Change_date { get; set; }

   
        public string? Field_changed { get; set; }

  
        public string? Old_value { get; set; }

 
        public string? New_value { get; set; }

    }
}

