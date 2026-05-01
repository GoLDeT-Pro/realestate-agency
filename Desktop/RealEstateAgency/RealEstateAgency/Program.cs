using System;
using System.Windows.Forms;
using RealEstateAgency.Forms;

namespace RealEstateAgency
{
    static class Program
    {
        public static DatabaseService DbService;
        public static UserService UserService;
        public static PropertyService PropertyService;
        public static DealService DealService;
        public static ViewingRequestService ViewingRequestService;
        public static DictionaryService DictionaryService;
        public static User CurrentUser;

        [STAThread]
        static void Main()
        {
            DbService = new DatabaseService("localhost", "real_estate_agency", "root", "");
            UserService = new UserService(DbService);
            PropertyService = new PropertyService(DbService);
            DealService = new DealService(DbService);
            ViewingRequestService = new ViewingRequestService(DbService);
            DictionaryService = new DictionaryService(DbService);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}