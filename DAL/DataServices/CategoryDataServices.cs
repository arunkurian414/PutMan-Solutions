using BOL.Models;
using DAL.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class CategoryDataServices : ICategoryDataServices
    {   
        private SqlConnection sqlConnection;
        private ConnectionStrings connectionStrings;

        public List<Category> GetAllCategories()
        {
            connectionStrings = new ConnectionStrings();

            List<Category> categories = new List<Category>();
            try
            {
                using(sqlConnection=new SqlConnection(connectionStrings.SqlAppSettingConnection))
                {
                    sqlConnection.Open();
                    var cmd = new SqlCommand("SELECT * FROM ProductCategories", sqlConnection);
                    cmd.CommandType=CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                        category.CategoryName = reader["CategoryName"].ToString();
                        category.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                        categories.Add(category);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return categories.ToList();
        }

        public void GetCategoryByID()
        {

        }

        public void GetCategoryLike(string like, Enum columnName)
        {
            
        }
        public void AddCategory()
        {

        }
        public void DeleteCategory() { }

        public void UpdateCategory() { }
    }

}
