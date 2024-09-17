using System;
using System.Collections.Generic;
using System.Text;
using AutoPartsStore.Models.DB;
using AutoPartsStore.Models;
using System.Linq;

namespace AutoPartsStore
{
    public class DataTask
    {
        public List<FT5> GetFT1(int idCat)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Supplies
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        join m in db.Manufacturers on sp.FkIdManuf equals m.IdManufacturer
                        where sp.FkIdCategory == idCat
                        group m by new { m.Name} into g //группировка данных по определенным критериям
                        select new FT5
                        {
                            Name = g.Key.Name
                        }).ToList();
            }
        }

        public List<FT2> GetFT2(int idCat)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Supplies
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        join m in db.Manufacturers on sp.FkIdManuf equals m.IdManufacturer
                        where sp.FkIdCategory == idCat
                        select new FT2
                        {
                            Date = s.Date,
                            Price = s.Price,
                            Manuf = m.Name
                        }).ToList();
            }
        }

        public List<FT3> GetFT3(int idCat, DateTime sDate, DateTime eDate)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Sales
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        join c in db.Clients on s.FkIdClient equals c.IdClient
                        where sp.FkIdCategory == idCat && s.Date >= sDate && s.Date <= eDate
                        select new FT3
                        {
                           FIO = c.Fio
                        }).ToList();
            }
        }

        public List<FT4> GetFT4()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from sps in db.SparePartStock
                        join sp in db.SpareParts on sps.FkIdSparePart equals sp.IdSparePart
                        join cs in db.CellsStocks on sps.FkIdCell equals cs.IdCell
                        join s in db.Stock on cs.FkIdStock equals s.IdStock
                        select new FT4
                        {
                            Name = sp.Code,
                            Amount = sps.Amount,
                            StockCell = "Склад №" + s.Number + " ячейка №" + cs.Number
                        }).ToList();
            }
        }

        public List<FT5> GetFT5()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Sales
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        select new { sp.Code, s.Amount } into x
                        group x by new { x.Code } into g
                        orderby g.Select(x => x.Amount).Count()
                        select new FT5
                        {
                            Name = g.Key.Code,
                            Count = g.Select(x => x.Amount).Count()
                        }).Take(10).ToList();
            }
        }

        public List<FT5> GetFT51()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Supplies
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        join m in db.Manufacturers on sp.FkIdManuf equals m.IdManufacturer
                        select new { m.Name, s.Price } into x
                        group x by new { x.Name } into g
                        orderby g.Select(x => x.Price).Sum()
                        select new FT5
                        {
                            Name = g.Key.Name,
                        }).Take(10).ToList();
            }
        }

        public FT5 GetFT6(int idProd, int month)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var total = db.Sales.Count();
                var sales = (from s in db.Sales
                             join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                             join p in db.Products on sp.FkIdProduct equals p.IdProduct
                             where sp.FkIdProduct == idProd && s.Date.Month == month
                             group p by new {p.Name} into g
                             select new FT5
                             {
                                 Name = g.Key.Name,
                                 Count = total / g.Count()
                             }).FirstOrDefault();
                return sales;
            }
        }

        public FT7 GetFT7()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.SpareParts
                           where s.FkIdManuf == 4
                           group s by 1 into g
                           select new FT7
                           {
                               Percent = Math.Round(g.Count() / Convert.ToDecimal(db.SpareParts.Count()), 2) * 100,
                               Price = Math.Round(g.Sum(x => (decimal)x.Price) / Convert.ToDecimal(db.SpareParts.Sum(x => x.Price)), 2) * 100,
                               Ed = Math.Round(g.Count() / (decimal)db.SpareParts.Count(), 2)
                           }).FirstOrDefault();
            }
        }

        public decimal GetFT8()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Supplies.Sum(x => x.Price) / db.Sales.Sum(x => x.TotalPrice) * 100;
            }
        }

        public List<FT9> GetFT9()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from sp in db.SpareParts 
                        join sps in db.SparePartStock on sp.IdSparePart equals sps.FkIdSparePart
                        join s in db.Sales on sp.IdSparePart equals s.FkIdSparePart into gj
                        from x in gj.DefaultIfEmpty()
                        where x == null
                        select new FT9
                        {
                            Code = sp.Code,
                        }).ToList();
            }
        }

        public int GetCountSparePartStock()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.SparePartStock.Count();
            }
        }


        public List<FT10> GetFT10()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from d in db.DefectiveGoods
                        join s in db.Supplies on d.FkIdSupplies equals s.IdSupply
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        join m in db.Manufacturers on sp.FkIdManuf equals m.IdManufacturer
                        select new FT10
                        {
                            Code = sp.Code,
                            Manuf = m.Name
                        }).ToList();
            }
        }

        public List<FT11> GetFT11(DateTime date)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from s in db.Sales
                        join sp in db.SpareParts on s.FkIdSparePart equals sp.IdSparePart
                        where s.Date == date
                        select new FT11
                        {
                            Code = sp.Code,
                            Amount = s.Amount,
                            Price = s.TotalPrice
                        }).ToList();
            }
        }

        public List<FT12> GetFT12(DateTime sDate, DateTime eDate)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                List<FT12> inc = (from s in db.Sales
                                  where s.Date >= sDate && s.Date <= eDate
                                  select new FT12
                                  {
                                      Date = s.Date,
                                      Income = s.TotalPrice
                                  }).ToList();
                List<FT12> exp = (from s in db.Supplies
                                  where s.Date >= sDate && s.Date <= eDate
                                  select new FT12
                                  {
                                      Date = s.Date,
                                      Expense = s.Price
                                  }).ToList();
                foreach (var e in exp)
                {
                    inc.Add(new FT12
                    {
                        Date = e.Date,
                        Expense = e.Expense
                    });
                }
                return inc;
            }
        }

        public List<FT13> GetFT13()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from sps in db.SparePartStock
                        join sp in db.SpareParts on sps.FkIdSparePart equals sp.IdSparePart
                        join cs in db.CellsStocks on sps.FkIdCell equals cs.IdCell
                        join s in db.Stock on cs.FkIdStock equals s.IdStock
                        select new FT13
                        {
                            Code = sp.Code,
                            Price = sp.Price,
                            StockCell = "Склад №" + s.Number + " ячейка №" + cs.Number,
                            Amount = sps.Amount,
                            TotalPrice = Convert.ToDecimal(sp.Price * sps.Amount)
                        }).ToList();
            }
        }

        public List<FT14> GetFT14()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from sp in db.SpareParts
                        join su in db.Supplies on sp.IdSparePart equals su.FkIdSparePart
                        join s in db.Sales on sp.IdSparePart equals s.FkIdSparePart             
                        select new FT14
                        {
                            Code = sp.Code,
                            DateSale = s.Date,
                            DateSupply = su.Date,
                            Day = (s.Date - su.Date).TotalDays
                        }).ToList();
            }
        }

        public List<FT15> GetFT15()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from cs in db.CellsStocks
                        join s in db.Stock on cs.FkIdStock equals s.IdStock
                        join sps in db.SparePartStock on cs.IdCell equals sps.FkIdCell into gj
                        from x in gj.DefaultIfEmpty()
                        where x == null
                        select new { s.Number, cs.Capacity } into y
                        group y by new { y.Number } into g
                        select new FT15
                        {
                            Name = "Склад №" + g.Key.Number,
                            Cell = g.Count(),
                            Count = g.Select(x => x.Capacity).Sum()
                        }).ToList();
            }
        }

        public List<FT16> GetFT16()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from a in db.Applications
                        join c in db.Clients on a.FkIdClient equals c.IdClient
                        join sp in db.SpareParts on a.FkIdSparePart equals sp.IdSparePart
                        select new FT16
                        {
                            Client = c.Fio,
                            Code = sp.Code,
                            Price = sp.Price
                        }).ToList();
            }
        }
    }
}
