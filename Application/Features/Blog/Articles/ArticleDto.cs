using Autenticul.Gaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Application.Features.Blog.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }           // Titlul articolului
        public string Description { get; set; }     // Meta description
        public string Content { get; set; }         // Continut complet
        public string Author { get; set; }          // Nume autor
        public string ImagePath { get; set; }       // Imagine asociata

        // Campuri SEO suplimentare
        public string[] Tags { get; set; } = Array.Empty<string>();  // Cuvinte cheie
        public string Slug { get; set; } = "";                        // URL-friendly identifier
        public string Summary { get; set; } = "";                    // Rezumat scurt
        public Guid CategoryId { get; set; } = Guid.Empty;                 // Categoria (ex: "mama-si-bebe")

        public ArticleDto()
        {
             
        }

        public ArticleDto(Guid id, string title, string description, string content, string author, string imagePath, string[] tags, string slug, string summary, Guid categoryId)
        {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            Author = author;
            ImagePath = imagePath;
            Tags = tags;
            Slug = slug;
            Summary = summary;
            CategoryId = categoryId;
        }
    }
}
