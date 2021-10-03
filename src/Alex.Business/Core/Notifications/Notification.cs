using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Core.Notifications {
    public class Notification {
        public Notification(string message) {
            Message = message;
        }

        string Message { get; set;
        }
    }
}
