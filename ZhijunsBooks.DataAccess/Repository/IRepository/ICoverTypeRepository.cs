using ZhijunsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhijunsBooks.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
