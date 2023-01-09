namespace Myblogsite.Models
{
	public class Post
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
	    public DateTime Time { get; set; }
        public string? Comment { get; set; }
		public string? Image  { get; set; }
}
}
