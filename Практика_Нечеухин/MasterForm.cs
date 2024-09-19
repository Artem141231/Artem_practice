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
using System.Windows.Forms.VisualStyles;

namespace Практика_Нечеухин
{
    public partial class MasterForm : Form
    {
        private int UserID;
        private DataTable table;
        private SqlDataAdapter adapter;
        private DB db;

        public MasterForm(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
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
 
            SqlCommand clientCommand = new SqlCommand(@"
        SELECT DISTINCT u.userID, u.fio 
        FROM Users u
        INNER JOIN Requests r ON u.userID = r.clientID
        WHERE r.masterID = @masterID", db.getConnection());

            clientCommand.Parameters.AddWithValue("@masterID", this.UserID); 

            SqlDataAdapter clientAdapter = new SqlDataAdapter(clientCommand);
            DataTable clientTable = new DataTable();
            clientAdapter.Fill(clientTable);


            comboBoxClient.DataSource = clientTable;
            comboBoxClient.DisplayMember = "fio";
            comboBoxClient.ValueMember = "userID";

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

            SqlCommand requestCommand = new SqlCommand(@"
        SELECT requestID, problemDescription 
        FROM Requests 
        WHERE clientID = @clientID AND masterID = @masterID", db.getConnection());


            requestCommand.Parameters.AddWithValue("@clientID", clientID); 
            requestCommand.Parameters.AddWithValue("@masterID", this.UserID); 

            SqlDataAdapter requestAdapter = new SqlDataAdapter(requestCommand);
            DataTable requestTable = new DataTable();
            requestAdapter.Fill(requestTable);


            comboBoxRequest.DataSource = requestTable;
            comboBoxRequest.DisplayMember = "requestID"; 
            comboBoxRequest.ValueMember = "requestID"; 
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
    LEFT JOIN HomeTechType t ON htm.homeTechTypeID = t.homeTechTypeID
    WHERE r.masterID = @masterID"; 

            SqlCommand command = new SqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@masterID", this.UserID); 

            adapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

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
            if (comboBoxRequest.SelectedValue == null || comboBoxClient.SelectedValue == null|| 
                dateTimePickerCompletionDate.Value == null) 
            {
                MessageBox.Show("Пожалуйста, заполните все формы и выберите все необходимые значения.");
                return; 
            }
            string repairParts = textBoxRepairParts.Text; 
            DateTime completionDate = dateTimePickerCompletionDate.Value; 
            int selectedClientID = (int)comboBoxClient.SelectedValue;
            int selectedRequestID = (int)comboBoxRequest.SelectedValue;

            string query = @"
        UPDATE Requests 
        SET clientID = @clientID, 
            repairParts = @repairParts, 
            completionDate = @completionDate 
        WHERE requestID = @requestID";

            using (SqlConnection connection = db.getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@repairParts", repairParts); 
                command.Parameters.AddWithValue("@completionDate", completionDate); 
                command.Parameters.AddWithValue("@clientID", selectedClientID);
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
            string filterValue = textBoxFilter.Text.Trim(); 
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            string query = @"
    SELECT r.requestID, r.startDate, r.problemDescription, r.requestStatus, r.completionDate, r.repairParts,
           uClient.fio AS ClientName, uMaster.fio AS MasterName, t.typeName AS TechType
    FROM Requests r
    LEFT JOIN Users uClient ON r.clientID = uClient.userID
    LEFT JOIN Users uMaster ON r.masterID = uMaster.userID
    LEFT JOIN HomeTechModel htm ON r.homeTechModelID = htm.homeTechModelID
    LEFT JOIN HomeTechType t ON htm.homeTechTypeID = t.homeTechTypeID
    WHERE r.masterID = @masterID
    AND (@filter IS NULL OR
         r.problemDescription LIKE '%' + @filter + '%' OR 
         CONVERT(VARCHAR, r.startDate, 120) LIKE '%' + @filter + '%' OR
         r.requestStatus LIKE '%' + @filter + '%' OR
         uClient.fio LIKE '%' + @filter + '%' OR
         t.typeName LIKE '%' + @filter + '%')";

            using (SqlCommand command = new SqlCommand(query, db.getConnection()))
            {
                command.Parameters.AddWithValue("@masterID", this.UserID);
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
            }
            dataGridView1.DataSource = table;

        }

        private void panelCreateRequest_Paint(object sender, PaintEventArgs e)
        {

        } 
    }
}
