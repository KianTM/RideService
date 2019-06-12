using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using RideService.Entities;

namespace RideService.DAL
{
    public class CategoryRepository : BaseRepository
    {
        public List<RideCategory> HandleData(DataTable dataTable)
        {
            List<RideCategory> categories = new List<RideCategory>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["RideCategoryId"];
                string name = (string)row["Name"];
                string description = (string)row["Description"];

                RideCategory category = new RideCategory(id, name, description);
                categories.Add(category);
            }

            return categories;
        }

        public List<RideCategory> GetAllCategories()
        {
            string sql = "SELECT * FROM RideCategories";
            DataTable dataTable = ExecuteQuery(sql);
            return HandleData(dataTable);
        }
    }
}
