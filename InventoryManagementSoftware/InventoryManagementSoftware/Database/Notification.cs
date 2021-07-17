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
        public int IdentityUserId { get; set; }

        public virtual AspNetUser IdentityUser { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
