using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using System.Data.SqlClient;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        Business_Logic BL = new Business_Logic();
        public Form1()
        {
            InitializeComponent();
        }

        private void SetDefaults()
        {
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Price.Text = "";
        }
        private void DisableFields()
        {
            // Disabling Insert Button
            btn_Insert.Enabled = false;
            // Disabling ID TextBox
            txt_ID.Enabled = false;
        }
        private void EnableFields()
        {
            // Disabling Insert Button
            btn_Insert.Enabled = true;
            // Disabling ID TextBox
            txt_ID.Enabled = true;
        }
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Item i = new Item();
                i.ID = int.Parse(txt_ID.Text);
                i.Name = txt_Name.Text.ToString();
                i.Price = int.Parse(txt_Price.Text);
                BL.InsertItem(i);
                MessageBox.Show("Item Inserted Successfully!");
                SetDefaults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Setting Default Values
            SetDefaults();
            // Enabling Fields
            EnableFields();
        }

        private void btn_Fetch_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(txt_ID.Text);
                SqlDataReader sdr = BL.ViewByID(ID);
                // Reading Record
                if (sdr.Read())
                {
                    txt_ID.Text = sdr[0].ToString();
                    txt_Name.Text = sdr[1].ToString();
                    txt_Price.Text = sdr[2].ToString();
                    DisableFields();
                }
                else
                {
                    MessageBox.Show("Record Not Found");
                }
                // Closing Reader & Connection
                sdr.Close();
                BL.db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(txt_ID.Text);
                BL.DeleteItem(ID);
                MessageBox.Show("Item Deleted Successfully");
                SetDefaults();
                EnableFields();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                //EnableFields();
                Item i = new Item();
                i.ID = int.Parse(txt_ID.Text);
                i.Name = txt_Name.Text.ToString();
                i.Price = int.Parse(txt_Price.Text);
                BL.UpdateItem(i);
                MessageBox.Show("Item Updated Successfully");
                SetDefaults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
