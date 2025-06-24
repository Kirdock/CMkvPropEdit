using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMkvPropEdit.CustomControls
{
    public class NumericUpDownColumn : DataGridViewColumn
    {
        public NumericUpDownColumn()
            : base(new NumericUpDownCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class NumericUpDownCell : DataGridViewTextBoxCell
    {
        private readonly decimal min;
        private readonly decimal max;

        public NumericUpDownCell()
            : base()
        {
            Style.Format = "F0";
        }
        public NumericUpDownCell(decimal min, decimal max)
            : base()
        {
            this.min = min;
            this.max = max;
            Style.Format = "F0";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
            ctl.Minimum = min;
            ctl.Maximum = max;
            ctl.Value = Convert.ToDecimal(Value);
        }

        public override Type EditType
        {
            get { return typeof(NumericUpDownEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(decimal); }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }

        public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
        {
            private DataGridView dataGridViewControl;
            private bool valueIsChanged = false;
            private int rowIndexNum;

            public NumericUpDownEditingControl()
                : base()
            {
                DecimalPlaces = 0;
            }

            public DataGridView EditingControlDataGridView
            {
                get { return dataGridViewControl; }
                set { dataGridViewControl = value; }
            }

            public object EditingControlFormattedValue
            {
                get { return Value.ToString("F0"); }
                set { Value = decimal.Parse(value.ToString()); }
            }
            public int EditingControlRowIndex
            {
                get { return rowIndexNum; }
                set { rowIndexNum = value; }
            }
            public bool EditingControlValueChanged
            {
                get { return valueIsChanged; }
                set { valueIsChanged = value; }
            }

            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }

            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                Font = dataGridViewCellStyle.Font;
                ForeColor = dataGridViewCellStyle.ForeColor;
                BackColor = dataGridViewCellStyle.BackColor;
            }

            public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            {
                return (keyData == Keys.Left || keyData == Keys.Right ||
                    keyData == Keys.Up || keyData == Keys.Down ||
                    keyData == Keys.Home || keyData == Keys.End ||
                    keyData == Keys.PageDown || keyData == Keys.PageUp);
            }

            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return Value.ToString();
            }

            public void PrepareEditingControlForEdit(bool selectAll)
            {
            }

            protected override void OnValueChanged(EventArgs e)
            {
                valueIsChanged = true;
                EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(e);
            }
        }
    }
}