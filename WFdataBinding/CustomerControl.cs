using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFdataBinding
{
    // This class implements a simple user control
    // that demonstrates how to apply the propertyNameChanged pattern.
    [ComplexBindingProperties("DataSource", "DataMember")]
    public class CustomerControl : UserControl
    {
        private DataGridView dataGridView1;
        private Label label1;
        private DateTime lastUpdate = DateTime.Now;

        public EventHandler DataSourceChanged;

        public object DataSource
        {
            get
            {
                return this.dataGridView1.DataSource;
            }
            set
            {
                if (DataSource != value)
                {
                    this.dataGridView1.DataSource = value;
                    OnDataSourceChanged();
                }
            }
        }

        public string DataMember
        {
            get { return this.dataGridView1.DataMember; }

            set { this.dataGridView1.DataMember = value; }
        }

        private void OnDataSourceChanged()
        {
            if (DataSourceChanged != null)
            {
                DataSourceChanged(this, new EventArgs());
            }
        }

        public CustomerControl()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
               System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dataGridView1.Location = new System.Drawing.Point(100, 100);
            this.dataGridView1.Size = new System.Drawing.Size(500, 500);

            this.dataGridView1.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer List:";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Size = new System.Drawing.Size(450, 250);
        }
    }
}
