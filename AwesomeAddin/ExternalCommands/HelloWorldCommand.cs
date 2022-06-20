using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.Attributes;

namespace AwesomeAddin
{
    //IExternalCommand
    //IExternalApplication
    [Transaction(TransactionMode.Manual)]
    public class HelloWorldCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                var uidoc = commandData.Application.ActiveUIDocument;
                var doc = uidoc.Document;

                var mainWindow = new HelloWorldWindow();
                mainWindow.ShowDialog();

                if (mainWindow.DialogResult  != System.Windows.Forms.DialogResult.OK)
                {
                    return Result.Cancelled;
                }

                string name = HelloWorldModel.NameValue;
                int age = HelloWorldModel.AgeValue;
                double weight = HelloWorldModel.WeightValue;

                //var str = name + "\n" + age.ToString() + "\n" + weight.ToString();

                //TaskDialog.Show("Data", str);

                var allWalls = new FilteredElementCollector(doc).OfClass(typeof(Wall)).ToElements();

                using var t = new Transaction(doc, "Set Param values");
                t.Start();

                foreach (var wall in allWalls)
                {
                    wall.LookupParameter("Mark").Set(name);
                }

                t.Commit();

                return Result.Succeeded;
            }
            catch(Exception ex)
            {
                TaskDialog.Show("Error", ex.Message);
                return Result.Failed;
            }

        }
    }
}
