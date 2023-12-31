﻿using Microsoft.EntityFrameworkCore;
using Octokit;
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

        public DbSet<LabelEntity> Label {  get; set; }

        public DbSet<CollaboratEntity>collaborat { get; set; }
    }
}
