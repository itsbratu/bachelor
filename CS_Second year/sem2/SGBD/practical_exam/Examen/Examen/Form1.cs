using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=IONUWORKSPACE\SQLEXPRESS;Initial Catalog=Problema1;Integrated Security=true";

        DataSet dataSet = new DataSet();
        SqlDataAdapter cofetariiAdapter = new SqlDataAdapter();
        SqlDataAdapter brioseAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fetchParent();
        }

        private void fetchParent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    cofetariiAdapter.SelectCommand = new SqlCommand("select * from Cofetarii", connection);
                    cofetariiAdapter.Fill(dataSet, "Cofetarii");

                    dataGridCofetarii.DataSource = dataSet.Tables["Cofetarii"];
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void fetchBriose(int cofetarieId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    brioseAdapter.SelectCommand = new SqlCommand("select * from Briose where cod_cofetarie = @cofetarieId", connection);
                    brioseAdapter.SelectCommand.Parameters.AddWithValue("@cofetarieId", cofetarieId);

                    if (dataSet.Tables["Briose"] != null)
                    {
                        dataSet.Tables["Briose"].Clear();
                    }

                    brioseAdapter.Fill(dataSet, "Briose");

                    dataGridBriose.DataSource = dataSet.Tables["Briose"];
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    brioseAdapter.SelectCommand = new SqlCommand("select * from Briose", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(brioseAdapter);
                    brioseAdapter.InsertCommand = builder.GetInsertCommand();
                    brioseAdapter.UpdateCommand = builder.GetUpdateCommand();
                    brioseAdapter.DeleteCommand = builder.GetDeleteCommand();

                    brioseAdapter.Update(dataSet, "Briose");

                    dataSet.Tables["Briose"].Clear();
                    brioseAdapter.Fill(dataSet, "Briose");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dataGridCofetarii_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView != null && gridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gridView.SelectedRows[0];
                int cofetarieId = (int)row.Cells[0].Value;
                if (row != null)
                {
                    fetchBriose(cofetarieId);
                }
            }
        }
    }
}
