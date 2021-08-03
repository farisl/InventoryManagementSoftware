using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class UserNotification
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }

        public virtual IdentityUser<int> User { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
