using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backendnet.Data.Seed;

public static class SeedIdentityUserData 
{
    public static void SeedUserIdentityData(this ModelBuilder modelBuilder) 
    {
        // Agregar el rol de "Administrador" a la tabla AspNetRoles
        string  AdministradorRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole{
            Id = AdministradorRoleId,
            Name = "Administrador",
            NormalizedName = "Administrador".ToUpper()
        });

        // Agregar el rol "Usuario" a la tabla AspNetRoles
        string  UsuarioRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole{
            Id = UsuarioRoleId,
            Name = "Usuario",
            NormalizedName = "Usuario".ToUpper()
        });

        // Agregamos un usuario a la tabla AspNetUsers
        var  UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser{
                Id = UsuarioId,
                UserName = "emilianolezama@outlook.com",
                Email = "emilianolezama@outlook.com",
                NormalizedEmail = "emilianolezama@outlook.com".ToUpper(),
                Nombre = "Cesar Emiliano Lezama López",
                NormalizedUserName = "emilianolezama@outlook.com".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
                Protegido = true // Este no se puede eliminar
            }
        );

        // Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> 
            {
                RoleId = AdministradorRoleId,
                UserId = UsuarioId
            }
        );

         // Agregamos un usuario a la tabla AspNetUsers
        UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
            {
                Id = UsuarioId,
                UserName = "patito@uv.mx",
                Email = "patito@uv.mx",
                NormalizedEmail = "patito@uv.mx".ToUpper(),
                Nombre = "Usuario Patito",
                NormalizedUserName = "patito@uv.mx".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito")
            }
        );


        // Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> 
            {
                RoleId = UsuarioRoleId,
                UserId = UsuarioId
            }
        );
    
    }
}