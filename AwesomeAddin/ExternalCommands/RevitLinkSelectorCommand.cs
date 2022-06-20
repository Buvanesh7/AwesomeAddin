using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AwesomeAddin.Models;
using AwesomeAddin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeAddin.ExternalCommands
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class RevitLinkSelectorCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                var doc = commandData.Application.ActiveUIDocument.Document;

                List<Document> rvtLinkDocs = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).
                    OfType<RevitLinkInstance>().Select(x => x.GetLinkDocument()).ToList();

                Document firstDoc = rvtLinkDocs.FirstOrDefault();

                var rvtLinkNames = rvtLinkDocs.Select(x => x.Title).ToList();

                var mainWindow = new RevitLinkSelectorWindow(rvtLinkNames);
                mainWindow.ShowDialog();

                if (mainWindow.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return Result.Cancelled;

                var selectedRvtLinkNames = RevitLinkSelectorModel.selectedRevitLinks;

                var selectedDocs = rvtLinkDocs.Where(x => selectedRvtLinkNames.Contains(x.Title)).ToList();

                var wallsCount = 0;

                foreach (var selectedDoc in selectedDocs)
                {
                    var walls = new FilteredElementCollector(selectedDoc).OfClass(typeof(Wall)).ToElements().Count;
                    wallsCount += walls;
                }

                TaskDialog.Show("Wall Count", wallsCount.ToString());

                return Result.Succeeded;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
    }
}
