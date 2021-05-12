using CoursesApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        private Dictionary<Guid, Course> _courses = new();
        private Dictionary<Guid, Instructor> _instructors = new();

        public RepositoryService()
        {
            var c1 = new Course(
                Id: Guid.NewGuid(),
                Name: "Introduction to Asp.Net",
                Category: "Programming Language",
                InstructorId: Guid.Empty);

            var c2 = new Course(
                Id: Guid.NewGuid(),
                Name: "Angular 12 Basic",
                Category: "Programming Language",
                InstructorId: Guid.Empty);

            _courses.Add(c1.Id, c1);
            _courses.Add(c2.Id, c2);
        }

        public Task<Course> AddCourse(Course value)
        {
            var actualCourse = value with
            {
                Id = Guid.NewGuid()
            };

            _courses.Add(actualCourse.Id, actualCourse);

            return Task.FromResult(actualCourse);
        }

        public Task<Instructor> AddInstructor(Instructor value)
        {
            var maxId = _instructors.Keys.Max();
            var actual = value with
            {
                Id = Guid.NewGuid()
            };

            _instructors.Add(actual.Id, actual);
            return Task.FromResult(actual);
        }

        public Task ModifyCourse(Guid id, Course value)
        {
            if (!_courses.ContainsKey(id))
                throw new ArgumentOutOfRangeException(nameof(id));

            if (value.Id != id)
                throw new ArgumentException("Id property does not match id parameter", nameof(value));

            _courses[id] = value;
            return Task.CompletedTask;
        }

        public Task ModifyInstructor(Guid id, Instructor value)
        {
            if (!_instructors.ContainsKey(id))
                throw new ArgumentOutOfRangeException(nameof(id));

            if (value.Id != id)
                throw new ArgumentException("Id property does not match id parameter", nameof(value));

            _instructors[id] = value;
            return Task.CompletedTask;
        }

        public Task DeleteCourse(Guid id)
        {
            if (!_courses.ContainsKey(id))
                throw new ArgumentOutOfRangeException(nameof(id));

            _courses.Remove(id);
            return Task.CompletedTask;
        }

        public Task DeleteInstructor(Guid id)
        {
            if (!_instructors.ContainsKey(id))
                throw new ArgumentOutOfRangeException(nameof(id));

            _instructors.Remove(id);
            return Task.CompletedTask;
        }

        public Task<List<Course>> GetAllCourses()
        {
            return Task.FromResult(_courses.Values.ToList());
        }

        public Task<List<Instructor>> GetAllInstructors()
        {
            return Task.FromResult(_instructors.Values.ToList());
        }
    }
}
