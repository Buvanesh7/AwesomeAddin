using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeAddin.Models
{
    public static class WallCreationModel
    {
        public static Level BaseLevelValue { get; set; }
        public static Level TopLevelValue { get; set; }
        public static WallType WallTypeValue { get; set; }
        public static bool StructureValue { get; set; }
        public static double BaseOffsetValue { get; set; }
    }
}
