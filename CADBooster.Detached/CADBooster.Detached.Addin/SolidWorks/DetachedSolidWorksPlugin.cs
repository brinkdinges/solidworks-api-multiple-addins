using System.Reflection.Emit;
using AngelSix.SolidDna.SolidWorks.Integration.Base;
using CADBooster.Detached.Addin.Windows;
using CADBooster.Detached.Logging;

namespace CADBooster.Detached.Addin.SolidWorks
{
    public class DetachedSolidWorksPlugin : SolidPlugIn
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(DetachedSolidWorksPlugin));

        public override string AddInTitle => "Detached add-in";

        public override string AddInDescription => "The very detached add-in";
        
        public override void ConnectedToSolidWorks()
        {
            Log.Info("Detached add-in connected to SOLIDWORKS", nameof(ConnectedToSolidWorks));
          
            ShowWindow.TaskPane();
        }
        
        public override void DisconnectedFromSolidWorks()
        {
            Log.Info("Detached add-in closing down", nameof(DisconnectedFromSolidWorks));
        }
    }
}

