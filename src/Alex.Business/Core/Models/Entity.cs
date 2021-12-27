using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Core.Models {
    public abstract class Entity {
        protected Entity() {
            Id = Guid.NewGuid();
            Created_at = new DateTime();
            Updated_at = new DateTime();
            Deleted_at = new DateTime();
        }
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Crated_at { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}
