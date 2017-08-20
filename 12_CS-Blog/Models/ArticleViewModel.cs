using System.ComponentModel.DataAnnotations;

namespace _12_CS_Blog.Models
{
	public class ArticleViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(250)]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		public string AuthorId { get; set; }
	}
}