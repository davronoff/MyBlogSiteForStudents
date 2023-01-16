using Myblogsite.Models;

namespace MyBlogSite.AdminPanel.ViewModels
{
    public class PostEditViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Time { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
        public IFormFile NewImage { get; set; }

        public static explicit operator PostEditViewModel(Post v)
        {
            return new PostEditViewModel()
            {
                Id = v.Id,
                Title = v.Title,
                Time = v.Time,
                Comment = v.Comment,
                Image = v.Image,
            };
        }
        public static explicit operator Post(PostEditViewModel v)
        {
            return new Post()
            {
                Id = v.Id,
                Title = v.Title,
                Time = v.Time,
                Comment = v.Comment,
                Image = v.Image
            };
        }
    }
}
