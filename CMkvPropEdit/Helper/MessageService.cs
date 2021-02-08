using System.Windows.Forms;

namespace CMkvPropEdit.Helper
{
    static class MessageService
    {
        internal static void ShowInformation(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        internal static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        internal static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal static DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }
    }
}
