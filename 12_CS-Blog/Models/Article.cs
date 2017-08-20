﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_CS_Blog.Models
{
	public class Article
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(250)]
		public string Title { get; set; }

		public string Content { get; set; }

		[ForeignKey("Author")]
		public string AuthorId { get; set; }

		public virtual ApplicationUser Author { get; set; }

		public bool IsAuthor(string name)
		{
			return this.Author.UserName.Equals(name);
		}
	}
}