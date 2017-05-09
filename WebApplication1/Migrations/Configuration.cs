namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.GuestBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.GuestBookContext context)
        {
            
            //AddTestUser(context);
            //AddTestMessage(context);
            
        }

        public void AddTestUser(GuestBookContext context)
        {
            context.Users.AddOrUpdate(
                u => u.Name,
                new User { Name = "test", Pasword = "0000" }
           );
            context.SaveChanges();
        }

        public void AddTestMessage(GuestBookContext context)
        {
            var test = context.Users.Where(u => u.Name == "test").SingleOrDefault();
            context.Messages.AddOrUpdate(
                m => m.Id_user,
                new Message { Id_user = test.Id, MessageText = "test text", MessageDate = DateTime.Now }
           );
            context.SaveChanges();
        }
    }
}
