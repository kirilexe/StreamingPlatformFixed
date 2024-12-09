using System.ComponentModel.DataAnnotations;

public class Song
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
}
