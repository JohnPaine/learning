using System;
using System.Linq;

namespace LessonProject.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users => Db.Users;

        public bool CreateUser(User instance) {
            if (instance.ID != 0) {
                return false;
            }
            instance.AddedDate = DateTime.Now;
            instance.ActivatedLink = User.GetActivateUrl();

            Db.Users.InsertOnSubmit(instance);
            Db.Users.Context.SubmitChanges();
            return true;
        }

        public bool UpdateUser(User instance) {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache == null) {
                return false;
            }
            cache.AvatarPath = instance.AvatarPath;
            cache.Email = instance.Email;

            Db.Users.Context.SubmitChanges();
            return true;
        }

        public bool RemoveUser(int idUser) {
            var instance = Db.Users.FirstOrDefault(p => p.ID == idUser);
            if (instance == null) {
                return false;
            }
            Db.Users.DeleteOnSubmit(instance);
            Db.Users.Context.SubmitChanges();
            return true;
        }
    }
}