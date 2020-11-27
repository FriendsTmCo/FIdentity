using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class SelectedRoleServices : ISelectedRoleRepository, IDisposable
    {
        private readonly IdentityContext _db;
        private readonly IRoleRepository _role;

        public SelectedRoleServices(IdentityContext db,RoleServices role)
        {
            _role = role;
            _db = db;
        }

        public async Task<bool> Delete(UserSelectedRoles selectedRoles)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserSelectedRoles.Remove(selectedRoles);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int selectedId)
        {
            return await Task.Run(() => Delete(GetById(selectedId).Result));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<IEnumerable<UserSelectedRoles>> GetAll()
        {
            return await Task.Run(() => _db.UserSelectedRoles.ToListAsync());
        }

        public async Task<IEnumerable<UserSelectedRoles>> GetAll(Expression<Func<UserSelectedRoles, bool>> where = null)
        {
            return await Task.Run(() =>
            {
                IQueryable<UserSelectedRoles> _selected = _db.UserSelectedRoles;
                if (where != null)
                {
                    _selected = _selected.Where(where);
                }
                return _selected.ToListAsync();
            });
        }

        public async Task<UserSelectedRoles> GetById(int selectedId)
        {
            return await Task.Run(() => _db.UserSelectedRoles.Find(selectedId));
        }

        public async Task<IEnumerable<UsersRoles>> GetRolesByUserId(int userId)
        {
            var lstRoles = new List<UsersRoles>();

            return await Task.Run(() =>
            {

                var selecteds = _db.UserSelectedRoles.Where(s => s.UserId == userId).ToList();
                if (selecteds != null)
                {
                    foreach (var item in selecteds)
                    {
                        lstRoles.Add(_role.GetById(item.RoleId).Result);
                    }
                    return lstRoles;
                }

                return null;
            });
        }

        public async Task<bool> Insert(UserSelectedRoles selectedRoles)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserSelectedRoles.Add(selectedRoles);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(UserSelectedRoles selectedRoles)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserSelectedRoles.Update(selectedRoles);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
