using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class NotificationService : BaseCRUDService<Model.Notification, Database.Notification, NotificationInsertRequest, object, NotificationSearcgObject>
        , INotificationService
    {
        private readonly IUserNotificationService _userNotificationService;

        public NotificationService(IMSContext context, IMapper mapper, IUserNotificationService userNotificationService) : base(context, mapper)
        {
            _userNotificationService = userNotificationService;
        }

        public override Model.Notification Insert(NotificationInsertRequest request)
        {
            Database.Notification notification = _mapper.Map<Database.Notification>(request);
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            foreach(var id in request.UserIds)
            {
                _userNotificationService.Insert(new UserNotificationInsertRequest
                {
                    NotificationId = notification.Id,
                    UserId = id,
                    IsRead = false
                });
            }

            return _mapper.Map<Model.Notification>(notification);
        }

    }
}
