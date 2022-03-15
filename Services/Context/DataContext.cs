using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pickflicksbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace pickflicksbackend.Services.Context
{
    public class DataContext : DbContext 
    {
        public DbSet<UserModel> UserInfo { get; set;}
        public DbSet<MWGModel> MWGInfo { get; set; }
        public DataContext(DbContextOptions options ): base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}