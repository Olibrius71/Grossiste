using Grossiste.Entities;

namespace Grossiste;

public interface IGrossisteService
{
    void AddArticle(Article article);
    
    bool DeleteArticleById(int id);
    
    Article? GetArticleById(int id);
    
    List<Article> GetAllArticles();
}