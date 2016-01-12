using Lesson1;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (PreStartApp), "Start")]

namespace Lesson1
{
    public class PreStartApp
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод запускается один раз перед стартом приложения        
        /// </summary>
        public static void Start() {
            logger.Info("Application PreStart");
        }
    }
}