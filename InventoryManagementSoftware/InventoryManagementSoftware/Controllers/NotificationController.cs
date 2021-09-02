using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class NotificationController : BaseCRUDController<Model.Notification, Database.Notification, NotificationInsertRequest, object, NotificationSearcgObject>
    {
        public NotificationController(INotificationService service) : base(service)
        {
        }

        [NonAction]
        public override Notification Update(int id, object request)
        {
            return base.Update(id, request);
        }

    }
}
