using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class UserNotification
    {
        public int Id { get; set; }
        public bool IsRead { get; set; } = false;
        public int NotificationId { get; set; }
        public int UserId { get; set; }

        public virtual Notification Notification { get; set; }
        public string NotificationText => Notification?.Text;
        public string NotificationDate => Notification?.DateTime.ToString("yyyy-MM-dd HH:mm");
    }
}
