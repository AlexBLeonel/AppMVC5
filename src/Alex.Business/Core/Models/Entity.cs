using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Core.Models {
    public abstract class Entity {
        protected Entity() {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
