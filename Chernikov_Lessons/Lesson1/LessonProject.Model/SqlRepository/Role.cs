using System.Linq;

namespace LessonProject.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Role> Roles => Db.Roles;

        public bool CreateRole(Role instance) {
            if (instance.ID != 0) {
                return false;
            }
            Db.Roles.InsertOnSubmit(instance);
            Db.Roles.Context.SubmitChanges();
            return true;
        }

        public bool UpdateRole(Role instance) {
            var cache = Db.Roles.FirstOrDefault(p => p.ID == instance.ID);
            if (cache == null) {
                return false;
            }
            cache.Name = instance.Name;
            cache.Code = instance.Code;

            Db.Roles.Context.SubmitChanges();
            return true;
        }

        public bool RemoveRole(int idRole) {
            var instance = Db.Roles.FirstOrDefault(p => p.ID == idRole);
            if (instance == null) {
                return false;
            }
            Db.Roles.DeleteOnSubmit(instance);
            Db.Roles.Context.SubmitChanges();
            return true;
        }
    }
}