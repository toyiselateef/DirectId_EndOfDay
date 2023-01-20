using System;

namespace Domain.Common
{

    public class AuditableBaseEntity
    {
        public virtual int Id { get;  }

        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }

}
