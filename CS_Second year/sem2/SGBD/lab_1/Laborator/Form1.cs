using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Laborator
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=IONUWORKSPACE\SQLEXPRESS;Initial Catalog=CarSharing;Integrated Security=true;";
        int childSelectedID = -1;
        int parentSelectedID = -1;
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void fetchParentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Soferi;", connection);
                    adapter.Fill(ds, "Soferi");
                    gridParents.DataSource = ds.Tables["Soferi"];
                    parentSelectedID = -1;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchChildData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Masini;", connection);
                    adapter.Fill(ds, "Masini");
                    gridChildren.DataSource = ds.Tables["Masini"];
                    childSelectedID = -1;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hideChildControls()
        {
            deleteChild.Visible = false;
            modChild.Visible = false;
            addChild.Visible = false;
            labelModMarca.Visible = false;
            labelModModel.Visible = false;
            labelModNumar.Visible = false;
            labelModSofer.Visible = false;
            labelAddMarca.Visible = false;
            labelAddModel.Visible = false;
            labelAddNumar.Visible = false;
            inputModMarca.Visible = false;
            inputModModel.Visible = false;
            inputModNumar.Visible = false;
            inputModSofer.Visible = false;
            inputAddMarca.Visible = false;
            inputAddModel.Visible = false;
            inputAddNumar.Visible = false;
            acceptModChild.Visible = false;
            acceptAddChild.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fetchParentData();
            fetchChildData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Tables["Soferi"].Clear();
            ds.Tables["Masini"].Clear();
            hideChildControls();
            fetchParentData();
            fetchChildData();
        }
        private void gridParinti_SelectionChanged(object sender, EventArgs e)
        {
            parentSelectedID = -1;
            childSelectedID = -1;
            DataGridView dgv = sender as DataGridView;
            hideChildControls();
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedEntry = dgv.SelectedRows[0];
                parentSelectedID = (int)selectedEntry.Cells[0].Value;
                if (parentSelectedID != -1)
                {
                    deleteChild.Visible = true;
                    modChild.Visible = true;
                    addChild.Visible = true;
                }
                if (selectedEntry != null)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            adapter.SelectCommand = new SqlCommand("SELECT * FROM Masini WHERE id_sofer=@selectedID;", connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@selectedID", selectedEntry.Cells[0].Value);
                            ds.Tables["Masini"].Clear();
                            adapter.Fill(ds, "Masini");
                            gridChildren.DataSource = ds.Tables["Masini"];
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void gridCopii_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedEntry = dgv.SelectedRows[0];
                if (selectedEntry != null) { 
                    childSelectedID = (int)selectedEntry.Cells[0].Value;
                    inputModMarca.Text = selectedEntry.Cells[1].Value.ToString();
                    inputModModel.Text = selectedEntry.Cells[2].Value.ToString();
                    inputModNumar.Text = selectedEntry.Cells[3].Value.ToString();
                }
            }
        }

        private void deleteChild_Click(object sender, EventArgs e)
        {
            if(childSelectedID != -1) 
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        adapter.DeleteCommand = new SqlCommand("DELETE FROM Masini WHERE id_masina=@childSelectedID;", connection);
                        adapter.DeleteCommand.Parameters.AddWithValue("@childSelectedID", childSelectedID);
                        adapter.DeleteCommand.ExecuteNonQuery();

                        adapter.SelectCommand = new SqlCommand("SELECT * FROM Masini WHERE id_sofer=@selectedID;", connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@selectedID", parentSelectedID);
                        ds.Tables["Masini"].Clear();
                        adapter.Fill(ds, "Masini");
                        gridChildren.DataSource = ds.Tables["Masini"];
                        MessageBox.Show("Masina a fost stersa cu succes!");

                        labelModMarca.Visible = !labelModMarca.Visible;
                        labelModModel.Visible = !labelModModel.Visible;
                        labelModNumar.Visible = !labelModNumar.Visible;
                        labelModSofer.Visible = !labelModSofer.Visible;
                        inputModMarca.Visible = !inputModMarca.Visible;
                        inputModModel.Visible = !inputModModel.Visible;
                        inputModNumar.Visible = !inputModNumar.Visible;
                        inputModSofer.Visible = !inputModSofer.Visible;
                        acceptModChild.Visible = !acceptModChild.Visible;
                        childSelectedID = -1;
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { MessageBox.Show("Alegeti o masina!"); }
        }

        private void modifyChild_Click(object sender, EventArgs e)
        {
            if (childSelectedID == -1) { MessageBox.Show("Alegeti o masina!"); }
            else
            {
                labelModMarca.Visible = !labelModMarca.Visible;
                labelModModel.Visible = !labelModModel.Visible;
                labelModNumar.Visible = !labelModNumar.Visible;
                labelModSofer.Visible = !labelModSofer.Visible;
                inputModMarca.Visible = !inputModMarca.Visible;
                inputModModel.Visible = !inputModModel.Visible;
                inputModNumar.Visible = !inputModNumar.Visible;
                inputModSofer.Visible = !inputModSofer.Visible;
                acceptModChild.Visible = !acceptModChild.Visible;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(" SELECT id_sofer FROM Soferi ;", connection);
                        DataTable data = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(data);

                        inputModSofer.Items.Clear();
                        foreach (DataRow row in data.Rows) { inputModSofer.Items.Add(row["id_sofer"].ToString()); }

                        inputModSofer.SelectedIndex = 0;
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string validateChildInput(string marca , string model , string numar)
        {
            string err = "";
            if(!Regex.IsMatch(marca , @"^[a-zA-Z ]+$")){ err += "Marca introdusa invalida!\n"; }
            if(!Regex.IsMatch(model , @"^[a-zA-Z0-9 ]+$")) { err += "Model introdus invalid!\n"; }
            if(numar.Length != 7) { err += "Numarul ar trebui sa contina 7 caractere!\n"; }
            else
            {
                if (!Regex.IsMatch(numar, @"^[a-zA-Z]{2}[0-9]*?[a-zA-Z]{3}$")) { err += "Numarul este invalid!\n"; }
            }
            return err;
        }

        private void acceptChild_Click(object sender, EventArgs e)
        {
            string marcaInput = inputModMarca.Text;
            string modelInput = inputModModel.Text;
            string numarInput = inputModNumar.Text;
            int idSoferInput = Int32.Parse(inputModSofer.SelectedItem.ToString());
            string errorString = validateChildInput(marcaInput , modelInput , numarInput);

            if (errorString.Length > 0) { MessageBox.Show(errorString); }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        adapter.UpdateCommand = new SqlCommand("UPDATE Masini SET marca = @inputMarca , model = @inputModel , " +
                            "numar_inmatriculare = @inputNumar , id_sofer = @inputIDSofer WHERE id_masina = @currentSelected;", connection);
                        adapter.UpdateCommand.Parameters.AddWithValue("@inputMarca", marcaInput);
                        adapter.UpdateCommand.Parameters.AddWithValue("@inputModel", modelInput);
                        adapter.UpdateCommand.Parameters.AddWithValue("@inputNumar", numarInput);
                        adapter.UpdateCommand.Parameters.AddWithValue("@inputIDSofer", idSoferInput);
                        adapter.UpdateCommand.Parameters.AddWithValue("@currentSelected", childSelectedID);
                        adapter.UpdateCommand.ExecuteNonQuery();

                        adapter.SelectCommand = new SqlCommand("SELECT * FROM Masini WHERE id_sofer=@selectedID;", connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@selectedID", parentSelectedID);
                        ds.Tables["Masini"].Clear();
                        adapter.Fill(ds, "Masini");
                        gridChildren.DataSource = ds.Tables["Masini"];
                        childSelectedID = -1;
                        MessageBox.Show("Modificare executata cu succes!");

                        labelModMarca.Visible = false;
                        labelModModel.Visible = false;
                        labelModNumar.Visible = false;
                        labelModSofer.Visible = false;
                        inputModMarca.Visible = false;
                        inputModModel.Visible = false;
                        inputModNumar.Visible = false;
                        inputModSofer.Visible = false;
                        acceptModChild.Visible = false;

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void addChild_Click(object sender, EventArgs e)
        {
            labelAddMarca.Visible = !labelAddMarca.Visible;
            labelAddModel.Visible = !labelAddModel.Visible;
            labelAddNumar.Visible = !labelAddNumar.Visible;
            inputAddMarca.Visible = !inputAddMarca.Visible;
            inputAddModel.Visible = !inputAddModel.Visible;
            inputAddNumar.Visible = !inputAddNumar.Visible;
            acceptAddChild.Visible = !acceptAddChild.Visible;
            inputAddMarca.Text = "";
            inputAddModel.Text = "";
            inputAddNumar.Text = "";
        }

        private string existentEntry(string numarInput)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(" SELECT numar_inmatriculare FROM Masini ;", connection);
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);

                    foreach (DataRow row in data.Rows)
                    {
                        if (numarInput.Equals(row["numar_inmatriculare"].ToString())) { return "O masina cu acest numar exista deja!\n"; }
                    }
                    connection.Close();
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private void acceptAddChild_Click(object sender, EventArgs e)
        {
            string marcaInput = inputAddMarca.Text;
            string modelInput = inputAddModel.Text;
            string numarInput = inputAddNumar.Text;
            string errorString = validateChildInput(marcaInput, modelInput, numarInput);
            errorString += existentEntry(numarInput);

            if (errorString.Length > 0) { MessageBox.Show(errorString); }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        adapter.InsertCommand = new SqlCommand("INSERT INTO Masini (marca,model,numar_inmatriculare,id_sofer) VALUES" +
                            "(@marcaInput,@modelInput,@numarInput,@selectedParent);", connection);
                        adapter.InsertCommand.Parameters.AddWithValue("@marcaInput", marcaInput);
                        adapter.InsertCommand.Parameters.AddWithValue("@modelInput", modelInput);
                        adapter.InsertCommand.Parameters.AddWithValue("@numarInput", numarInput);
                        adapter.InsertCommand.Parameters.AddWithValue("@selectedParent", parentSelectedID);
                        adapter.InsertCommand.ExecuteNonQuery();

                        adapter.SelectCommand = new SqlCommand("SELECT * FROM Masini WHERE id_sofer=@selectedID;", connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@selectedID", parentSelectedID);
                        ds.Tables["Masini"].Clear();
                        adapter.Fill(ds, "Masini");
                        gridChildren.DataSource = ds.Tables["Masini"];

                        MessageBox.Show("Masina adaugata cu succes!");
                        labelAddMarca.Visible = false;
                        labelAddModel.Visible = false;
                        labelAddNumar.Visible = false;
                        inputAddMarca.Visible = false;
                        inputAddModel.Visible = false;
                        inputAddNumar.Visible = false;
                        acceptAddChild.Visible = false;

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
