namespace ODataTest.Models
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public string Telephone { get; set; }
        public int Age { get; set; }
    }
}