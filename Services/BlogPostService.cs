#region snippet_BookServiceClass
using BlogPostApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlogPostApi.Services
{
  public class BlogPostService
  {
    private readonly IMongoCollection<BlogPost> _blogPosts;

    #region snippet_BookServiceConstructor
    public BlogPostService(IBlogPostsDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _blogPosts = database.GetCollection<BlogPost>(settings.BlogPostsCollectionName);
    }
    #endregion

    public List<BlogPost> Get() =>
        _blogPosts.Find(blogPost => true).ToList();

    public BlogPost Get(string id) =>
        _blogPosts.Find<BlogPost>(blogPost => blogPost.Id == id).FirstOrDefault();

    public BlogPost Create(BlogPost blogPost)
    {
      _blogPosts.InsertOne(blogPost);
      return blogPost;
    }

    public void Update(string id, BlogPost blogPostIn) =>
        _blogPosts.ReplaceOne(blogPost => blogPost.Id == id, blogPostIn);

    public void Remove(BlogPost blogPostIn) =>
        _blogPosts.DeleteOne(blogPost => blogPost.Id == blogPostIn.Id);

    public void Remove(string id) =>
        _blogPosts.DeleteOne(blogPost => blogPost.Id == id);
  }
}
#endregion
