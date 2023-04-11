using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTAuth.Models;


namespace JWTAuth.Repository
{
    public interface IChecklistRepository
    {
        IList<Checklist> GetAllChecklists();
        void Create(Checklist checklist);
        void Update(Checklist checklist);
        void Delete(int checklistId);

        //Checklist Item
        IList<ChecklistItem> GetAllChecklistsItemByChecklistId(int checklistId);
        void CreateItemByChecklistId(Checklist checklist);
        IList<ChecklistItem> GetChecklistsItemById(int checklistId, int checklistItemId);
        void UpdateChecklistsItemByChecklistId(int checklistId, ChecklistItem checklistItem);
        void DeleteChecklistsItemByChecklistId(int checklistId, int checklistItemId);
        //void UpdateChecklistsItemByChecklistId(int checklistId, ChecklistItem checklistItem);

    }
}
