﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.PermissionManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpPermissionManagementDbProperties.ConnectionStringName)]
    public class PermissionManagementDbContext : AbpDbContext<PermissionManagementDbContext>, IPermissionManagementDbContext
    {
        public DbSet<PermissionGrant> PermissionGrants { get; set; }

        public PermissionManagementDbContext(DbContextOptions<PermissionManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.NamingConventionsRewriteName(AbpPermissionManagementDbProperties.DbNamingConvention);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePermissionManagement();

            builder.NamingConventionsRewriteName(AbpPermissionManagementDbProperties.DbNamingConvention);
        }

    }
}
