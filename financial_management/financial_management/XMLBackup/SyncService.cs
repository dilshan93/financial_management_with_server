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
            var backupXML = Status.LoadPath;
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
            var backupXML = Status.LoadPath;
            backupXML.Descendants("SyncState").Remove();
            backupXML.Save(Status.SavePath);
            Status.SetWatingSync(false);
        }

        public void SaveWatingSyncState()
        {
            var xmlDoc = Status.LoadPath;
            xmlDoc.Add(new XElement("SyncState", new XAttribute("PendingData", true)));
            xmlDoc.Save(Status.SavePath);
            Status.SetWatingSync(true);
        }
    }
}
