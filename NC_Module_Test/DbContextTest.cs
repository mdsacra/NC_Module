using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NC_Module.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NC_Module_Test
{
    public class DbContextTest : IDisposable
    {

        public DataContext Context;

        public DbContextTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DbContextTest").Options;

            Context = new DataContext(options);


            Context.SaveChanges();

        }

        public void Dispose()
        {

        }
    }
}
