namespace RealEstate.UI.Areas.AdminArea.Models.TestimonialVMs
{
    public class CreateTestimonialVM
    {
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public bool IsActive => true;
    }
}
