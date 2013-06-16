using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.DAL;

namespace RedCross.Models.BusinessModels
{
    public class ImportantEventService:IImportantEventService
    {
        private Service<ImportantEvent> service;

        public ImportantEventService()
        {
            service = new Service<ImportantEvent>();
        }

        public ResponseStatus GetImportantEvents(HttpRequestBase req, Paginate paginate, Container_List_ImportantEvent conta_ImportantEvent)
        {
            return service.GetMuti(req,
                () => new ImportantEventDAL(),
                conta_ImportantEvent.List_ImportantEvent,
                paginate);
        }

        public ResponseStatus GetImportantEvent(int id, Func<ImportantEvent> m_func)
        {
            return service.GetSingle(id,
                m_func,
                () => new ImportantEventDAL());
        }

        public ResponseStatus AddImportantEvent(HttpRequestBase req)
        {
            return service.Add(req,
                () => new ImportantEvent(),
                ()=> new ImportantEventDAL(),
                (importantEvent) =>
                {
                    this.SetValue(req, importantEvent,true);
                });
        }

        private void SetValue(HttpRequestBase req,ImportantEvent importantEvent,bool isAdd)
        {
            if (!isAdd) importantEvent.Id = Convert.ToInt32(req.Form["id"]);
            importantEvent.Content = req.Form["content"].ToString();
            importantEvent.PublisTime = Convert.ToDateTime(req.Form["publish"]);
        }

        public ResponseStatus DeleteImportantEvent(HttpRequestBase req)
        {
            return service.Delete(req, () => new ImportantEventDAL());
        }

        public ResponseStatus UpdateImportantEvent(HttpRequestBase req)
        {
            return service.Update(req,
                () => new ImportantEvent(),
                () => new ImportantEventDAL(),
                (importantEvent) =>
                {
                    this.SetValue(req, importantEvent,false);
                });
        }
    }
}