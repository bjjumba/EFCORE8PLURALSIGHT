using Microsoft.EntityFrameworkCore;
using PublishData;
using PublisherDomain;

using var context = new PublisherContext();
context.Database.EnsureCreated();

// AddAuthor();
AddAuthorWithBooks();
// GetAuthors();
GetAuthorsWithBooks();


void AddAuthorWithBooks()
{
    var author = new Author {FirstName = "Julie", LastName = "Lerman"};
    author.Books.Add(new Book{Title = "Programming Entity Framework", PublishDate = new DateOnly(2018,8,1)});
    author.Books.Add(new Book{Title = "Programming Entity Framework 2nd Edition", PublishDate = new DateOnly(2010,8,1)});
    using var context = new PublisherContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PublisherContext();
    var authors = context.Authors.Include(a => a.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine($"{author.FirstName} {author.Books.Count}");
    }
}
void GetAuthors()
{
    using var context = new PublisherContext();
    var authors = context?.Authors.ToList();
    if (authors != null)
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.FirstName}");
        }
}

void AddAuthor()
{
    var author = new Author{FirstName = "Jjumba", LastName = "Eric Benjamin"};
    using var context = new PublisherContext();
    context.Authors.Add(author);
    context.SaveChanges();
}