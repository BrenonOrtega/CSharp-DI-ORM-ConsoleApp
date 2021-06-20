using System;
using System.Collections.Generic;
using SchoolApp.Application.Dtos.ReadDtos.StudentDtos;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Dtos.ReadDtos
{
    public class StudentReadDto 
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public IList<StudentCourseDto> Courses { get; }

        public StudentReadDto() {  }
        public StudentReadDto(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            Email = student.Email;
        }

        public static implicit operator StudentReadDto(Student student) => new StudentReadDto(student);

        public override string ToString() => $"Student:{FirstName} {LastName} - Id:{Id} - Email: {Email}";
    }
}
