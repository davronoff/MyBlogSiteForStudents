namespace Myblogsite.Models
{
	public class Post
	{
		//blog site modeli
		public Guid Id { get; set; }
		public string? Title { get; set; }
	    public DateTime Time { get; set; }
        public string? Comment { get; set; }
		public string? Image  { get; set; }
	}
}
