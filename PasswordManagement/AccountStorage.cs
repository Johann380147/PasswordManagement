using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PasswordManagement
{

    class Account
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Extras { get; set; }
        public Image ImageBound { get; set; }
        public string Category { get; set; }
    }
    
    class AccountStorage : Account
    {
        private static readonly string connectionString = Properties.Resources.ConnectionString;
        private enum Operation { Add, Delete, Edit };
        private MemoryStream ms;

        public AccountStorage()
        {

        }

        public void AddAccount(string name, string website, string username, string password, string extras, byte[] image, string category)
        {
            PerformBasicNonQuery(Operation.Add, name, website, username, password, extras, image, category);
        }
        
        public void EditAccount(int id, string name, string website, string username, string password, string extras, byte[] image, string category)
        {
            PerformBasicNonQuery(Operation.Edit, id, name, website, username, password, extras, image, category);
        }

        public void DeleteAccount(int id)
        {
            PerformBasicNonQuery(Operation.Delete, id);
        }

        public void AddCategory(string category)
        {
            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("INSERT INTO Categories (Category) VALUES (@category)", connection))
            {
                connection.Open();

                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.ExecuteNonQuery();
            }
        }

        public void EditCategory(string oldCategory, string newCategory)
        {
            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("UPDATE Categories SET Category = @newcategory WHERE Category = @oldcategory", connection))
            {
                connection.Open();

                command.Parameters.Add("@newcategory", SqlDbType.NVarChar, 50).Value = newCategory;
                command.Parameters.Add("@oldcategory", SqlDbType.NVarChar, 50).Value = oldCategory;
                command.ExecuteNonQuery();
            }
            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("UPDATE Accounts SET CategoryIn = @newcategory WHERE CategoryIn = @oldcategory", connection))
            {
                connection.Open();

                command.Parameters.Add("@newcategory", SqlDbType.NVarChar, 50).Value = newCategory;
                command.Parameters.Add("@oldcategory", SqlDbType.NVarChar, 50).Value = oldCategory;
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(string category)
        {
            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("DELETE FROM Categories WHERE Category = @category", connection))
            {
                connection.Open();

                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.ExecuteNonQuery();
            }

            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("UPDATE Accounts SET CategoryIn = @newcategory WHERE CategoryIn = @category", connection))
            {
                connection.Open();

                command.Parameters.Add("@newcategory", SqlDbType.NVarChar, 50).Value = "All";
                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();

            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("SELECT DISTINCT Category FROM Categories", connection))
            {
                connection.Open();

                using (var dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        categories.Add(dataReader.GetString(0));
                    }
                }
                
            }
            return categories;
        }

        public Account GetAccountInfo(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT ROW_NUMBER() OVER(ORDER BY Id), Name, Website, Username, Password, Extras, CategoryIn, Image FROM Accounts", connection))
            {
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    byte[] imageBytes;

                    while (dataReader.Read())
                    {
                        if (Convert.ToInt32(dataReader[0]) != id) continue;

                        var account = new Account();

                        account.Name = dataReader.GetString(1);
                        account.Website = dataReader.GetString(2);
                        account.Username = dataReader.GetString(3);
                        account.Password = dataReader.GetString(4);
                        account.Extras = dataReader.GetString(5);
                        account.Category = dataReader.GetString(6);
                        if (!dataReader.IsDBNull(7))
                        {
                            imageBytes = new byte[dataReader.GetBytes(7, 0, null, 0, 0)];
                            dataReader.GetBytes(7, 0, imageBytes, 0, imageBytes.Length);

                            ms = new MemoryStream(imageBytes);
                            account.ImageBound = new Bitmap(ms);
                            
                        }
                        else account.ImageBound = null;

                        return account;
                        
                    }
                }

                return null;
            }
        }
        
        public Account GetAccountInfoOfCategory(string category, int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(
                "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS RowNumber, Name, Website, Username, Password, Extras, CategoryIn, Image " +
                "FROM Accounts WHERE CategoryIn = @category) " + 
                "SELECT TOP 1 Name, Website, Username, Password, Extras, CategoryIn, Image FROM CTE WHERE RowNumber = @index", connection))
            {
                connection.Open();
                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.Parameters.Add("@index", SqlDbType.Int).Value = index;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    byte[] imageBytes;

                    if (dataReader.Read())
                    {
                        var account = new Account();

                        account.Name = dataReader.GetString(0);
                        account.Website = dataReader.GetString(1);
                        account.Username = dataReader.GetString(2);
                        account.Password = dataReader.GetString(3);
                        account.Extras = dataReader.GetString(4);
                        account.Category = dataReader.GetString(5);
                        if (!dataReader.IsDBNull(6))
                        {
                            imageBytes = new byte[dataReader.GetBytes(6, 0, null, 0, 0)];
                            dataReader.GetBytes(6, 0, imageBytes, 0, imageBytes.Length);

                            ms = new MemoryStream(imageBytes);

                            account.ImageBound = new Bitmap(ms);

                        }
                        else account.ImageBound = null;

                        return account;
                    }
                    else return null;
                    
                }
                
            }
        }
        
        public void EditCategorisedAccount(int id, string name, string website, string username, string password, string extras, byte[] image, string category, string categoryAfter)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(
                "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS RowNumber, Name, Website, Username, Password, Extras, CategoryIn, Image " +
                "FROM Accounts WHERE CategoryIn = @category) " +
                "UPDATE CTE SET Name =@name, Website=@website, Username=@username, Password=@password, Extras=@extras, CategoryIn=@categoryAfter, Image=@image WHERE RowNumber = @id", connection))
            {
                connection.Open();

                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
                command.Parameters.Add("@website", SqlDbType.NVarChar, 50).Value = website;
                command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
                command.Parameters.Add("@extras", SqlDbType.NVarChar, -1).Value = extras;
                command.Parameters.Add("@categoryAfter", SqlDbType.NVarChar, 50).Value = categoryAfter;
                
                if (image == null)
                {
                    command.Parameters.Add("@image", SqlDbType.VarBinary, -1);
                    command.Parameters["@image"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@image", SqlDbType.VarBinary, -1).Value = image;
                }
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategorisedAccount(string category, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(
                "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS RowNumber, Name, Website, Username, Password, Extras, CategoryIn, Image " +
                "FROM Accounts WHERE CategoryIn = @category) " +
                "DELETE CTE WHERE RowNumber = @id", connection))
            {
                connection.Open();

                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }
        
        public List<Account> GetAccountListInfo()
        {
            List<Account> accountNames = new List<Account>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM Accounts", connection))
            {
                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    Account a;
                    byte[] imageBytes;

                    while (dataReader.Read())
                    {
                        a = new Account();
                        a.Name = dataReader.GetString(1);
                        a.Website = dataReader.GetString(2);
                        a.Username = dataReader.GetString(3);
                        a.Password = dataReader.GetString(4);
                        a.Extras = dataReader.GetString(5);
                        a.Category = dataReader.GetString(7);

                        if (dataReader.IsDBNull(6))
                        {
                            a.ImageBound = Properties.Resources.defaultimg;
                        }
                        else
                        {
                            imageBytes = new byte[dataReader.GetBytes(6, 0, null, 0, 0)];
                            dataReader.GetBytes(6, 0, imageBytes, 0, imageBytes.Length);

                            ms = new MemoryStream(imageBytes);
                            a.ImageBound = new Bitmap(ms);
                        }

                        accountNames.Add(a);
                    }

                }
            }
            
            return accountNames;
        }

        public List<Account> GetAccountListOfCategory(string category)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM Accounts WHERE CategoryIn = @category", connection))
            {
                connection.Open();
                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    Account a;
                    byte[] imageBytes;

                    while (dataReader.Read())
                    {
                        a = new Account();
                        a.Name = dataReader.GetString(1);
                        a.Website = dataReader.GetString(2);
                        a.Username = dataReader.GetString(3);
                        a.Password = dataReader.GetString(4);
                        a.Extras = dataReader.GetString(5);
                        a.Category = dataReader.GetString(7);

                        if(dataReader.IsDBNull(6))
                        {
                            a.ImageBound = Properties.Resources.defaultimg;
                        }
                        else
                        {
                            imageBytes = new byte[dataReader.GetBytes(6, 0, null, 0, 0)];
                            dataReader.GetBytes(6, 0, imageBytes, 0, imageBytes.Length);

                            ms = new MemoryStream(imageBytes);
                            a.ImageBound = new Bitmap(ms);
                        }

                        accounts.Add(a);
                    }
                }

            }
            return accounts;
        }

        public List<Image> GetAccountImages()
        {
            List<Image> images = new List<Image>();
            using (var connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (var command = new SqlCommand("SELECT Image FROM Accounts", connection))
            {
                connection.Open();

                byte[] imageBytes;

                using (var datareader = command.ExecuteReader())
                while (datareader.Read())
                {
                    if (datareader.IsDBNull(0))
                    {
                        images.Add(Properties.Resources.defaultimg);
                        continue;
                    }

                    imageBytes = new byte[datareader.GetBytes(0, 0, null, 0, 0)];
                    datareader.GetBytes(0, 0, imageBytes, 0, imageBytes.Length);

                    ms = new MemoryStream(imageBytes);
                    images.Add(new Bitmap(ms));
                    
                }
            }


            return images;
        }

        public List<Image> GetAccountImagesOfCategory(string category)
        {
            List<Image> images = new List<Image>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(
                "SELECT Image FROM Accounts WHERE CategoryIn = @category", connection))
            {
                connection.Open();
                command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;

                byte[] imageBytes;
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader.IsDBNull(0))
                        {
                            images.Add(Properties.Resources.defaultimg);
                            continue;
                        }

                        imageBytes = new byte[dataReader.GetBytes(0, 0, null, 0, 0)];
                        dataReader.GetBytes(0, 0, imageBytes, 0, imageBytes.Length);

                        ms = new MemoryStream(imageBytes);
                        images.Add(new Bitmap(ms));
                    }
                }
            }

            return images;
        }

        public List<Account> SortListAscending()
        {
            List<Account> sortedList = new List<Account>();
            
            AddToList(sortedList, SortOrder.Ascending);
            DeleteDbTable();
            CreateDbTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (Account account in sortedList)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Accounts (Name,Website,Username,Password,Extras,Image,CategoryIn) VALUES (@name,@website,@username,@password,@extras,@image,@category)",
                            connection))
                    {
                        command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = account.Name;
                        command.Parameters.Add("@website", SqlDbType.NVarChar, 50).Value = account.Website;
                        command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = account.Username;
                        command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = account.Password;
                        command.Parameters.Add("@extras", SqlDbType.NVarChar, -1).Value = account.Extras;
                        
                        if (account.ImageBound == null)
                        {
                            command.Parameters.Add("@image", SqlDbType.VarBinary, -1);
                            command.Parameters["@image"].Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@image", SqlDbType.VarBinary, -1).Value = account.ImageBound.ImageToByte();
                        }
                        command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = account.Category;
                        command.ExecuteNonQuery();
                    }        
                }
            }
                

            return sortedList;
            
        }

        public List<Account> SortListDescending()
        {
            List<Account> sortedList = new List<Account>();
            
            AddToList(sortedList, SortOrder.Descending);
            DeleteDbTable();
            CreateDbTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (Account account in sortedList)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Accounts (Name,Website,Username,Password,Extras,Image,CategoryIn) VALUES (@name,@website,@username,@password,@extras,@image,@category)",
                            connection))
                    {
                        command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = account.Name;
                        command.Parameters.Add("@website", SqlDbType.NVarChar, 50).Value = account.Website;
                        command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = account.Username;
                        command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = account.Password;
                        command.Parameters.Add("@extras", SqlDbType.NVarChar, -1).Value = account.Extras;

                        if (account.ImageBound == null)
                        {
                            command.Parameters.Add("@image", SqlDbType.VarBinary, -1);
                            command.Parameters["@image"].Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@image", SqlDbType.VarBinary, -1).Value = account.ImageBound.ImageToByte();
                        }
                        command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = account.Category;
                        command.ExecuteNonQuery();
                    }
                }
            }

            return sortedList;
        }
        
        private void PerformBasicNonQuery(Operation operation, int id)
        {
            PerformBasicNonQuery(operation, id, "", "", "", "", "", null, "");
        }

        private void PerformBasicNonQuery(Operation operation, string name, string website, string username, string password, string extras, byte[] image, string category)
        {
            PerformBasicNonQuery(operation, -1, name, website, username, password, extras, image, category);
        }

        private void PerformBasicNonQuery(Operation operation, int id, string name, string website, string username, string password, string extras, byte[] image, string category)
        {
            string text;
            switch(operation)
            {
                case Operation.Add:
                    text = "INSERT INTO Accounts (Name,Website,Username,Password,Extras,Image,CategoryIn) VALUES (@name, @website, @username, @password, @extras, @image, @category)";
                    break;
                case Operation.Delete:
                    text = "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY Id) AS RowNumber FROM Accounts) DELETE CTE WHERE RowNumber = " + id;
                    break;
                case Operation.Edit:
                    text = "WITH CTE AS (SELECT ROW_NUMBER() OVER (ORDER BY Id) AS RowNumber, Name,Website,Username,Password,Extras,Image,CategoryIn FROM Accounts) " +
                        "UPDATE CTE SET Name = @name, Website = @website, Username = @username, Password = @password, Extras = @extras, Image = @image, CategoryIn = @category WHERE RowNumber = " + id;
                    break;
                default:
                    return;
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(text, connection))
            {
                connection.Open();

                if(text.Contains("@name"))
                {
                    command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
                    command.Parameters.Add("@website", SqlDbType.NVarChar, 50).Value = website;
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
                    command.Parameters.Add("@extras", SqlDbType.NVarChar, -1).Value = extras;
                    
                    if (image == null)
                    {
                        command.Parameters.Add("@image", SqlDbType.VarBinary, -1);
                        command.Parameters["@image"].Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@image", SqlDbType.VarBinary, -1).Value = image;
                    }
                    command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = category;
                }
                    
                command.ExecuteNonQuery();
            }
             
        }

        private void CreateDbTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("CREATE TABLE[dbo].[Accounts] (" +
                                  "[Id]       INT IDENTITY(1, 1) NOT NULL," +
                                  "[Name]     NVARCHAR(50)  NULL," +
                                  "[Website]  NVARCHAR(50)  NULL," +
                                  "[Username] NVARCHAR(50)  NULL," +
                                  "[Password] NVARCHAR(50)  NULL," +
                                  "[Extras]   NVARCHAR(MAX) NULL," +
                                  "[Image]   VARBINARY (MAX) NULL," +
                                  "[CategoryIn]   NVARCHAR(50) NULL," +
                                  "PRIMARY KEY CLUSTERED([Id] ASC))", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
                
        }

        private void DeleteDbTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DROP TABLE Accounts", connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            
        }
        
        private void AddToList(List<Account> sortedList, SortOrder sortOrder)
        {
            string text;
            switch (sortOrder)
            {
                case SortOrder.Unspecified:
                    text = "SELECT * FROM Accounts ORDER BY Name";
                    break;
                case SortOrder.Ascending:
                    text = "SELECT * FROM Accounts ORDER BY Name ASC";
                    break;
                case SortOrder.Descending:
                    text = "SELECT * FROM Accounts ORDER BY Name DESC";
                    break;
                default:
                    text = "SELECT * FROM Accounts ORDER BY Name";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(text, connection))
            {
                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    byte[] img;
                    Image i;
                    while (dataReader.Read())
                    {

                        if (!dataReader.IsDBNull(6))
                        {
                            img = new byte[dataReader.GetBytes(6, 0, null, 0, 0)];
                            dataReader.GetBytes(6, 0, img, 0, img.Length);
                            ms = new MemoryStream(img);
                            i = new Bitmap(ms);
                        }
                        else i = null;

                        sortedList.Add(new Account()
                        {
                            Name = dataReader[1].ToString(),
                            Website = dataReader[2].ToString(),
                            Username = dataReader[3].ToString(),
                            Password = dataReader[4].ToString(),
                            Extras = dataReader[5].ToString(),
                            ImageBound = i,
                            Category = dataReader[7].ToString()
                        });
                    }
                }
            }
            
             
        }
    }
}
