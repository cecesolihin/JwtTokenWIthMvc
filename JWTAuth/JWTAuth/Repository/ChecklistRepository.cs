using Dapper;
using JWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JWTAuth.Repository
{
    public class ChecklistRepository : IChecklistRepository
    {
        public readonly string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();

        public void CreateChecklist(Checklist checklist)
        {

            var sql = @"Insert Into dbo.Checklist values(@name)";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new {checklist.Name});
            }
        }

        public void CreateItemByChecklistId(int checklistId,ChecklistItem checklistItem)
        {
            var sql = @"Insert Into dbo.ChecklistItem (ChecklistId,ItemName) values (@ChecklistId,@ItemName)";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new { checklistId, checklistItem.ItemName});
            }
        }

        public void DeleteChecklist(int checklistId)
        {
            var sql = @"Delete From dbo.Checklist where ChecklistId=@ChecklistId";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new { checklistId});
            }
        }

        public void DeleteChecklistItemByChecklistId(int checklistId, int checklistItemId)
        {
            var sql = @"Delete From dbo.ChecklistItem where ChecklistId=@ChecklistId and ChecklistItemId=@ChecklistItemId";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql,new { checklistId, checklistItemId});
            }
        }

        public IList<Checklist> GetAllChecklist()
        {
            IList<Checklist> listdata = new List<Checklist>();
            try
            {
                var sql = @"SELECT  ChecklistId,Name FROM dbo.Checklist";

                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    listdata = db.Query<Checklist>(sql).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listdata;
        }

        public IList<ChecklistItem> GetAllChecklistItemByChecklistId(int checklistId)
        {
            IList<ChecklistItem> listdata = new List<ChecklistItem>();
            try
            {
                var sql = @"SELECT ChecklistId ,ChecklistItemId,ItemName FROM dbo.ChecklistItem where ChecklistId=@ChecklistId";

                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    listdata = db.Query<ChecklistItem>(sql, new { checklistId}).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listdata;
        }

        public IList<ChecklistItem> GetChecklistItemById(int checklistId, int checklistItemId)
        {
            IList<ChecklistItem> listdata = new List<ChecklistItem>();
            try
            {
                var sql = @"SELECT ChecklistId ,ChecklistItemId,ItemName 
                            FROM dbo.ChecklistItem 
                            where ChecklistId=@ChecklistId 
                            and ChecklistItemId=@ChecklistItemId";


                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    listdata = db.Query<ChecklistItem>(sql , new { checklistId, checklistItemId}).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listdata;
        }

        public void UpdateChecklist(Checklist checklist)
        {
            var sql = @"Update dbo.Checklist set Name=@name where ChecklistId=@ChecklistId";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new { checklist.Name, checklist.ChecklistId});
            }
        }

        public void UpdateChecklistItemByChecklistId(int checklistId,ChecklistItem checklistItem)
        {
            var sql = @"Update dbo.ChecklistItem set ItemName=@ItemName where ChecklistId=@ChecklistId";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new {  checklistItem.ItemName, checklistId});
            }
        }

    

        public void UpdateChecklistsItemByChecklistItemId(int checklistId, ChecklistItem checklistItem)
        {
            var sql = @"Update dbo.ChecklistItem 
                        set ItemName=@ItemName 
                        where ChecklistId=@ChecklistId 
                        and ChecklistItemId=@ChecklistItemId";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var exec = db.Execute(sql, new { checklistItem.ItemName, checklistId, checklistItem.ChecklistItemId });
            }
        }
    }
}