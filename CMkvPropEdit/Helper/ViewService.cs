using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CMkvPropEdit.Helper
{
    static class ViewService
    {
        internal static IEnumerable<Control> GetAllControls(Control control, params Type[] types)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, types))
                                      .Concat(controls)
                                      .Where(c => types.Contains(c.GetType()));
        }
    }
}
