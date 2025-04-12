namespace Techan.DataAccess.DataInitalizers;
internal static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder builder)
    {
        builder.AddLanguages();
    }

    private static void AddLanguages(this ModelBuilder builder)
    {
        Language language1 = new() { Id = 1, Name = "Azerbaijan", Code = "AZE", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1730241623/motordoctor.az/fajaznl6ilmlbmo05xbw.png", CreatedBy = "SUPERADMIN", CreatedDate = DateTime.MinValue };
        Language language2 = new() { Id = 2, Name = "English", Code = "ENG", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1730241623/motordoctor.az/mygg6rnd9rkxwc6vlljx.png", CreatedBy = "SUPERADMIN", CreatedDate = DateTime.MinValue };
        Language language3 = new() { Id = 3, Name = "Russian", Code = "RUS", ImagePath = "https://res.cloudinary.com/dlilcwizx/image/upload/v1730241623/motordoctor.az/upkqfbyfpy7rvmjdwfsm.png", CreatedBy = "SUPERADMIN", CreatedDate = DateTime.MinValue };

        List<Language> languages = [language1, language2, language3];


        builder.Entity<Language>().HasData(languages);
    }
}
