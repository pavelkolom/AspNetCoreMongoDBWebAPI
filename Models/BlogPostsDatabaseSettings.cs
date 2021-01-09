namespace BlogPostApi.Models
{
    public class BlogPostsDatabaseSettings : IBlogPostsDatabaseSettings
    {
        public string BlogPostsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBlogPostsDatabaseSettings
  {
        string BlogPostsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
