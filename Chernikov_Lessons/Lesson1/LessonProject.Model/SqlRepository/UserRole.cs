using System.Linq;

namespace LessonProject.Model
{
    public partial class SqlRepository
    {
        public IQueryable<UserRole> UserRoles => Db.UserRoles;

        public bool CreateUserRole(UserRole instance) {
            if (instance.ID != 0) {
                return false;
            }
            Db.UserRoles.InsertOnSubmit(instance);
            Db.UserRoles.Context.SubmitChanges();
            return true;
        }

        public bool UpdateUserRole(UserRole instance) {
            var cache = Db.UserRoles.FirstOrDefault(p => p.ID == instance.ID);
            if (cache == null) {
                return false;
            }
            //TODO : Update fields for UserRole
            Db.UserRoles.Context.SubmitChanges();
            return true;
        }

        public bool RemoveUserRole(int idUserRole) {
            var instance = Db.UserRoles.FirstOrDefault(p => p.ID == idUserRole);
            if (instance == null) {
                return false;
            }
            Db.UserRoles.DeleteOnSubmit(instance);
            Db.UserRoles.Context.SubmitChanges();
            return true;
        }
    }
}