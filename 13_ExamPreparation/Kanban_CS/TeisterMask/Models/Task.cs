using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeisterMask.Models
{
    public class Task
    {
		[Key]
	    public int Id { get; set; }

		[Required]
		[AllowHtml]
		[MinLength(2), MaxLength(30)]
		public string Title { get; set; }

		[Required]
		[AllowHtml]
		[MinLength(4), MaxLength(15)]
		public string Status { get; set; }
	}
}