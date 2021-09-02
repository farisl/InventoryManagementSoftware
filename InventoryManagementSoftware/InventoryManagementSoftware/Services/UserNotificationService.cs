using AutoMapper;
using eProdaja.Filters;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class UserNotificationService : BaseCRUDService<Model.UserNotification, Database.UserNotification, UserNotificationInsertRequest, UserNotificationUpdateRequest, UserNotificationSearchObject>
        , IUserNotificationService
    {
        public UserNotificationService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.UserNotification> Get(UserNotificationSearchObject search)
        {
            var list = _context.UserNotifications
                .Where(x => !x.IsRead)
                .Include(x => x.Notification)
                .AsQueryable();

            if (search?.UserId != null)
                list = list.Where(x => x.UserId == search.UserId);

            return _mapper.Map<List<Model.UserNotification>>(list.ToList());
        }

        public override Model.UserNotification Update(int id, UserNotificationUpdateRequest request)
        {
            var entity = _context.UserNotifications.Find(id);

            if (entity == null)
                throw new UserException("Notification for this user does not exist.");

            entity.IsRead = request.IsRead;
            _context.SaveChanges();

            return _mapper.Map<Model.UserNotification>(entity);
        }

    }
}
