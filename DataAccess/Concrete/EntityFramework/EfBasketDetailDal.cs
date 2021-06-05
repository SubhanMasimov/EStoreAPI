﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDetailDal : EfEntityRepositoryBase<BasketDetail, EStoreContext>, IBasketDetailDal
    {
        public new List<BasketDetail> GetAll(Expression<Func<BasketDetail, bool>> expression = null)
        {
            using (EStoreContext context = new EStoreContext())
            {
                return expression == null
                   ? context.Set<BasketDetail>().Include(b => b.Basket).ToList()
                   : context.Set<BasketDetail>().Where(expression).ToList();
            }
        }
    }
}
