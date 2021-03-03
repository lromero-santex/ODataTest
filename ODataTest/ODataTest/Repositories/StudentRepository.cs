using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using ODataTest.Models;

namespace ODataTest.Repositories
{
    public class StudentRepository
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            if (!_context.Students.Any())
            {
                _context.Students.AddRange(GetStudents());
                _context.SaveChanges();
            }
        }
        public IEnumerable<Student> GetAll(ODataQueryOptions<Student> oDataQueryOptions)
        {
            return oDataQueryOptions.ApplyTo(_context.Students).Cast<Student>().ToList();
        }
        
        
        public IEnumerable GetAllDynamic(ODataQueryOptions<Student> oDataQueryOptions)
        {
            return oDataQueryOptions.ApplyTo(_context.Students);
        }
        private static IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { Id= 1, Name = "Juan Perez", Telephone = "1234", Age = 10, Address = GetAddresses().First()},
                new Student { Id= 2, Name = "Carlos Garcia", Telephone = "4567", Age = 20, Address = GetAddresses().Skip(1).First()},
                new Student { Id= 3, Name = "Pablo Algo", Telephone = "7894", Age = 30, Address = GetAddresses().Skip(2).First()}
            };
        }

        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address { Id=1, City = "Cordoba", Number = "123", Street = "Avellaneda", StudentId = 1},
                new Address { Id=2, City = "Buenos Aires", Number = "321", Street = "Colon", StudentId = 2},
                new Address { Id=3, City = "Buenos Aires", Number = "456", Street = "Caseros", StudentId = 3}
            };
        }
    }
}