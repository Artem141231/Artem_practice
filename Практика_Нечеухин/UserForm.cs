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
    public partial class UserForm : Form
    {
        private int UserID;

        private DataTable table; 
        private SqlDataAdapter adapter;
        private DB db;

        public UserForm(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadRequestData();
            LoadHomeTechTypes();

        }

        private void LoadRequestData()
        {
            db = new DB();

            table = new DataTable();


            SqlCommand command = new SqlCommand("SELECT * FROM Requests WHERE ClientID = @ClientID ", db.getConnection());

            command.Parameters.AddWithValue("@ClientID", UserID);

            adapter = new SqlDataAdapter(command);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand(); 
            adapter.InsertCommand = commandBuilder.GetInsertCommand();
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            dataGridView1.Columns["StartDate"].HeaderText = "Дата создания заявка";
            dataGridView1.Columns["problemDescription"].HeaderText = "Проблема";
            dataGridView1.Columns["requestStatus"].HeaderText = "Статус";
            dataGridView1.Columns["completionDate"].HeaderText = "Дата выполнения заявок";
            dataGridView1.Columns["repairParts"].HeaderText = "Запчасти";
            dataGridView1.Columns["requestID"].Visible = false;
            dataGridView1.Columns["homeTechModelID"].Visible = false;
            dataGridView1.Columns["masterID"].Visible = false;
            dataGridView1.Columns["clientID"].Visible = false;
            db.CloseConnection();
        }
            private void btnSaveData_Click(object sender, EventArgs e)
        {

            if (table != null && table.GetChanges() != null) 
            {
                db.OpenConnection(); 

                adapter.UpdateCommand.Connection = db.getConnection();
                adapter.InsertCommand.Connection = db.getConnection();
                adapter.DeleteCommand.Connection = db.getConnection();

                adapter.Update(table); 

                MessageBox.Show("Изменения сохранены.");
                db.CloseConnection();
            }
            else
            {
                MessageBox.Show("Нет изменений для сохранения.");
            }
        }
        private void btnAppRequest_Click(object sender, EventArgs e)
        {
            panelMainMenu.Visible = false;
            panelAppRequest.Visible = true;
            panelCreateRequest.Visible = false;
        }

        private void Bear_Click(object sender, EventArgs e)
        {
            panelMainMenu.Visible = true;
            panelAppRequest.Visible = false;
            panelCreateRequest.Visible = false;
        }

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            panelCreateRequest.Visible = true;
            panelMainMenu.Visible = false;
            panelAppRequest.Visible = false;
        }

        private void LoadHomeTechTypes()
        {
            DB db = new DB();
            SqlCommand command = new SqlCommand("SELECT homeTechTypeID, typeName FROM HomeTechType", db.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable homeTechTypeTable = new DataTable();
            adapter.Fill(homeTechTypeTable);

            comboBoxTechType.DataSource = homeTechTypeTable;
            comboBoxTechType.DisplayMember = "typeName"; 
            comboBoxTechType.ValueMember = "homeTechTypeID"; 
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            int selectedTechTypeID = Convert.ToInt32(comboBoxTechType.SelectedValue);
            string homeTechModelName = textBoxHomeTechModel.Text; 
            string problemDescription = textBoxDescriptionProblems.Text;

            if (string.IsNullOrEmpty(Convert.ToString( selectedTechTypeID)) || string.IsNullOrEmpty(homeTechModelName) || string.IsNullOrEmpty(problemDescription))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            db.OpenConnection();

            SqlCommand checkModel = new SqlCommand("SELECT homeTechModelID FROM HomeTechModel WHERE modelName = @modelName AND homeTechTypeID = @homeTechTypeID", db.getConnection());
            checkModel.Parameters.AddWithValue("@modelName", homeTechModelName);
            checkModel.Parameters.AddWithValue("@homeTechTypeID", selectedTechTypeID);

            object result = checkModel.ExecuteScalar(); 

            int homeTechModelID;

            if (result == null)
            {

                SqlCommand insertModel = new SqlCommand("INSERT INTO HomeTechModel(modelName, homeTechTypeID) OUTPUT INSERTED.homeTechModelID VALUES(@modelName, @homeTechTypeID)", db.getConnection());
                insertModel.Parameters.AddWithValue("@modelName", homeTechModelName);
                insertModel.Parameters.AddWithValue("@homeTechTypeID", selectedTechTypeID);
                //dasd
                homeTechModelID = (int)insertModel.ExecuteScalar(); 
            }
            else
            {
                homeTechModelID = (int)result; 
            }

            SqlCommand Requests = new SqlCommand("INSERT INTO Requests(startDate, problemDescription, requestStatus, homeTechModelID, clientID) VALUES(@time, @DescriptionProblems, @requestStatus, @homeTechModelID, @clientID)", db.getConnection());
            Requests.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            Requests.Parameters.Add("@DescriptionProblems", SqlDbType.VarChar).Value = problemDescription;
            Requests.Parameters.Add("@requestStatus", SqlDbType.VarChar).Value = "Новая заявка";
            Requests.Parameters.Add("@homeTechModelID", SqlDbType.Int).Value = homeTechModelID; 
            Requests.Parameters.Add("@clientID", SqlDbType.Int).Value = UserID; 

            Requests.ExecuteNonQuery(); 
            db.CloseConnection();

            MessageBox.Show("Заявка успешно создана!");
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

            string query = @"
        SELECT * FROM Requests 
        WHERE ClientID = @ClientID 
          AND (@filter IS NULL OR 
               problemDescription LIKE '%' + @filter + '%' OR 
               CONVERT(VARCHAR, startDate, 120) LIKE '%' + @filter + '%' OR
               requestStatus LIKE '%' + @filter + '%')";

            SqlCommand command = new SqlCommand(query, db.getConnection());

            command.Parameters.AddWithValue("@ClientID", UserID);

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

        private void btn_review_Click(object sender, EventArgs e)
        {
            panelReview.Visible = !panelReview.Visible;
        }
    }
}
