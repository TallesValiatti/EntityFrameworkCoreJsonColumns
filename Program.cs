using EntityFrameworkCoreJsonColumns.Data;
using EntityFrameworkCoreJsonColumns.Models;

using var context = new AppDbContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

await AddDataAsync(context);

// Filter data
var books = context
    .Books
    .AsEnumerable()
    .Where(x => x.Details != null && x.Details!.Tags != null)
    .Where(x => x.Details!.Tags!.Any(x => x.Key == "Category" && x.Value == "Horror"))
    .ToList();

Console.Write($"Count: {books.Count()}");

async Task AddDataAsync(AppDbContext context)
{
    await context.Books.AddRangeAsync(new List<Book>
        {
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "Lord of the rings",
            Details = new Details
            {
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Key = "Category",
                        Value = "Fantasy"
                    },
                    new Tag
                    {
                        Key = "Category",
                        Value = "Epic"
                    }
                }
            }
        },
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "The Shining",
            Details = new Details
            {
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Key = "Category",
                        Value = "Horror"
                    }
                }
            }
        },
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "The Hobbit"
        }
    });

    await context.SaveChangesAsync();
}