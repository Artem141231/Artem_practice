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
    public partial class LoginHistory : Form
    {
        public LoginHistory()
        {
            InitializeComponent();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxFilter.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            string query = @"
        SELECT * FROM LoginHistory 
        WHERE (@filter IS NULL OR 
              login LIKE '%' + @filter + '%' OR 
              CONVERT(VARCHAR, time, 120) LIKE '%' + @filter + '%' OR
              LTRIM(RTRIM(IsSuccessful)) = @filter)
        ORDER BY time DESC";

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

            UpdateRecordCount(db);
        }

        private void LoginHistory_Load(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM LoginHistory ", db.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table); 
            dataGridView1.DataSource = table;
            dataGridView1.Columns["time"].HeaderText = "Время";
            dataGridView1.Columns["login"].HeaderText = "Логин";
            dataGridView1.Columns["IsSuccessful"].HeaderText = "Успешность захода";

            UpdateRecordCount(db);
        }
        private void UpdateRecordCount(DB db)
        {
            db.OpenConnection();
            string countQuery = "SELECT COUNT(*) FROM LoginHistory";
            string filteredCountQuery = @"
                SELECT COUNT(*) FROM LoginHistory 
                WHERE (@filter IS NULL OR 
                      login LIKE '%' + @filter + '%' OR 
                      CONVERT(VARCHAR, time, 120) LIKE '%' + @filter + '%' OR
                      LTRIM(RTRIM(IsSuccessful)) LIKE '%' + @filter + '%')";

            SqlCommand countCommand = new SqlCommand(countQuery, db.getConnection());
            
            int totalRecords = (int)countCommand.ExecuteScalar();


            SqlCommand filteredCountCommand = new SqlCommand(filteredCountQuery, db.getConnection());
            string filterValue = textBoxFilter.Text;
            if (string.IsNullOrEmpty(filterValue))
            {
                filteredCountCommand.Parameters.AddWithValue("@filter", DBNull.Value);
            }
            else
            {
                filteredCountCommand.Parameters.AddWithValue("@filter", filterValue);
            }
            int filteredRecords = (int)filteredCountCommand.ExecuteScalar();

            labelCount.Text = $"{filteredRecords} из {totalRecords}";
        }

    }
}
