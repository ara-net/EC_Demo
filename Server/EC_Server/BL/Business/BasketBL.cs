﻿using EC_Server.BL.Interface;
using EC_Server.DTO;
using EC_Server.Model;
using EC_Server.Tools;
using static EC_Server.Tools.Extension;

namespace EC_Server.BL.Business
{
    public class BasketBL : BlBase, IBasketBL
    {
        private readonly EiContext db;

        public BasketBL(EiContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<ApiResultDTO> Get()
        {
            var data = await (from b in db.Baskets
                              from bd in db.BasketDetail.Where(m => m.BasketId == b.Id)
                              from p in db.Products.Where(m => m.Id == bd.ProductId)
                              from fbh in db.BasketHistory.Where(m => m.BasketId == b.Id && m.Status == BasketStatus.Created)
                              from ebh in db.BasketHistory.Where(m => m.BasketId == b.Id).OrderByDescending(m => m.Id).Take(1)
                              from cu in db.Users.Where(m => m.UserId == fbh.UserId)
                              from eu in db.Users.Where(m => m.UserId == ebh.UserId)
                              select new BasketDTO
                              {
                                  basketId = b.Id,
                                  CreateDateEn = b.CreateDate,
                                  Quantity = bd.Quantity,
                                  Title = p.Title,
                                  Unit = p.UnitType,
                                  Fee = bd.Fee,
                                  Status = ebh.Status,
                                  StatusDateTimeEn = ebh.StatusDateTime,
                                  CustomerName = cu.FullName,
                                  EmployeeName = eu.FullName,
                              }).ToListAsync();

            var result = data.GroupBy(m => m.basketId).Select(n => new BasketDTO
            {
                CreateDateEn = n.First().CreateDateEn,
                Quantity = n.Sum(o => o.Quantity),
                Status = n.First().Status,
                StatusDateTimeEn = n.First().StatusDateTimeEn,
                TotalPrice = n.Sum(o => o.Price),
                CustomerName = n.First().CustomerName,
                EmployeeName = n.First().EmployeeName,
                basketId = n.Key
            }).OrderByDescending(m => m.basketId).ToList();

            return GetSuccessResult(result);
        }

        public async Task<ApiResultDTO> Get(Guid basketId)
        {
            var data = db.BasketDetail.Where(m => m.BasketId == basketId)
                .Include(m => m.Product)
                .Select(m => new BasketDetailDTO
                {
                    Quantity = m.Quantity,
                    UnitPrice = m.Fee,
                    Title = m.Product.Title,
                    UnitType = m.Product.UnitType
                });
            return GetSuccessResult(await data.ToListAsync());
        }
        public async Task<ApiResultDTO> SetStatus(statusUpdateDTO data)
        {
            db.BasketHistory.Add(new BasketHistory
            {
                BasketId = data.BasketId,
                Status = data.Status,
                StatusDateTime = DateTime.Now,
                UserId = data.UserId
            });

            return await db.SaveChangesAsync() > 0 ? GetSuccessResult(data) : GetFailResult(); ;

        }
    }
}
