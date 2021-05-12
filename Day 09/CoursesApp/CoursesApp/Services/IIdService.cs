using System;

namespace CoursesApp.Services
{
    public interface IIdService
    {
        Guid Id { get; }

        string User { get; set; }
    }
}