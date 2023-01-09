using Microsoft.EntityFrameworkCore;
using Myblogsite.Models;

namespace Myblogsite.DataLayer
{
#pragma warning disable
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Post> posts { get; set; }
	}
}
