using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Maintenance_UC : UserControl
    {
        private int clickedRowIndex;
        String maintenanceTImeSchedule = "";
        public Maintenance_UC()
        {
            InitializeComponent();
        }

        private void Maintenance_UC_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                int rowIndex = gridMaintenance.Rows.Add("" + i);
                gridMaintenance.Rows[rowIndex].Cells[1].Value = "Not Set";
                gridMaintenance.Rows[rowIndex].Cells[2].Value = "N/A";
                gridMaintenance.Rows[rowIndex].Cells[3].Value = "N/A";
            }

            cbMaintenanceStatus.Items.Add("Not Set");
            cbMaintenanceStatus.Items.Add("Scheduled");
            cbMaintenanceStatus.Items.Add("On Going");
        }

        private void gridMaintenance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
        
                clickedRowIndex = e.RowIndex;

                DataGridViewRow row = gridMaintenance.Rows[e.RowIndex];
                txtRoomNumber.Text = row.Cells[0].Value.ToString();
            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex >= 0)
            {
                if(cbMaintenanceStatus.Text != "")
                {
                    MessageBox.Show("Maintenance Successfully Scheduled");
                    gridMaintenance.Rows[clickedRowIndex].Cells[1].Value = cbMaintenanceStatus.Text;
                    gridMaintenance.Rows[clickedRowIndex].Cells[2].Value = dateTimePicker.Text;
                    gridMaintenance.Rows[clickedRowIndex].Cells[3].Value = maintenanceTImeSchedule;
                }
            }
            else
            {
                MessageBox.Show("No row has been clicked yet.");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tmrSetTime.Start();
        }


        bool timeSetExpanded = true;
        private void tmrSetTime_Tick(object sender, EventArgs e)
        {
            if (timeSetExpanded)
            {
                tmrSetTime.Start();
                panelSetTime.Height += 10;
                if(panelSetTime.Height >= 198)
                {
                    tmrSetTime.Stop();
                    timeSetExpanded = false;
                }
            } else
            {
                tmrSetTime.Start();
                panelSetTime.Height -= 10;
                if(panelSetTime.Height <= 0)
                {
                    tmrSetTime.Stop();
                    timeSetExpanded = true;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void btn7am_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "7:00 AM";
        }

        private void btn9am_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "9:00 AM";
        }

        private void btn10am_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "10:00 AM";
        }

        private void btn8am_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "8:00 AM";
        }

        private void btn11am_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "11:00 AM";
        }

        private void btn12pm_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "12:00 PM";
        }

        private void btn1pm_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "1:00 PM";
        }

        private void btn2pm_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "2:00 PM";
        }

        private void btn3pm_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "3:00 PM";
        }

        private void btn4pm_Click(object sender, EventArgs e)
        {
            maintenanceTImeSchedule = "4:00 PM";
        }
    }

 
}
