using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace Integration.Tests.Base
{
    public abstract class BaseIntegrationTests
    {
        protected virtual bool UseSqlServer => true;

        [TestInitialize]
        public virtual async Task TestInitializeAsync()
        {
            await DestroyDatabaseAsync();
            await CreateDatabaseAsync();
        }

        [TestCleanup]
        public virtual async Task TestCleanupAsync()
        {
            await DestroyDatabaseAsync();
        }

        protected async Task RunOnDatabaseAsync(Func<DatabaseContext, Task> action)
        {
            if (UseSqlServer)
            {
                await RunOnSqlServer(action);
            }
            else
            {
                await RunOnMemory(action);
            }
        }

        private async Task RunOnSqlServer(Func<DatabaseContext, Task> databaseAction)
        {
            var connection = @"Server = .\SQLEXPRESS; Database=Temperature.Development.Testing; Trusted_Connection = true;";

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new DatabaseContext(options))
            {
                await databaseAction(context);
            }
        }

        private async Task RunOnMemory(Func<DatabaseContext, Task> databaseAction)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("TemperatureDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                await databaseAction(context);
            }
        }

        private async Task CreateDatabaseAsync()
        {
            await RunOnDatabaseAsync(context => context.Database.EnsureCreatedAsync());
        }

        private async Task DestroyDatabaseAsync()
        {
            await RunOnDatabaseAsync(context => context.Database.EnsureDeletedAsync());
        }
    }
}
