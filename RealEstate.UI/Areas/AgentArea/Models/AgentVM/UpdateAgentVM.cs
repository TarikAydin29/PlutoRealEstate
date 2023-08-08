namespace RealEstate.UI.Areas.AgentArea.Models.AgentVM
{
    public class UpdateAgentVM
    {
        public Guid Id { get; set; }
        public DateTime? UpdatedDate => DateTime.Now;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }       

    }
}
