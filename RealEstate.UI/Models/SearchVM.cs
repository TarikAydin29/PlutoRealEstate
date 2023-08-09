namespace RealEstate.UI.Models
{
    public class SearchVM
    {
        public string sehir { get; set; }
        public string ilce { get; set; }
        public string mahalle { get; set; }
        public Guid category { get; set; }
        public Guid status { get; set; }
        public int roomNumber { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
    }
}
