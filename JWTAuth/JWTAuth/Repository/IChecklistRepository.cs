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
        IList<Checklist> GetAllChecklist();
        void CreateChecklist(Checklist checklist);
        void UpdateChecklist(Checklist checklist);
        void DeleteChecklist(int checklistId);

        //Checklist Item
        IList<ChecklistItem> GetAllChecklistItemByChecklistId(int checklistId);
        void CreateItemByChecklistId(int checklistId,ChecklistItem checklistItem);
        IList<ChecklistItem> GetChecklistItemById(int checklistId, int checklistItemId);
        void UpdateChecklistItemByChecklistId(int checklistId, ChecklistItem checklistItem);
        void DeleteChecklistItemByChecklistId(int checklistId, int checklistItemId);
        void UpdateChecklistsItemByChecklistItemId(int checklistId, ChecklistItem checklistItem);

    }
}
