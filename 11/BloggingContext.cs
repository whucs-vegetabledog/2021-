using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;

namespace EFDemo2 {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BloggingContext : DbContext {
    public BloggingContext() : base("BlogDataBase") {
      Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<BloggingContext>());
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

  }
}
