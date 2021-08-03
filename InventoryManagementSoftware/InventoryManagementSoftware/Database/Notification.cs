using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Notification
    {
        public Notification()
        {
            UserNotifications = new HashSet<UserNotification>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        public virtual IdentityUser<int> User { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
