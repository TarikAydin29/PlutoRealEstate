namespace RealEstate.UI.Areas.AdminArea.Models.PropertyStatusVMs
{
    public class CreatePropertyStatusVM
    {
        public string Status { get; set; }
        public bool IsActive => true;
    }
}
