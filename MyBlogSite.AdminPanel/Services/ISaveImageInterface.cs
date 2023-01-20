namespace MyBlogSite.AdminPanel.Services
{
    public interface ISaveImageInterface
    {
        string SaveImage(IFormFile newFile);
        void DeleteImage(string fileName);
    }
}
