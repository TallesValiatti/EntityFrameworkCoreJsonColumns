namespace  EntityFrameworkCoreJsonColumns.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Details? Details { get; set; } = default!;
}