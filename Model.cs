using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Author> Authors{ get; set; }

    public string ConnectionString { get; }
    public MariaDbServerVersion ServerVersion { get; }

    public BloggingContext()
    {
        ServerVersion = new MariaDbServerVersion(new Version(10, 4, 32));
        ConnectionString = "server=localhost;user=root;password=;database=studio";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(ConnectionString, ServerVersion);
}

public class Song
{
    public int SongID { get; set; }
    public string Title { get; set; }
    public int Duration {  get; set; }
    public Album Album { get; set; }
    public List<Author> Authors { get; set; }
    public List<User> UsersWhoOwn { get; set; }
}
public class Album
{
    public int AlbumID { get; set; }
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; } 
    public List<Song> Songs { get; set; }
    public List<Author> Authors { get; set; }
}
public class Author
{
    public int AuthorID { get; set; }
    public string Name { get; set; }
    public List<Album> Albums { get; set; }
    public List<Song> Songs { get; set; }
}
public class User
{
    public int UserID { get; set; }
    public bool IsAdmin { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public List<Song> OwnedSongs { get; set; }
}