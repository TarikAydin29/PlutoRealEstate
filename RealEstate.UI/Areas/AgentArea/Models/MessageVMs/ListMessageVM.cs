using RealEstate.Entities.Entities;

namespace RealEstate.UI.Areas.AgentArea.Models.MessageVMs
{
    public class ListMessageVM
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
        public Guid AgentId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMessage { get; set; }

        public Property Property { get; set; }
    }
}
