using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeAddin.Updaters
{
    public class CableTrayChangeUpdater : IUpdater
    {
        UpdaterId _updaterId;

        public CableTrayChangeUpdater(AddInId addIn)
        {
            _updaterId = new UpdaterId(addIn, Guid.Parse("a1b9d397-616c-4726-8a09-66879f211e92"));
        }
        public void Execute(UpdaterData data)
        {
            var doc = data.GetDocument();
            //doc.Application.Username;

            var modified = data.GetModifiedElementIds();

            foreach (var modifiedId in modified)
            {
                var ele = doc.GetElement(modifiedId);
                var str = ele.Name + "\n" + ele.Id.ToString();
                TaskDialog.Show("Message", str);
            }
            
        }

        public string GetAdditionalInformation()
        {
            return "It is an updater";
        }

        public ChangePriority GetChangePriority()
        {
            return ChangePriority.MEPSystems;
        }

        public UpdaterId GetUpdaterId()
        {
            return _updaterId;
        }

        public string GetUpdaterName()
        {
            return "CableTrayChangeUpdater";
        }
    }
}
