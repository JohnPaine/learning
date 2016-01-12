using System;

namespace LessonProject.Model
{
    public partial class User
    {
        public static string GetActivateUrl() {
            return Guid.NewGuid().ToString("N");
        }
    }
}