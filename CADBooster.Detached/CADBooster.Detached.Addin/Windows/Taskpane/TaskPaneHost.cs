using System.Runtime.InteropServices;
using System.Windows.Forms;
using AngelSix.SolidDna.SolidWorks.Integration.Interfaces;

namespace CADBooster.Detached.Addin.Windows.TaskPane
{
    [ProgId(MyProgId)]
    public partial class TaskPaneHost : UserControl, ITaskpaneControl
    {
        #region Private members
        /// <summary>
        /// Our unique ProgId for SolidWorks to find and load us
        /// </summary>
        private const string MyProgId = "CADBooster.Detached";

        #endregion

        #region Public properties
        /// <summary>
        /// 
        /// </summary>
        public string ProgId => MyProgId;

        #endregion

        /// <summary>
        /// Not even necessary apparently
        /// </summary>
        public TaskPaneHost()
        {
            InitializeComponent();
        }
    }
}
