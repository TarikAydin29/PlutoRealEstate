using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RealEstate.UI.Areas.AgentArea.Models
{
    public class ListPropertyVM
    {
        public Guid Id { get; set; }

        [Display(Name = "İlan Eklenme Tarihi")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "En Son Güncellenme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = "İlan Başlığı")]
        public string PropertyTitle { get; set; }
        [Display(Name = "İlan Fiyatı")]
        public decimal Price { get; set; }       
        [Display(Name = "İl")]
        public string City { get; set; }
        [Display(Name = "İlçe")]
        public string County { get; set; }
        [Display(Name = "Mahalle")]
        public string District { get; set; }
        [Display(Name = "İlan Resmi")]
        public string ImageUrl { get; set; }


        public Guid CategoryID { get; set; }
        public Guid AgentID { get; set; }
        public Guid PropertyStatusID { get; set; }
    }
}
