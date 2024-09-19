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

namespace Практика_Нечеухин
{
    public partial class ManagerForm : Form
    {
        private DataTable table;
        private SqlDataAdapter adapter;
        private DB db;
        public ManagerForm()
        {
            InitializeComponent();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadRequestData();
            LoadComboBoxes();
            if (comboBoxClient.SelectedValue != null && int.TryParse(comboBoxClient.SelectedValue.ToString(), out int selectedClientID))
            {
                UpdateRequestComboBox(selectedClientID);
            }


        }
        private void LoadComboBoxes()
        {

            SqlCommand clientCommand = new SqlCommand("SELECT userID, fio FROM Users WHERE typeID = 4", db.getConnection());
            SqlDataAdapter clientAdapter = new SqlDataAdapter(clientCommand);
            DataTable clientTable = new DataTable();
            clientAdapter.Fill(clientTable);

            comboBoxClient.DataSource = clientTable;
            comboBoxClient.DisplayMember = "fio";
            comboBoxClient.ValueMember = "userID";


            SqlCommand masterCommand = new SqlCommand("SELECT userID, fio FROM Users WHERE typeID = 2", db.getConnection());
            SqlDataAdapter masterAdapter = new SqlDataAdapter(masterCommand);
            DataTable masterTable = new DataTable();
            masterAdapter.Fill(masterTable);

            comboBoxMaster.DataSource = masterTable;
            comboBoxMaster.DisplayMember = "fio";
            comboBoxMaster.ValueMember = "userID";


            comboBoxStatus.Items.AddRange(new string[] { "Новая заявка", "В процессе ремонта", "Готова к выдаче" });
            if (clientTable.Rows.Count > 0)
            {
                comboBoxClient.SelectedIndex = 0;
            }
        }
        private void LoadRequestData()
        {
            db = new DB();

            table = new DataTable();



            string query = @"
        SELECT r.requestID, r.startDate, r.problemDescription, r.requestStatus, r.completionDate, r.repairParts,
               uClient.fio AS ClientName, uMaster.fio AS MasterName, t.typeName AS TechType
        FROM Requests r
        LEFT JOIN Users uClient ON r.clientID = uClient.userID
        LEFT JOIN Users uMaster ON r.masterID = uMaster.userID
        LEFT JOIN HomeTechModel htm ON r.homeTechModelID = htm.homeTechModelID
        LEFT JOIN HomeTechType t ON htm.homeTechTypeID = t.homeTechTypeID";

            SqlCommand command = new SqlCommand(query, db.getConnection());

            adapter = new SqlDataAdapter(command);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = table;


            dataGridView1.Columns["startDate"].HeaderText = "Дата создания заявки";
            dataGridView1.Columns["problemDescription"].HeaderText = "Описание проблемы";
            dataGridView1.Columns["requestStatus"].HeaderText = "Статус заявки";
            dataGridView1.Columns["completionDate"].HeaderText = "Дата выполнения";
            dataGridView1.Columns["repairParts"].HeaderText = "Использованные запчасти";
            dataGridView1.Columns["ClientName"].HeaderText = "ФИО клиента";
            dataGridView1.Columns["MasterName"].HeaderText = "ФИО мастера";
            dataGridView1.Columns["TechType"].HeaderText = "Тип техники";


            db.CloseConnection();
        }


        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            panelCreateRequest.Visible = true;
            panelMainMenu.Visible = false;
            panelAppRequest.Visible = false;
            panelCreateRequest.BringToFront();
        }
        private void Bear_Click(object sender, EventArgs e)
        {
            panelMainMenu.Visible = true;
            panelAppRequest.Visible = false;
            panelCreateRequest.Visible = false;
            panelMainMenu.BringToFront();
        }


        private void btnAppRequest_Click(object sender, EventArgs e)
        {
            panelMainMenu.Visible = false;
            panelAppRequest.Visible = true;
            panelCreateRequest.Visible = false;
            panelAppRequest.BringToFront();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (comboBoxClient.SelectedValue == null ||
                comboBoxMaster.SelectedValue == null ||
                comboBoxStatus.SelectedItem == null ||
                comboBoxRequest.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все формы и выберите все необходимые значения.");
                return;
            }
            int selectedClientID = (int)comboBoxClient.SelectedValue;
            int selectedMasterID = (int)comboBoxMaster.SelectedValue;
            string selectedStatus = comboBoxStatus.SelectedItem.ToString();
            int selectedRequestID = (int)comboBoxRequest.SelectedValue;

            string query = @"
                UPDATE Requests 
                SET clientID = @clientID, 
                    masterID = @masterID, 
                    requestStatus = @requestStatus 
                WHERE requestID = @requestID";

            using (SqlConnection connection = db.getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@clientID", selectedClientID);
                command.Parameters.AddWithValue("@masterID", selectedMasterID);
                command.Parameters.AddWithValue("@requestStatus", selectedStatus);
                command.Parameters.AddWithValue("@requestID", selectedRequestID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Заявка успешно обновлена!");
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении заявки.");
                }

                connection.Close();
            }

            LoadRequestData();
        }

        private void panelExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxFilter.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Исправленный SQL-запрос для поиска
            string query = @"
    SELECT * FROM Requests 
    WHERE (@filter IS NULL OR 
           problemDescription LIKE '%' + @filter + '%' OR 
           CONVERT(VARCHAR, startDate, 120) LIKE '%' + @filter + '%' OR
           requestStatus LIKE '%' + @filter + '%')";

            SqlCommand command = new SqlCommand(query, db.getConnection());

            if (string.IsNullOrEmpty(filterValue))
            {
                command.Parameters.AddWithValue("@filter", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@filter", filterValue);
            }

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedValue != null && int.TryParse(comboBoxClient.SelectedValue.ToString(), out int selectedClientID))
            {
                UpdateRequestComboBox(selectedClientID);
            }
        }
        private void UpdateRequestComboBox(int clientID)
        {
            SqlCommand requestCommand = new SqlCommand("SELECT requestID, problemDescription FROM Requests WHERE clientID = @clientID", db.getConnection());
            requestCommand.Parameters.AddWithValue("@clientID", clientID);
            SqlDataAdapter requestAdapter = new SqlDataAdapter(requestCommand);
            DataTable requestTable = new DataTable();
            requestAdapter.Fill(requestTable);

            comboBoxRequest.DataSource = requestTable;
            comboBoxRequest.DisplayMember = "requestID";
            comboBoxRequest.ValueMember = "requestID";
        }
    }
}
