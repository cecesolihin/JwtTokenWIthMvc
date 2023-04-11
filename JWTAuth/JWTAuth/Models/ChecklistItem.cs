using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWTAuth.Models
{
    public class ChecklistItem
    {
        public int ChecklistId { get; set; }
        public int ChecklistItemId { get; set; }
        public string ItemName { get; set; }
    }
}