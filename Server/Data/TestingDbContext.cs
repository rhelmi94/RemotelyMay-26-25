using Microsoft.EntityFrameworkCore;

namespace RaefTech.Server.Data;

public class TestingDbContext : AppDb
{
    public TestingDbContext(IWebHostEnvironment hostEnvironment) 
        : base(hostEnvironment)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("Raef Tech");
        base.OnConfiguring(options);
    }
}
