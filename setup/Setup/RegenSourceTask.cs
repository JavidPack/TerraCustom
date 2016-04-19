using System.Windows.Forms;

namespace Terraria.TerraCustom.Setup
{
    public class RegenSourceTask : CompositeTask
    {
        public RegenSourceTask(ITaskInterface taskInterface, params Task[] tasks) : base(taskInterface, tasks) { }

        public override bool StartupWarning() {
            return MessageBox.Show(
                    "Any changes in /src will be lost.\r\n",
                    "Ready for Setup", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                == DialogResult.OK;
        }
    }
}