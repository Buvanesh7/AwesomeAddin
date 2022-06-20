using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using AwesomeAddin.ExternalCommands;
using AwesomeAddin.Properties;
using AwesomeAddin.Updaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace AwesomeAddin
{
    public class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            //application.ControlledApplication.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(DisplayWelcomeMessage);
            //application.ControlledApplication.ElementTypeDuplicated += new EventHandler<ElementTypeDuplicatedEventArgs>(DoSomething);


            var cbUpdater = new CableTrayChangeUpdater(application.ActiveAddInId);
            UpdaterRegistry.RegisterUpdater(cbUpdater);

            var cbFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);

            UpdaterRegistry.AddTrigger(cbUpdater.GetUpdaterId(), cbFilter, Element.GetChangeTypeAny());


            var tabName = "Awesome";
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch { }

            var generalPannelName = "General";
            RibbonPanel generalPannel = null;

            var linkPannelName = "Revit Link";
            RibbonPanel linkPannel = null;

            var allPannels = application.GetRibbonPanels();
            var generalPannelCheck = allPannels.Where(x => x.Name == generalPannelName).FirstOrDefault();
            var linkPannelCheck = allPannels.Where(x => x.Name == linkPannelName).FirstOrDefault();

            if (generalPannelCheck == null)
            {
                generalPannel = application.CreateRibbonPanel(tabName, generalPannelName);
                generalPannel.AddSeparator();
            }
            else
                generalPannel = generalPannelCheck;

            if (linkPannelCheck == null)
            {
                linkPannel = application.CreateRibbonPanel(tabName, linkPannelName);
                linkPannel.AddSeparator();
            }
            else
                linkPannel = linkPannelCheck;

            var path = Assembly.GetExecutingAssembly().Location;

            var helloWorldButtonData = new PushButtonData("HelloWorldButton", "Hello World", path, typeof(HelloWorldCommand).FullName);
            var helloWorldButton = generalPannel.AddItem(helloWorldButtonData) as PushButton;
            helloWorldButton.ToolTip = "Display Hello World";
            helloWorldButton.LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Resources.helloworld_32x32.GetHbitmap(),
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            helloWorldButton.Image = Imaging.CreateBitmapSourceFromHBitmap(Resources.helloworld_16x16.GetHbitmap(),
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            var dimensionButtonData = new PushButtonData("dimensionButtonData", "Dimension grids", path, typeof(DimensionGridsCommand).FullName);
            var dimensionButton = generalPannel.AddItem(dimensionButtonData) as PushButton;

            var wallCreationButtonData = new PushButtonData("wallCreationButtonData", "Create Wall", path, typeof(WallCreationCommand).FullName);
            var wallCreationButton = generalPannel.AddItem(wallCreationButtonData) as PushButton;

            var linksButtonData = new PushButtonData("linksButtonData", "Link Selector", path, typeof(RevitLinkSelectorCommand).FullName);
            var linksButton = linkPannel.AddItem(linksButtonData) as PushButton;


            return Result.Succeeded;
        }

        //private void DoSomething(object sender, ElementTypeDuplicatedEventArgs e)
        //{
        //    TaskDialog.Show("Message", "ElementDuplicated");
        //}

        //private void DisplayWelcomeMessage(object sender, DocumentOpenedEventArgs e)
        //{
        //    TaskDialog.Show("Welcome", "Model Opened");
        //}

        public Result OnShutdown(UIControlledApplication application)
        {
            var cbUpdater = new CableTrayChangeUpdater(application.ActiveAddInId);
            UpdaterRegistry.UnregisterUpdater(cbUpdater.GetUpdaterId());

            //application.ControlledApplication.DocumentOpened -= DisplayWelcomeMessage;
            //application.ControlledApplication.ElementTypeDuplicated -= DoSomething;

            return Result.Succeeded;
        }


    }
}
