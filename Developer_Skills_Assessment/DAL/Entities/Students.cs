using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Developer_Skills_Assessment.DAL.Entities
{
    public class Students
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
