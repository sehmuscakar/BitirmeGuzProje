using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPostContactManager
    {
        List<PostContact> GetList();
        void Add(PostContact postContact);
        void Update(PostContact postContact);
        void Remove(PostContact postContact);
       PostContact GetByID(int id);
    }
}
