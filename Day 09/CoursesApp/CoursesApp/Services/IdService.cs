using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Services
{
    public class IdService : IIdService, IDisposable
    {
        public Guid Id { get; private set; }

        public string User { get; set; }

        public IdService()
        {
            Id = Guid.NewGuid();
        }

        public void Dispose()
        {
        }
    }
}
