using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class NewsManager : INewsService
   {

      private readonly INewsDal _newsService;

      public NewsManager(INewsDal newsService)
      {
         _newsService = newsService;
      }

      public void Delete(News t)
      {
         _newsService.Delete(t);
      }

      public News GetById(int id)
      {
        return _newsService.GetById(id);
      }

      public List<News> GetListAll()
      {
         return _newsService.GetListAll();
      }

      public void Insert(News t)
      {
         _newsService.Insert(t);
      }

      public void Update(News t)
      {
         _newsService.Update(t);
      }
   }
}
