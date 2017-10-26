using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nerd_Dinner.Models
{
    public class DinnerRepository
    {
        NerdDinnerDataContext context = new NerdDinnerDataContext();

        //Showing only upcoming Dinners 
        public IQueryable<tbl_Dinner> ShowUpcomingDinners()
        {
            var res = from obj in context.tbl_Dinners
                      where obj.EventDate > DateTime.Now
                      orderby obj.EventDate
                      select obj;
            return res;

        }

      

        //Showing all the dinners in the table
        public IQueryable<tbl_Dinner> ShowAllDinners()
        {
            var res = from obj in context.tbl_Dinners
                      orderby obj.EventDate
                      select obj;
            return res;
        }

        //showing just one dinner by id
        public tbl_Dinner ShowById(int id)
        {
            var res = context.tbl_Dinners.SingleOrDefault(x => x.Dinner_ID == id);
            return res;
        }
        //Inserting Dinner
        public void Insert(tbl_Dinner dinner)
        {
            context.tbl_Dinners.InsertOnSubmit(dinner);
        }

        //Deleting Dinner 
        //we will have to delete it from both the table

        public void Delete(tbl_Dinner dinner)
        {
            context.Tables.DeleteAllOnSubmit(dinner.Tables);
            context.tbl_Dinners.DeleteOnSubmit(dinner);
        }

        public void Save()
        {
            context.Connection.Open();
            context.SubmitChanges();
            context.Connection.Close();
        }
    }
}