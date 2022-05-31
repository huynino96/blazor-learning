using Microsoft.AspNetCore.Identity;
using TodoListBlazor.Api.Entities;

namespace TodoListBlazor.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async System.Threading.Tasks.Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if(!context.Users.Any())
            {
                var user = new Entities.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin@email.com",
                    PhoneNumber= "012345678",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Task 1",
                    CreatedDate = DateTime.Now,
                    priority = Enums.Priority.High,
                    status = Enums.Status.Opened
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
