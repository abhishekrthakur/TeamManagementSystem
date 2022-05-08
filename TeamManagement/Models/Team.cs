using System.ComponentModel.DataAnnotations;
namespace TeamManagement.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? TeamName { get; set; }
        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string? ManagerName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int ProjectDone { get; set; }
       

        public int MemberId { get; set; }
        public int RoleId { get; set; }
    }
}
