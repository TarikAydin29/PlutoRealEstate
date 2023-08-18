namespace RealEstate.UI.Areas.CustomerArea.Models.MessagesVMs
{
    public class CreateMessageVM
    {
        public bool IsActive => true;
        public DateTime? CreatedDate => DateTime.Now;
        public Guid PropertyId { get; set; }
        public string UserMessage { get; set; }
    }
}
