using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeAddin.ExternalCommands
{
    [TransactionAttribute(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class DimensionGridsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                var uidoc = commandData.Application.ActiveUIDocument;
                var doc = uidoc.Document;

                var allGrids = new FilteredElementCollector(doc).OfClass(typeof(Grid)).OfType<Grid>().ToList();

                var refArray = new ReferenceArray();

                var spList = new List<XYZ>();

                foreach (var gr in allGrids)
                {
                    spList.Add(gr.Curve.GetEndPoint(0));
                    var grRef = Reference.ParseFromStableRepresentation(doc, gr.UniqueId);
                    refArray.Append(grRef);
                }

                using var trans = new Transaction(doc, "Creating Dimensions");
                trans.Start();

                var accView = doc.ActiveView;
                var tempLine = Line.CreateBound(spList.ElementAt(0), spList.ElementAt(1));
                var newDim = doc.Create.NewDimension(accView, tempLine, refArray);

                trans.Commit();

                return Result.Succeeded;
            }
            catch(Exception ex)
            {
                TaskDialog.Show("Error Message", ex.Message);
                return Result.Failed;
            }
            
        }
    }
}
