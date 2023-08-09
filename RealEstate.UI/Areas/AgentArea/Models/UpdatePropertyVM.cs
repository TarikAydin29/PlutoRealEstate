using RealEstate.Entities.Entities;

namespace RealEstate.UI.Areas.AgentArea.Models
{
    public class UpdatePropertyVM
    {
        public UpdatePropertyVM()
        {
            this.Photos = new List<PropertyPhoto>();
        }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate => DateTime.Now;
        public Guid PropertyNo { get; set; }
        public string PropertyTitle { get; set; }
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
        public int BedroomCount { get; set; }
        public int BathCount { get; set; }
        public int BalconyCount { get; set; }
        public string Floor { get; set; }
        public decimal Dues { get; set; }
        public bool IsInSite { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string? ImageUrl { get; set; }
        public List<PropertyPhoto> Photos { get; set; }


        public Guid CategoryID { get; set; }
        public Guid AgentID { get; set; }
        public Guid PropertyStatusID { get; set; }
    }
}
