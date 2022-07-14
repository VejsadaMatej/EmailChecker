using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Email_Validator.Data.Entities;

namespace Email_Validator.Data.Context
{
    public class EmailCheckerContext : DbContext
    {
        public EmailCheckerContext (DbContextOptions<EmailCheckerContext> options)
            : base(options)
        {
        }

        public DbSet<Email_Validator.Data.Entities.EmailRecord> EmailRecord { get; set; } = default!;
    }
}
