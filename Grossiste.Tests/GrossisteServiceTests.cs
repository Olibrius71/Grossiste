// File: Grossiste.Tests/GrossisteTests.cs
using Grossiste.Entities;
using Xunit;

namespace Grossiste.Tests;

public class GrossisteServiceTests
{
    private readonly IGrossisteService _grossisteService;

    public GrossisteServiceTests()
    {
        GrossisteService.Articles.Clear();
        _grossisteService = new GrossisteService();
    }

    [Fact]
    public void AddArticle_Should_Add_New_Article()
    {
        const string name = "Test Article";
        const double price = 85.99;
        var initialCount = _grossisteService.GetAllArticles().Count;

        _grossisteService.AddArticle(new Article(1, name, price));
        var articles = _grossisteService.GetAllArticles();
        Assert.Equal(initialCount + 1, articles.Count);
        Assert.Contains(articles, a => a.Nom == name && a.Prix == price);
    }

    [Fact]
    public void GetArticleById_Should_Return_Correct_Article()
    {
        _grossisteService.AddArticle(new Article(1, "Article 1", 10));
        _grossisteService.AddArticle(new Article(2, "Article 2", 20));
        
        var article = _grossisteService.GetArticleById(2);
        Assert.NotNull(article);
        Assert.Equal("Article 2", article.Nom);
        Assert.Equal(20, article.Prix);
    }

    [Fact]
    public void DeleteArticle_Should_Remove_Existing_Article()
    {
        _grossisteService.AddArticle(new Article(1, "To Delete", 5));
        var initialCount = _grossisteService.GetAllArticles().Count;

        var result = _grossisteService.DeleteArticleById(1);
        Assert.True(result);
        Assert.Equal(initialCount - 1, _grossisteService.GetAllArticles().Count);
    }

    [Fact]
    public void DeleteArticle_Should_Return_False_For_Invalid_Id()
    {
        var result = _grossisteService.DeleteArticleById(999);
        Assert.False(result);
    }

    [Fact]
    public void GetAllArticles_Should_Return_All_Articles()
    {
        _grossisteService.AddArticle(new Article(1, "A1", 10));
        _grossisteService.AddArticle(new Article(2, "A2", 20));

        var articles = _grossisteService.GetAllArticles();
        Assert.Equal(2, articles.Count);
        Assert.Contains(articles, a => a.Nom == "A1");
        Assert.Contains(articles, a => a.Nom == "A2");
    }

}