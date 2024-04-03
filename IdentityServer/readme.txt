Add-Migration InitialIdentityServerMigration -c PersistedGrantDbContext => Update-Database -Context PersistedGrantDbContext
Added two tables: DeviceCodes and PesistedGrants
Add-Migration InitialIdentityServerMigration -c ConfigurationDbContext => Update-Database -Context ConfigurationDbContext
Added two tables: DeviceCodes and PesistedGrants
Add-Migration AppIdentityUserRoleMigration -c AppDbContext => Update-Database -Context AppDbContext