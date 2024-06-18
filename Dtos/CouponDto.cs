
namespace Cupones.Dtos
{
    public class CouponDto
    {
                
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public DateOnly Start_date { get; set; }

        
        public DateOnly End_date { get; set; }

        
        public string Discount_type { get; set; }
        
        public int Discount_value { get; set; }

        
        public int Usage_limit { get; set; }

        
        public int Min_purchase_amount { get; set; }

        
        public int Max_purchase_amount { get; set; }

        
        public string Status { get; set; }

        
        public int Created_By { get; set; }


        public string Code { get; set; }

        public int CampaignId { get; set; }

    }
}