using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS4790IA3.Models
{

    [Table("Runner")]
    public class Runner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First name must be 20 characters or less.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Last name must be 30 characters or less.")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "Shirt size must be 10 characters or less.")]
        public string ShirtSize { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RegistrationID { get; set; }

    }

    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10, ErrorMessage = "Course number must be 50 characters or less.")]
        public string Suffix { get; set; }

        [StringLength(10, ErrorMessage = "Course name must be 50 characters or less.")]
        public string Anonymous { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number must be 15 characters or less.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Email must be 30 characters or less.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Emergency contact must be 50 characters or less.")]
        public string EmergencyContact { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Contact's phone must be 15 characters or less.")]
        public string ContactsPhone { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AdultRunners { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ChildRunners { get; set; }


    }

    public class FunRunDbContext : DbContext
    {
        public DbSet<Runner> Runners { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }


    public class FunRun
    {

        public static List<Registration> getRegistrations()
        {
            FunRunDbContext db = new FunRunDbContext();
            return db.Registrations.ToList();
        }

      /*  public static List<Runner> getRunners(int registrationId)
        {
            FunRunDbContext db = new FunRunDbContext();
            var runners = db.Runners.SingleOrDefault(m => m.Id == registrationId);
            List <Runner> myRunners = new List<Runner>();
          foreach (Runner runner in runners)
            {
                myRunners.Add(runner);
            }
            return myRunners;
        } */

        public static int createRegistration(Registration registration)
        {
            FunRunDbContext db = new FunRunDbContext();
            db.Entry(registration).State = EntityState.Added;
            var savedRegistration = db.Registrations.Add(registration);
            db.SaveChanges();
            return savedRegistration.Id;
        }


        public static void createRunner(Runner runner)
        {
            FunRunDbContext db = new FunRunDbContext();
            db.Entry(runner).State = EntityState.Added;
            db.Runners.Add(runner);
            db.SaveChanges();
        }


    }
}