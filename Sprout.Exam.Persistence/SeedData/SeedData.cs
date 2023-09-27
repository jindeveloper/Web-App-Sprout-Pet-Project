namespace Sprout.Exam.Persistence.SeedData
{
    public  class SeedData
    {
        public static async Task SeedAsync(
                        UserManager<ApplicationUser> userManager)
        {
            try
            {
                if (userManager.Users.Count() > 0)
                    return;

                var result = await userManager.CreateAsync(new ApplicationUser() { UserName = "admin", Email = "jin.necesario@uap.asia", EmailConfirmed = true }, "p@ssw0rd123Jin");

                if (!result.Succeeded)
                {
                    throw new Exception($"Unable to create user {result.Errors.Select(x => x.Description)}");
                }
      
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
