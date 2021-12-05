using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;


namespace Business_Layer
{
    public class Business_Logic
    {
        public DAL db = new DAL();
        public string query;

        public void InsertItem(Item i)
        {
            query = @"Insert into Items Values('" + i.ID + "','" + i.Name + "','" + i.Price + "')";
            db.IDU(query);
        }
        public void UpdateItem(Item i)
        {
            query = @"UPDATE Items SET Name = '" + i.Name + "', Price= '" + i.Price + "' WHERE ID = '" + i.ID + "'";
            db.IDU(query);
        }
        public void DeleteItem(int ID)
        {

            query = @"DELETE FROM Items WHERE ID='" + ID + "'";
            db.IDU(query);
        }

        //public List<Item> GetAll()
        //{
        //    query = @"Select * from Items";
        //    DAL db = new DAL();
        //    SqlDataReader sdr = db.GetReader(query);

        //    List<Item> ItemsList = new List<Item>();

        //    while (sdr.Read())
        //    {
        //        Item i = new Item();
        //        i.ID = int.Parse(sdr[0].ToString());
        //        i.Name = sdr[1].ToString();
        //        i.Price = int.Parse(sdr[2].ToString());
        //        ItemsList.Add(i);
        //    }

        //    sdr.Close();
        //    db.CloseConnection();
        //    return ItemsList;
        //}

        public SqlDataReader ViewByID(int ID)
        {
            query = @"Select * from Items where ID='" + ID + "'";
            return db.GetReader(query);
        }
    }
}
