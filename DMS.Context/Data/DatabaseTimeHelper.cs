using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DMS.Context.Data;

public static class DatabaseTimeHelper
{
    public static DateTime GetCurrentDatabaseDateTime(ApplicationDbContext dbContext)
    {
        return dbContext.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
    }
}
