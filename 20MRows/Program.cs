using _20MRows;
using Bogus;

using var db = new AppDbContext();
db.Database.EnsureCreated();

int total = 20_000_000;
int batchSize = 1000;

Console.WriteLine("Inserting data...");

var faker = new Faker<Record>()
    .RuleFor(r => r.ISSN, f => f.Random.Replace("####-####"))
    .RuleFor(r => r.Title, f => f.Lorem.Sentence())
    .RuleFor(r => r.Author, f => f.Name.FullName())
    .RuleFor(r => r.PublishedAt, f => f.Date.Past())
    .RuleFor(r => r.Pages, f => f.Random.Int(10, 200))
    .RuleFor(r => r.Price, f => f.Finance.Amount(5, 500))
    .RuleFor(r => r.Rating, f => f.Random.Double(1, 5))
    .RuleFor(r => r.Active, f => f.Random.Bool())
    .RuleFor(r => r.CreatedAt, _ => DateTime.Now);

for (int i = 0; i < total; i += batchSize)
{
    var batch = faker.Generate(batchSize);
    db.Records.AddRange(batch);
    await db.SaveChangesAsync();
    Console.WriteLine($"Inserted {i + batchSize}");
}
