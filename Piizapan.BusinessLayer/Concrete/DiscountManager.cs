﻿using Piizapan.BusinessLayer.Abstract;
using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piizapan.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TDelete(Discount t)
        {
            _discountDal.Delete(t);
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> TGetList()
        {
            return _discountDal.GetList();
        }

        public void TInsert(Discount t)
        {
            _discountDal.Insert(t);
        }

        public void TUpdate(Discount t)
        {
            _discountDal.Update(t);
        }
    }
}
