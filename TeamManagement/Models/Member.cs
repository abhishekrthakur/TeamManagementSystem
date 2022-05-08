using System.ComponentModel.DataAnnotations;
namespace TeamManagement.Models
{
	public class Member
	{
		public int MemberId { get; set; }
		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Gender { get; set; }
		public DateTime DOB { get; set; }
		[Required]
		public string? MaritalStatus { get; set; }
		[Required]
		public string? Address { get; set; }
		[Required]
		public long PhoneNo { get; set; }
		[Required]
		public string? Skills { get; set; }
		public string? Hobbies { get; set; }
		[Required]
		public string? JobTitle { get; set; }
		[Required]
		public string? Technology { get; set; }

		public int TeamId { get; set; }
	}
}
