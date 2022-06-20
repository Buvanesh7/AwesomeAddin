using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using AwesomeAddin.Models;
using AwesomeAddin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeAddin.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    public class WallCreationCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                var uidoc = commandData.Application.ActiveUIDocument;
                var doc = uidoc.Document;

                var allLevels = new FilteredElementCollector(doc).OfClass(typeof(Level))
                    .OfType<Level>().OrderBy(x => x.Name).ToList();
                
                var allWallTypes = new FilteredElementCollector(doc).OfClass(typeof(WallType))
                    .OfType<WallType>().OrderBy(x => x.Name).ToList();

                var mainWindow = new WallCreationWindow(allLevels, allWallTypes);
                mainWindow.ShowDialog();

                if (mainWindow.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return Result.Cancelled;

                var baseLvl = WallCreationModel.BaseLevelValue;
                var topLvl = WallCreationModel.TopLevelValue;
                var wallType = WallCreationModel.WallTypeValue;

                var structural = WallCreationModel.StructureValue;
                var baseOff = WallCreationModel.BaseOffsetValue;

                var dlRef = uidoc.Selection.PickObject(ObjectType.Element);
                var dl = doc.GetElement(dlRef.ElementId);

                var locCurve = ((LocationCurve)dl.Location).Curve;

                using var t = new Transaction(doc, "Wall Creation");
                t.Start();

                var newWall = Wall.Create(doc, locCurve, baseLvl.Id, structural);

                newWall.ChangeTypeId(wallType.Id);
                newWall.LookupParameter("Top Constraint").Set(topLvl.Id);

                newWall.LookupParameter("Base Offset").Set(baseOff);

                t.Commit();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", ex.Message);
                return Result.Failed;
            }
        }
    }
}
