using Grossiste.Entities;

namespace Grossiste;

public class GrossisteService : IGrossisteService
{
    public static List<Article> Articles = new List<Article>();
    
    public void AddArticle(Article article)
    {
        Articles.Add(article);
    }

    public bool DeleteArticleById(int id)
    {
        return Articles.RemoveAll(a => a.Id == id) > 0;
    }

    public Article? GetArticleById(int id)
    {
        return Articles.FirstOrDefault(a => a.Id == id);
    }

    public List<Article> GetAllArticles()
    {
        return new List<Article>(Articles);
    }
}