using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_sgbd
{
    public partial class Form1 : Form
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshGridViewParent();
        }

        private void refreshGridViewParent()
        {
            try
            {
                /*Incarcare in tabelul parinte*/
                string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                string parentTable = ConfigurationManager.AppSettings["ParentTableName"];
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM " + parentTable, conn);
                dataAdapter.Fill(dataSet, parentTable);
                dataGridViewParent.DataSource = dataSet.Tables[parentTable];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshGridViewChild()
        {
            try
            {
                if (dataGridViewParent.SelectedCells.Count > 0)
                {
                    string pkParent = dataGridViewParent.CurrentRow.Cells[0].Value.ToString();
                    string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);
                    string childTable = ConfigurationManager.AppSettings["ChildTableName"];
                    string fkStatement = ConfigurationManager.AppSettings["pk_parent"];
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM " + childTable + " WHERE " + fkStatement, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@ID_Entity", pkParent);
                    if (dataSet.Tables[childTable] != null)
                        dataSet.Tables[childTable].Clear();
                    dataAdapter.Fill(dataSet, childTable);
                    dataGridViewChild.DataSource = dataSet.Tables[childTable];
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshGridViewChild();
            showChildTextBoxes();
        }

        private void showChildTextBoxes()
        {
            panelTextBoxes.Controls.Clear();
            List<string> childColumnsList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
            int textboxCount = Convert.ToInt32(ConfigurationManager.AppSettings["textbox_count"]);
            int locationTextBox = 50;
            int locationLabel = 50;
            int index = 1;
            while(index <= textboxCount)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();
                label.Location = new Point(0, locationLabel);
                textBox.Location = new Point(100, locationTextBox);
                textBox.Name = childColumnsList[index - 1];
                label.Text = ConfigurationManager.AppSettings["label" + index.ToString()];
                panelTextBoxes.Controls.Add(label);
                panelTextBoxes.Controls.Add(textBox);
                locationTextBox += label.Height;
                locationLabel += label.Height;
                index++;
            }
        }

        private void dataGridViewChild_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewChild.SelectedCells.Count > 0)
                {
                    string pkChild = dataGridViewChild.CurrentRow.Cells[0].Value.ToString();
                    string childTable = ConfigurationManager.AppSettings["ChildTableName"];
                    List<string> childColumnsList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                    string pkStatement = ConfigurationManager.AppSettings["pk_child"];
                    string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM " + childTable + " WHERE " + pkStatement, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@ID_Entity", pkChild);
                    if (dataSet.Tables[childTable] != null)
                        dataSet.Tables[childTable].Clear();
                    dataAdapter.Fill(dataSet, childTable);
                    foreach (string col in childColumnsList)
                    {
                        TextBox textBox = (TextBox)panelTextBoxes.Controls[col];
                        textBox.Text = dataSet.Tables[childTable].Rows[0][col].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sure you want to add this? ", "ADD -> Yes/No", MessageBoxButtons.YesNo);
                string childTable = ConfigurationManager.AppSettings["ChildTableName"];
                string insertedParametersNames = ConfigurationManager.AppSettings["InsertedParametersNames"];
                string childColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];
                List<string> childColumnsList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                if (dataGridViewParent.SelectedCells.Count > 0 && panelTextBoxes.Controls.Count > 0)
                {
                    string ID = dataGridViewParent.CurrentRow.Cells[0].Value.ToString();
                    SqlCommand cmd = new SqlCommand("INSERT INTO " + childTable + " (" + childColumnNames + ") VALUES (" + insertedParametersNames + ")", conn);
                    for (int i = 0; i < childColumnsList.Count -1; ++i)
                    {
                        TextBox textBox = (TextBox)panelTextBoxes.Controls[childColumnsList[i]];
                        cmd.Parameters.AddWithValue("@" + childColumnsList[i], textBox.Text);
                    }
                    cmd.Parameters.AddWithValue("@" + childColumnsList[childColumnsList.Count - 1], ID);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        refreshGridViewChild();
                        MessageBox.Show("Record inserted succesfully!");
                        conn.Close();
                    }
                    else
                    {
                        conn.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Plese select a parent record");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sure you want to delete this?", "DELETE -> Yes/No", MessageBoxButtons.YesNo);

                if (dataGridViewChild.SelectedCells.Count > 0 && dialogResult == DialogResult.Yes && panelTextBoxes.Controls.Count > 0)
                {
                    string pkChild = dataGridViewChild.CurrentRow.Cells[0].Value.ToString();
                    string childTable = ConfigurationManager.AppSettings["ChildTableName"];
                    string pkStatement = ConfigurationManager.AppSettings["pk_child"];
                    string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM " + childTable + " WHERE " + pkStatement, conn);
                    cmd.Parameters.AddWithValue("@ID_Entity", pkChild);
                    cmd.ExecuteNonQuery();
                    refreshGridViewChild();
                    MessageBox.Show("Deleted item succesfully!");
                    clearAllBoxes();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Plese select a child record");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sure you want to update this?", "UPDATE -> Yes/No", MessageBoxButtons.YesNo);

                if (dataGridViewChild.SelectedCells.Count > 0 && dialogResult == DialogResult.Yes && panelTextBoxes.Controls.Count > 0)
                {
                    string pkChild = dataGridViewChild.CurrentRow.Cells[0].Value.ToString();
                    string childTable = ConfigurationManager.AppSettings["ChildTableName"];
                    string childColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];
                    List<string> childColumnsList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                    string updateColumns = ConfigurationManager.AppSettings["UpdateColumns"];
                    string connectionString = ConfigurationManager.ConnectionStrings["CarSharing"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update " + childTable + " SET " + updateColumns, conn);
                    cmd.Parameters.AddWithValue("@ID_Entity", pkChild);
                    foreach (string column in childColumnsList)
                    {
                        TextBox textBox = (TextBox)panelTextBoxes.Controls[column];
                        cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                    }

                    cmd.ExecuteNonQuery();
                    refreshGridViewChild();
                    MessageBox.Show("Updated item succesfully!");
                    clearAllBoxes();
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Plese select a child record");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void clearAllBoxes()
        {
            List<string> childColumnsList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
            foreach (string column in childColumnsList)
            {
                TextBox textBox = (TextBox)panelTextBoxes.Controls[column];
                textBox.Clear();   
            }
        }
    }
}
