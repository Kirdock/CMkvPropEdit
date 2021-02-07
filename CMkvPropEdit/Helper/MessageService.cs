using System.Windows.Forms;

namespace CMkvPropEdit.Helper
{
    static class MessageService
    {
        internal static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
