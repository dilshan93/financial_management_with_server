using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace financial_management.Global
{
    internal class Status
    {

        private static bool ServerConnected = false;
        private static bool WatingSync = false;
        private static int CatId = 0;
        private static int TransId = 0;
        public static XElement LoadPath = XElement.Load("../../Backup.xml");
        public static string SavePath = "../../Backup.xml";
        public static string endpointURL = Properties.Settings.Default.ServiceURLLocal;



        public static void SetServerStatus(bool status)
        {
            ServerConnected = status;
        }

        public static bool readyToConnect()
        {
            return !WatingSync;
        }

        public static void SetWatingSync(bool watingSync)
        {
            WatingSync = watingSync;
        }

        public static bool IsConnected()
        {
            if (ServerConnected && !WatingSync)
            {
                return true;
            }

            return false;
        }

        public static int GetCategoryId()
        {
            CatId = CatId - 1;
            return CatId;
        }

        public static int GetTransactionId()
        {
            TransId = TransId - 1;
            return TransId;
        }

    }
}
