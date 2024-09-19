using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DatabaseController;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TestDatabase
        {
            private string sqlstr = @"Data Source=DESKTOP-57HE20H\SQLEXPRESS;Initial Catalog=Практика_Нечеухин;Integrated Security=True;";
            private Database database;

            public TestDatabase()
            {
                database = Database.GetInstance(sqlstr);
            }


            [TestMethod]
            public void ExecuteCommandWithParameters() // тест вставление таблицы в строк
            {
                string query = "INSERT INTO Users (fio, phone, login, password, typeID) VALUES (@fio, @phone, @login, @password, @typeID)";

                Parameter[] par =
                {
                new Parameter("@fio", "User Test"),
                new Parameter("@phone", "123456789"),
                new Parameter("@login", "user_test"),
                new Parameter("@password", "pass123"),
                new Parameter("@typeID", 1)
            };

                int rows = database.Execute(query, par);

                Assert.AreEqual(rows, 1, "Ожидалась вставка одной строки, но фактически была вставлена другая");
            }

            [TestMethod]
            public void GetScalarFromExistingTable()// Тест получения скалярного значения из существующей таблицы
            {

                string query = "SELECT COUNT(*) FROM Users";

                object result = database.GetScalar(query);

                Assert.IsNotNull(result, "Не удалось получить число записей.");
                Assert.IsTrue(Convert.ToInt32(result) >= 0, "Количество записей должно быть >= 0.");
            }

            [TestMethod]
            public void GetRowsFromDatabase() // Тест получения строк из таблицы
            {
                
                string query = "SELECT userID, login FROM Users";

                object[][] result = database.GetRowsData(query);

                CollectionAssert.AllItemsAreNotNull(result, "Не удалось получить записи из таблицы.");
            }
            [TestMethod]
            public void TestDeleteUser() //Тест удаления записи
            {
                string query = "DELETE FROM Users WHERE login = @login";

                Parameter[] parameters =
                {
        new Parameter("@login", "user_test")  
    };

                int rowsAffected = database.Execute(query, parameters);

                Assert.AreEqual(1, rowsAffected, "Не удалось удалить пользователя.");
            }
            [TestMethod]
            public void TestGetRequestsByMasterID() //Тест получения списка заявок мастера
            {
                string query = "SELECT requestID, problemDescription FROM Requests WHERE masterID = @masterID";

                Parameter[] parameters =
                {
        new Parameter("@masterID", 2)  
    };

                object[][] result = database.GetRowsData(query, parameters);


                Assert.IsTrue(result.Length > 0, "Не удалось получить заявки для мастера с ID 1.");
            }
        }
    }
}
