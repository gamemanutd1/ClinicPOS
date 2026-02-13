using ClinicPOS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicPOS.Infrastructure.Context;

public interface IApplicationDbContext
{
    DbSet<User> User { get; }
    DbSet<Role> Role { get; }
    DbSet<Patient> Book { get; }
}