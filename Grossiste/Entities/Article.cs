namespace Grossiste.Entities;

public class Article(int id, string nom, double prix)
{
    public int Id { get; set; } = id;
    public string Nom { get; set; } = nom;
    public double Prix { get; set; } = prix;
}