using University.Models;
using Microsoft.EntityFrameworkCore;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        public DbSet<Book> Books { get; set; }
        public DbSet<AthleticsFacility> AthleticsFacilities { get; set; }

        public DbSet<Classroom> Classrooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("UniversityDb");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region StudentSubject
            modelBuilder.Entity<Subject>().Ignore(s => s.IsSelected);

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Wieńczysław", LastName = "Nowakowicz", PESEL = "PESEL1", BirthDate = new DateTime(1987, 05, 22) },
                new Student { StudentId = 2, Name = "Stanisław", LastName = "Nowakowicz", PESEL = "PESEL2", BirthDate = new DateTime(2019, 06, 25) },
                new Student { StudentId = 3, Name = "Eugenia", LastName = "Nowakowicz", PESEL = "PESEL3", BirthDate = new DateTime(2021, 06, 08) });

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Matematyka", Semester = "1", Lecturer = "Michalina Warszawa" },
                new Subject { SubjectId = 2, Name = "Biologia", Semester = "2", Lecturer = "Halina Katowice" },
                new Subject { SubjectId = 3, Name = "Chemia", Semester = "3", Lecturer = "Jan Nowak" }
            );
            #endregion

            #region Pack

            #region Book 
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Example Book 1",
                    Author = "John Doe",
                    Publisher = "Publisher 1",
                    PublicationDate = new DateTime(2020, 1, 1),
                    ISBN = "ISBN1",
                    Genre = "Genre 1",
                    Description = "This is an example book description 1."
                },
                new Book
                {
                    BookId = 2,
                    Title = "Example Book 2",
                    Author = "Alice Smith",
                    Publisher = "Publisher 2",
                    PublicationDate = new DateTime(2021, 2, 2),
                    ISBN = "ISBN2",
                    Genre = "Genre 2",
                    Description = "This is an example book description 2."
                },
                new Book
                {
                    BookId = 3,
                    Title = "Example Book 3",
                    Author = "Bob Johnson",
                    Publisher = "Publisher 3",
                    PublicationDate = new DateTime(2022, 3, 3),
                    ISBN = "ISBN3",
                    Genre = "Genre 3",
                    Description = "This is an example book description 3."
                }
            );

            #endregion

            #region AthleticsFacility


            modelBuilder.Entity<AthleticsFacility>().HasData(
                new AthleticsFacility
                {
                    AthleticsFacilityId = 1,
                    Name = "Athletics Facility 1",
                    Location = "Location 1",
                    Type = "Type 1",
                    Description = "Description of Athletics Facility 1",
                    Capacity = 100
                },
                new AthleticsFacility
                {
                    AthleticsFacilityId = 2,
                    Name = "Athletics Facility 2",
                    Location = "Location 2",
                    Type = "Type 2",
                    Description = "Description of Athletics Facility 2",
                    Capacity = 150
                },
                new AthleticsFacility
                {
                    AthleticsFacilityId = 3,
                    Name = "Athletics Facility 3",
                    Location = "Location 3",
                    Type = "Type 3",
                    Description = "Description of Athletics Facility 3",
                    Capacity = 200
                }
            );


            #endregion

            #region Classroom
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    ClassroomId = 1,
                    Location = "Building A, Room 101",
                    Capacity = 30,
                    AvailableSeats = 25,
                    Projector = true,
                    Whiteboard = true,
                    Microphone = false,
                    Description = "Standard classroom with projector and whiteboard."
                },
                new Classroom
                {
                    ClassroomId = 2,
                    Location = "Building B, Room 202",
                    Capacity = 50,
                    AvailableSeats = 50,
                    Projector = true,
                    Whiteboard = true,
                    Microphone = true,
                    Description = "Large lecture hall with full audio-visual equipment."
                },
                new Classroom
                {
                    ClassroomId = 3,
                    Location = "Building C, Room 303",
                    Capacity = 20,
                    AvailableSeats = 18,
                    Projector = false,
                    Whiteboard = true,
                    Microphone = false,
                    Description = "Small classroom with whiteboard."
                }
            );
            #endregion

            #endregion

        }
    }
}
