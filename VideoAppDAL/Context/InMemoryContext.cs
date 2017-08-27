using System;
using System.Collections.Generic;
using System.Text;
using CSVideoMenu;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace VideoAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        private static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("VideoDB").Options;

        public InMemoryContext() : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
