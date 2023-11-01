using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class FundoDbContext:DbContext
    {
        public FundoDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<UserEntity> user { get; set; }

        public DbSet<NoteEntity>Note { get; set; }
    }
}
