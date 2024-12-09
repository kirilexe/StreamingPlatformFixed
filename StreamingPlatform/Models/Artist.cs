using System.Collections.Generic;

public class Artist
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Song> SongsList { get; set; }
    public virtual List<Genre> GenreList { get; set; }
}
