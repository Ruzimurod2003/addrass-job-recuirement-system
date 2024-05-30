using AdrasJRS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdrasJRS.Data.Extensions;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //For Admin role
        var adminRoleId = new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8");

        //For Admin default account
        var adminId = new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3");

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = adminRoleId,
            Name = "Admin",
            NormalizedName = "ADMIN",
            Description = "Administrator role"
        },
        new AppRole
        {
            Id = new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
            Name = "Employer",
            NormalizedName = "EMPLOYER",
            Description = "Employer role"
        },
        new AppRole
        {
            Id = new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
            Name = "User",
            NormalizedName = "USER",
            Description = "User role"
        });

        var hasher = new PasswordHasher<AppUser>();

        modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            Id = adminId,
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Abc123!@#"),
            SecurityStamp = string.Empty,
            FullName = "Administrator",
            Slug = "administrator",
            UrlAvatar = "default_admin.png",
            Disable = false,
            CreateDate = DateTime.Now,
            Status = -1 //admin status
        });

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            RoleId = adminRoleId,
            UserId = adminId
        });

        modelBuilder.Entity<Category>().HasData(
           new Category() { Id = 1, Name = "Skill", Slug = "skill", Description = "Die Fähigkeit, vielfältige Aufgaben in IT-Rollen auszuführen" },
           new Category() { Id = 2, Name = "Title", Slug = "title", Description = "Die Art der Position und Ebene, die ein Mitarbeiter innehat" },
           new Category() { Id = 3, Name = "Employer", Slug = "employer", Description = "Suchen Sie nach Kandidaten, die Code in mehreren Programmiersprachen schreiben" },
           new Category() { Id = 4, Name = "Province", Slug = "province", Description = "Wenn sich ein Mitarbeiter zur Arbeit bei der Firma meldet" }
        );

        modelBuilder.Entity<Time>().HasData(
           new Time() { Id = 1, Name = "Teilzeit", Slug = "teilzeit" },
           new Time() { Id = 2, Name = "Vollzeit", Slug = "vollzeit" },
           new Time() { Id = 3, Name = "Von zuhause aus arbeiten", Slug = "von-zuhause-aus-arbeiten" },
           new Time() { Id = 4, Name = "Im Büro", Slug = "im-büro" },
           new Time() { Id = 5, Name = "Vorübergehend", Slug = "vorübergehend" }
        );

        modelBuilder.Entity<Province>().HasData(
            new Province() { Id = 1, Name = "Baden-Württemberg ", Slug = "baden-württemberg", CategoryId = 4 },
            new Province() { Id = 2, Name = "Bayern (Bavaria).", Slug = "bayern-(bavaria)", CategoryId = 4 },
            new Province() { Id = 3, Name = "Berlin", Slug = "berlin", CategoryId = 4 },
            new Province() { Id = 4, Name = "Brandenburg", Slug = "brandenburg", CategoryId = 4 },
            new Province() { Id = 5, Name = "Bremen", Slug = "bremen", CategoryId = 4 },
            new Province() { Id = 6, Name = "Hamburg", Slug = "hamburg", CategoryId = 4 },
            new Province() { Id = 7, Name = "Hessen (Hesse)", Slug = "hessen-(hesse)", CategoryId = 4 },
            new Province() { Id = 8, Name = "Mecklenburg-Vorpommern (Mecklenburg-West Pomerania)", Slug = "mecklenburg-vorpommern-(mecklenburg-west-pomerania)", CategoryId = 4 },
            new Province() { Id = 9, Name = "Niedersachsen (Lower Saxony)", Slug = "niedersachsen-(lower-saxony)", CategoryId = 4 },
            new Province() { Id = 10, Name = "Nordrhein-Westfalen (North Rhine-Westphalia)", Slug = "nordrhein-westfalen-(north-rhine-westphalia)", CategoryId = 4 },
            new Province() { Id = 11, Name = "Rheinland-Pfalz (Rhineland-Palatinate)", Slug = "rheinland-pfalz-(rhineland-palatinate)", CategoryId = 4 },
            new Province() { Id = 12, Name = "Saarland", Slug = "saarland", CategoryId = 4 },
            new Province() { Id = 13, Name = "Sachsen (Saxony)", Slug = "sachsen-(saxony)", CategoryId = 4 },
            new Province() { Id = 14, Name = "Sachsen-Anhalt (Saxony-Anhalt)", Slug = "sachsen-anhalt-(saxony-anhalt)", CategoryId = 4 },
            new Province() { Id = 15, Name = "Schleswig-Holstein", Slug = "schleswig-holstein", CategoryId = 4 },
            new Province() { Id = 16, Name = "Thüringen (Thuringia)", Slug = "thüringen-(thuringia)", CategoryId = 4 }
        );

        modelBuilder.Entity<Country>().HasData(
           new Country() { Id = 1, Name = "Vietnam", Flag = "Vietnam.png" },
           new Country() { Id = 2, Name = "Vereinigt States", Flag = "USA.png" },
           new Country() { Id = 3, Name = "China", Flag = "China.png" },
           new Country() { Id = 4, Name = "Japan", Flag = "Japan.png" },
           new Country() { Id = 5, Name = "Singapur", Flag = "Singapore.png" },
           new Country() { Id = 6, Name = "Kanada", Flag = "Canada.png" },
           new Country() { Id = 7, Name = "England", Flag = "England.png" },
           new Country() { Id = 8, Name = "Indien", Flag = "India.png" },
           new Country() { Id = 9, Name = "Russland", Flag = "Russia.png" },
           new Country() { Id = 10, Name = "Schweiz", Flag = "Switzerland.png" },
           new Country() { Id = 11, Name = "Frankreich", Flag = "France.png" },
           new Country() { Id = 12, Name = "Italien", Flag = "Italy.png" },
           new Country() { Id = 13, Name = "Polen", Flag = "Poland.png" },
           new Country() { Id = 14, Name = "Südkorea", Flag = "Korea.png" },
           new Country() { Id = 15, Name = "Australien", Flag = "Australia.png" },
           new Country() { Id = 16, Name = "Deutschland", Flag = "Germany.png" },
           new Country() { Id = 17, Name = "Schweden", Flag = "Sweden.png" }
        );
    }
}