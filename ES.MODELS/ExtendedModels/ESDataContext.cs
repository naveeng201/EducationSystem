using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    public partial class ESDataContext
    {
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            //for now considering User Id as 1 always
            var currentUserId = 1;
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((IBaseEntity)entity.Entity).CreatedDate = DateTime.Now;
                    ((IBaseEntity)entity.Entity).CreatedBy = currentUserId;
                }

                ((IBaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
                ((IBaseEntity)entity.Entity).ModifiedBy = currentUserId;
            }
            return base.SaveChanges();
        }
    }
}
