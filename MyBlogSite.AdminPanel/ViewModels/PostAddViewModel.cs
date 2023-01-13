namespace MyBlogSite.AdminPanel.ViewModels
{
    public class PostAddViewModel
    {
        public string? Title { get; set; }
        public DateTime Time { get; set; }
        public string? Comment { get; set; }
        public IFormFile? Image { get; set; }
    }
}
