using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class UserNotificationInsertRequest
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
