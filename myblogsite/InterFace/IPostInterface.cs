using Myblogsite.Models;

namespace Myblogsite.InterFace
{
	public interface IpostInterface
	
	{

		List<Post> GetAllPosts();
		Post GetById(Guid postId); 
		Post AddPost(Post post); 
		Post UpdatePost(Post post);
		void DeletePost(Guid id);
	}
}
