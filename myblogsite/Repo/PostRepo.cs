using Myblogsite.DataLayer;
using Myblogsite.InterFace;
using Myblogsite.Models;

public class PostRepo : IpostInterface
{
	private readonly DataContext _dataContext;

	public PostRepo(DataContext dataContext)
	{
		_dataContext = dataContext;
	}
	public Post AddPost(Post post)
	{
		_dataContext.posts.Add(post);
		_dataContext.SaveChanges();
		return post;
	}

	public void DeletePost(Guid id)
	{
		var food = _dataContext.posts.FirstOrDefault(f => f.Id == id);
		_dataContext.posts.Remove(food);
		_dataContext.SaveChanges();
	}
	public List<Post> GetAllPosts()
	{
		var allpost = _dataContext.posts.ToList();
		return allpost;
	}

	public Post GetById(Guid postId)
	{
		var post = _dataContext.posts.FirstOrDefault(f => f.Id == postId);
		return post;
	}

	public Post UpdatePost(Post post)
	{
		_dataContext.posts.Update(post);
		_dataContext.SaveChanges();
		return post;
	}
}
