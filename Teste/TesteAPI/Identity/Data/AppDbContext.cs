using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Models;

namespace ApiIdentityEndpoint.Data;

public class AppDbContext(DbContextOptions options) 
    : IdentityDbContext<User>(options);

