using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using JWTAuth.Models;
using JWTAuth.Repository;
namespace JWTAuth.Controllers
{
   //[System.Web.Http.RoutePrefix("api/checklist")]
    public class ChecklistController : ApiController
    {
        ///private readonly IChecklistRepository repo;
        private ChecklistRepository repo = new ChecklistRepository();
        public ChecklistController()
        {
                
        }
        ////public ChecklistController(IChecklistRepository checklistRepository)
        ////{
        ////    repo = checklistRepository;
        ////}
        //Get All Checklist
       // [System.Web.Http.Route("checklist")]
        [System.Web.Http.HttpGet]
        public IList<Checklist> GetAllChecklist()
        {
            List<Checklist> data = new List<Checklist>();
            try
            {
                 data = (List<Checklist>)repo.GetAllChecklist();
            }
            catch (Exception ex)
            {

                throw;
            }
            return data;
        }
        //Create new checklist
        //[System.Web.Http.Route("checklist")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateChecklist(Checklist checklist)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.CreateChecklist(checklist);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
        //Delete checklist by ID
        //[System.Web.Http.Route("{checklistid:int}")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage DeleteChecklist(int checklistId)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.DeleteChecklist(checklistId);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
        //Get all Checklist Item by checklist id
       // [System.Web.Http.Route("{checklistid}/item")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item")]
        [System.Web.Http.HttpGet]
        public IList<ChecklistItem> GetAllChecklistItembyChecklistId(int checklistId)
        {
            List<ChecklistItem> data = new List<ChecklistItem>();
            try
            {
                data = (List<ChecklistItem>)repo.GetAllChecklistItemByChecklistId(checklistId);
            }
            catch (Exception ex)
            {

                throw;
            }
            return data;
        }
        //Create new checklist item in checklist
        //[System.Web.Http.Route("{checklistid}/item")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateChecklistItem(int checklistId, ChecklistItem checklistItem)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.CreateItemByChecklistId(checklistId, checklistItem);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
        //Get checklist item in checklist by checklist id
        
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item/{checklistitemid:int}")]
        [System.Web.Http.HttpGet]
        public IList<ChecklistItem> GetChecklistItembyChecklistId(int checklistId, int checklistItemId)
        {
            List<ChecklistItem> data = new List<ChecklistItem>();
            try
            {
                data = (List<ChecklistItem>)repo.GetChecklistItemById(checklistId, checklistItemId);
            }
            catch (Exception ex)
            {

                throw;
            }
            return data;
        }
        //Update status checklist item by checklist item id
        //[System.Web.Http.Route("{checklistid}/item/{checklistitemid}")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item/{checklistitemid:int}")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdateChecklistItemByChecklistId(int checklistId, ChecklistItem checklistItem)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.UpdateChecklistItemByChecklistId(checklistId, checklistItem);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
        //Delete item by checklist item id
        //[System.Web.Http.Route("{checklistid}/item/{checklistitemid}")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item/{checklistitemid:int}")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage DeleteChecklistItem(int checklistId, int checklistItemId)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.DeleteChecklistItemByChecklistId(checklistId, checklistItemId);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
        //Rename item by checlist item id
        //[System.Web.Http.Route("{checklistid}/item/{checklistitemid}")]
        [System.Web.Http.Route("~/api/checklist/{checklistid:int}/item/{checklistitemid:int}")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdateChecklistItem(int checklistId, ChecklistItem checklistItem)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.UpdateChecklistsItemByChecklistItemId(checklistId, checklistItem);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }

    }
}
