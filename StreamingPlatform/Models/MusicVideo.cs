using StreamingPlatform.Models;

public class MusicVideo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
}
