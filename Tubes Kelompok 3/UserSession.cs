using static Tubes_Kelompok_3.HalamanRegistrasiControl;

namespace Tubes_Kelompok_3
{
    public class UserSession
    {
        private static UserSession instance;

        //Singleton Instance
        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSession();
                }

                return instance;
            }
        }

        //Data User yang Sedang Login
        public User CurrentUser { get; set; }

        //Konstruktor : private
        private UserSession()
        {

        }
    }
}