using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order
{
    public partial class Form1 : Form

    {
        //General Declaration: Global variables
        clsProduct Pro = new clsProduct();

        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            txtNEW.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsConnection.con.ConnectionString = "Data Source = DESKTOP-VC57OT1\\SQL2004; Initial Catalog = DBOrder_Mgt;" +
            "Integrated Security=true";

            try
            {
                clsConnection.con.Open();
                MessageBox.Show("Connection Was Successfull...!");
                dgvProduct.DataSource = Pro.GetData();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Was Not Successfull...!");
                throw;
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = dgvProduct.CurrentRow.Cells["Code"].Value.ToString();
            txtProName.Text = dgvProduct.CurrentRow.Cells["ProName"].Value.ToString();
            txtQty.Text = dgvProduct.CurrentRow.Cells["Qty"].Value.ToString();
            txtPrice.Text = dgvProduct.CurrentRow.Cells["Price"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Pro.Code = Convert.ToInt16(txtCode.Text);
            Pro.ProName = txtProName.Text;
            Pro.Qty = Convert.ToInt16(txtQty.Text);
            Pro.Price = Convert.ToDouble(txtPrice.Text);
            if (Pro.Insert() == true)
            {
                dgvProduct.DataSource = Pro.GetData();
                MessageBox.Show("Insert Sucessfull...!", "SAVE DATA");
            }
            else
            {
                MessageBox.Show("Insert  Unsucessfull...!", "SAVE DATA");
            }
            btnSave.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Pro.Code = Convert.ToInt16(txtCode.Text);
            Pro.ProName = txtProName.Text;
            Pro.Qty = Convert.ToInt16(txtQty.Text);
            Pro.Price = Convert.ToDouble(txtPrice.Text);
            if (Pro.Update() == true)
            {
                dgvProduct.DataSource = Pro.GetData();
                MessageBox.Show("Data was updated...!");
            }
            else
            {
                MessageBox.Show("Data was not updated...!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = Pro.Search(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = Pro.GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Pro.Code = Convert.ToInt16(txtCode.Text);
            if (MessageBox.Show("Do you want to delete this record", "Delete Recore",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Pro.Delete() == true)
                {
                    dgvProduct.DataSource = Pro.GetData();
                    MessageBox.Show("Data was deleted...!");
                }
                else
                {
                    MessageBox.Show("Data was not deleted...!");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtCode.Focus();
            txtProName.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            btnSave.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Only confirm if you want to exit", "Exit Program",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
