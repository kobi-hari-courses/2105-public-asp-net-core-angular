using CoursesApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesApp.Services
{
    public interface IRepositoryService
    {
        Task<Course> AddCourse(Course value);
        Task<Instructor> AddInstructor(Instructor value);
        Task DeleteCourse(Guid id);
        Task DeleteInstructor(Guid id);
        Task<List<Course>> GetAllCourses();
        Task<List<Instructor>> GetAllInstructors();
        Task ModifyCourse(Guid id, Course value);
        Task ModifyInstructor(Guid id, Instructor value);
    }
}