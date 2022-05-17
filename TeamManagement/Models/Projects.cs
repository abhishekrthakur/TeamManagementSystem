namespace TeamManagement.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectHead { get; set; }
        public string Status { get; set; }
        public string Technology { get; set; }
        
    }
}
