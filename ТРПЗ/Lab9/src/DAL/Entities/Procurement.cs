namespace DAL.Entities;

public class Procurement
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty; 
    public string Destination { get; set; } = string.Empty;
    public int Quantity { get; set; } 
    public float Weight { get; set; } 
    public float Volume { get; set; }
}
