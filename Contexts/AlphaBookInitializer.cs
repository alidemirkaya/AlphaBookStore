using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Entities
{
    public class AlphaBookInitializer: CreateDatabaseIfNotExists<AlphaBookContext>
    {
        protected override void Seed(AlphaBookContext context)
        {
            base.Seed(context);
        }
    }
}