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
    public class UserNotificationController : BaseCRUDController<Model.UserNotification, Database.UserNotification, UserNotificationInsertRequest, UserNotificationUpdateRequest, UserNotificationSearchObject>
    {
        public UserNotificationController(IUserNotificationService service) : base(service)
        {
        }
    }
}
