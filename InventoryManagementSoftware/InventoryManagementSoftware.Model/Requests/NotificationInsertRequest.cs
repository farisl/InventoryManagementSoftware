using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class NotificationInsertRequest
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        public List<int> UserIds = new List<int>();
    }
}
