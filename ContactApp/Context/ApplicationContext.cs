using ContactApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts");
                entity.HasKey(e => e.ContactId);
                entity.Property(e => e.ContactId).HasColumnName("ContactId");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("ProfileId")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);                

                entity.Property(e => e.Company)
                    .HasColumnName("Company")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("Birthdate")
                    .IsRequired();

                entity.Property(e => e.WorkNumber)
                    .HasColumnName("WorkNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.PersonalNumber)
                    .HasColumnName("PersonalNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .HasColumnName("Address")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.City)
                    .HasColumnName("City")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.State)
                    .HasColumnName("State")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.HasOne(p => p.Profile)
                    .WithMany(c => c.Contacts)
                    .HasForeignKey(p => p.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contact_profile");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profiles");
                entity.HasKey(e => e.ProfileId);
                entity.Property(e => e.ProfileId).HasColumnName("ProfileId");


                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profile>().HasData(
                new Profile() { ProfileId = 1, Name = "User"    },
                new Profile() { ProfileId = 2, Name = "Manager" },
                new Profile() { ProfileId = 3, Name = "Admin"   });

            modelBuilder.Entity<Contact>().HasData(
                new Contact() { 
                    ContactId = 1, 
                    ProfileId = 1, 
                    Name = "Juan Gonzales", 
                    Company = "Santander Rio",
                    Image = "image1", 
                    Email = "juan.gonzales@gmail.com", 
                    Birthdate = DateTime.Now,
                    WorkNumber = "5411527754", 
                    PersonalNumber = "5411527714", 
                    Address = "Calle 1 123",
                    City = "Mar del Plata", 
                    State = "Buenos Aires"
                },
                new Contact() { 
                    ContactId = 2, 
                    ProfileId = 2, 
                    Name = "Guillermo Garcia", 
                    Company = "Galeno",
                    Image = "image2", 
                    Email = "guillermo.garcia@gmail.com", 
                    Birthdate = DateTime.Now.AddDays(-2),
                    WorkNumber = "5411635489", 
                    PersonalNumber = "5411635449", 
                    Address = "Belgrano 550",
                    City = "Mendoza", 
                    State = "Mendoza"
                },
                new Contact() { 
                    ContactId = 3, 
                    ProfileId = 3, 
                    Name = "Martin Mendoza", 
                    Company = "Arcor",
                    Image = "image3", 
                    Email = "martin.mendoza@gmail.com", 
                    Birthdate = DateTime.Now.AddDays(-5),
                    WorkNumber = "5411526358", 
                    PersonalNumber = "5411526328", 
                    Address = "Av Libertador 1700",
                    City = "Capital Federal", 
                    State = "Buenos Aires"
                },
                new Contact()
                {
                    ContactId = 4,
                    ProfileId = 1,
                    Name = "Homero Simpson",
                    Company = "Planta Nuclear",
                    Image = "image4",
                    Email = "homero.simpson@lossimpsons.com",
                    Birthdate = DateTime.Now.AddYears(-55),
                    WorkNumber = "344456987",
                    PersonalNumber = "344456984",
                    Address = "Avenida Siempre Viva 1234",
                    City = "Ciudad Grito",
                    State = "springfield"
                },
                new Contact()
                {
                    ContactId = 5,
                    ProfileId = 3,
                    Name = "Tony Stark",
                    Company = "Stark Industries",
                    Image = "image5",
                    Email = "tony.stark@starkindustries.com",
                    Birthdate = DateTime.Now.AddYears(-50),
                    WorkNumber = "5411526358",
                    PersonalNumber = "5411526328",
                    Address = "9th Street",
                    City = "NY",
                    State = "NY"
                });
        }
    }
}
