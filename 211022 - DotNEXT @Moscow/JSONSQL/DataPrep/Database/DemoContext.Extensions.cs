using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep.Database
{
    public partial class DemoContext
    {
        private readonly string _connStr;
        public DemoContext(string connStr)
        {
            this._connStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connStr,
                        opts=>
                        {
                            opts.CommandTimeout(3600);
                        });
            }
        }
    }
}
