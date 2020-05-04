using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVR.Core.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<SemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SemContext";
        }

        protected override void Seed(SemContext context)
        {
            //base.Seed(context);
        }
    }
}
