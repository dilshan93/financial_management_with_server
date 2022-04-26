using financial_management.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace financial_management.XMLBackup
{
    public class SyncService
    {

        public void IsWatingSyncTrue()
        {
            var backupXML = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            if (backupXML.Descendants("SyncState").Count() > 0)
            {
                Status.SetWatingSync(true);
            }
            else
            {
                Status.SetWatingSync(false);
            }
        }

        public void DeleteSyncState()
        {
            var backupXML = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            backupXML.Descendants("SyncState").Remove();
            backupXML.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            Status.SetWatingSync(false);
        }

        public void SaveWatingSyncState()
        {
            var xmlDoc = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            xmlDoc.Add(new XElement("SyncState", new XAttribute("PendingData", true)));
            xmlDoc.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            Status.SetWatingSync(true);
        }
    }
}
