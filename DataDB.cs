using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPartsStore.Models.DB;
using AutoPartsStore.Models;

namespace AutoPartsStore
{
    public class DataDB
    {
        public List<Brands> GetBrands()
        {
            //  создании контекста данных
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                // получаем объекты из бд
                return db.Brands.ToList();
            }
        }

        public void AddBrand(Brands br)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Brands.Add(br); // добавление
                db.SaveChanges(); // сохранение изменений
            }
        }

        public void EditBrand(Brands br)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                
                var b = db.Brands.Where(x => x.IdBrand == br.IdBrand).FirstOrDefault(); // филттрация полчаемых данных по условию                
                b.Name = br.Name; // обновляем объект
                db.SaveChanges(); // сохранение изменений
            }
                
        }

        public void DelBrand(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var b = db.Brands.Where(x => x.IdBrand == id).FirstOrDefault();
                db.Brands.Remove(b);
                db.SaveChanges();
            }
        }


        public List<Models.DB.Models> GetModels()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Models.ToList();
            }
        }

        public List<Auto> GetAuto()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from m in db.Models
                        join b in db.Brands on m.FkIdBrand equals b.IdBrand //объединение таблиц
                        select new Auto // создаем колекцию
                        {
                            IdModel = m.IdModel,
                            ModelBrand = b.Name + " " + m.Name
                        }).ToList();
            }
        }

        public void AddModel(Models.DB.Models model)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Models.Add(model);
                db.SaveChanges();
            }
        }

        public void EditModel(Models.DB.Models model)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var m = db.Models.Where(x => x.IdModel == model.IdModel).FirstOrDefault();
                m.FkIdBrand = model.FkIdBrand;
                m.Name = model.Name;
                db.SaveChanges();
            }

        }

        public void DelModel(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var m = db.Models.Where(x => x.IdModel == id).FirstOrDefault();
                db.Models.Remove(m); // Удаляем модель
                db.SaveChanges();
            }
        }

        public List<Categories> GetCategories()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Categories.ToList();
            }
        }

        public void AddCategory(Categories c)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Categories.Add(c);
                db.SaveChanges();
            }
        }

        public void EditCategory(Categories cat)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.Categories.Where(x => x.IdCategory == cat.IdCategory).FirstOrDefault();
                c.Name = cat.Name;
                db.SaveChanges();
            }

        }

        public void DelCategory(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.Categories.Where(x => x.IdCategory == id).FirstOrDefault();
                db.Categories.Remove(c);
                db.SaveChanges();
            }
        }

        public List<Manufacturers> GetManuf()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Manufacturers.ToList();
            }
        }

        public void AddManuf(Manufacturers m)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Manufacturers.Add(m);
                db.SaveChanges();
            }
        }

        public void EditManuf(Manufacturers manuf)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var m = db.Manufacturers.Where(x => x.IdManufacturer == manuf.IdManufacturer).FirstOrDefault();
                m.Name = manuf.Name;
                db.SaveChanges();
            }
        }

        public void DelManuf(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var m = db.Manufacturers.Where(x => x.IdManufacturer == id).FirstOrDefault();
                db.Manufacturers.Remove(m);
                db.SaveChanges();
            }
        }

        public List<Stock> GetStocks()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Stock.ToList();
            }
        }

        public void AddStock(Stock m)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Stock.Add(m);
                db.SaveChanges();
            }
        }

        public void EditStock(Stock stock)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Stock.Where(x => x.IdStock == stock.IdStock).FirstOrDefault();
                s.Number = stock.Number;
                s.Address = stock.Address;
                db.SaveChanges();
            }
        }

        public void DelStock(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Stock.Where(x => x.IdStock == id).FirstOrDefault();
                db.Stock.Remove(s);
                db.SaveChanges();
            }
        }

        public List<CellsStocks> GetCellsStock()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.CellsStocks.ToList();
            }
        }

        public List<Cmb> GetCellStockCmb()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return (from c in db.CellsStocks
                        join s in db.Stock on c.FkIdStock equals s.IdStock
                        select new Cmb
                        {
                            IdCmb = c.IdCell,
                            NameCmb = "Склад №" + s.Number + " ячейка №" + c.Number
                        }).ToList();
            }
        }

        public void AddCell(CellsStocks c)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.CellsStocks.Add(c);
                db.SaveChanges();
            }
        }

        public void EditCell(CellsStocks cl)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.CellsStocks.Where(x => x.IdCell == cl.IdCell).FirstOrDefault();
                c.Number = cl.Number;
                c.FkIdStock = cl.FkIdStock;
                db.SaveChanges();
            }
        }

        public void DelCell(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.CellsStocks.Where(x => x.IdCell == id).FirstOrDefault();
                db.CellsStocks.Remove(c);
                db.SaveChanges();
            }
        }

        public List<Products> GetProducts()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Products.ToList();
            }
        }

        public void AddProduct(Products p)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
        }

        public void EditProduct(Products pr)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var p = db.Products.Where(x => x.IdProduct == pr.IdProduct).FirstOrDefault();
                p.Name = pr.Name;
                db.SaveChanges();
            }
        }

        public void DelProduct(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var p = db.Products.Where(x => x.IdProduct == id).FirstOrDefault();
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }

        public List<SpareParts> GetSpareParts(int idProd)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.SpareParts.Where(x => x.FkIdProduct == idProd).ToList();
            }
        }

        public void AddSparePart(SpareParts sp)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.SpareParts.Add(sp);
                db.SaveChanges();
            }
        }

        public void EditSparePart(SpareParts spareParts)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var sp = db.SpareParts.Where(x => x.IdSparePart == spareParts.IdSparePart).FirstOrDefault();
                sp.Code = spareParts.Code;
                sp.FkIdCategory = spareParts.FkIdCategory;
                sp.FkIdManuf = spareParts.FkIdManuf;
                sp.FkIdModel = spareParts.FkIdModel;
                sp.Price = spareParts.Price;
                db.SaveChanges();
            }
        }

        public void DelSparePart(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.SpareParts.Where(x => x.IdSparePart == id).FirstOrDefault();
                db.SpareParts.Remove(s);
                db.SaveChanges();
            }
        }

        public List<Supplies> GetSupplies()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Supplies.ToList();
            }
        }

        public void AddSupplies(Supplies sp)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Supplies.Add(sp);
                db.SaveChanges();
            }
        }

        public void EditSupplies(Supplies sp)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Supplies.Where(x => x.IdSupply == sp.IdSupply).FirstOrDefault();
                s.Date = sp.Date;
                s.FkIdSparePart = sp.FkIdSparePart;
                s.Amount = sp.Amount;
                s.Price = sp.Price;
                db.SaveChanges();
            }
        }

        public void DelSupplies(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Supplies.Where(x => x.IdSupply == id).FirstOrDefault();
                db.Supplies.Remove(s);
                db.SaveChanges();
            }
        }

        public List<SpareParts> GetSparePartCmb()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.SpareParts.ToList();
            }
        }

        public List<SparePartStock> GetSPStock()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.SparePartStock.ToList();
            }
        }

        public void AddSPStock(SparePartStock sp)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.SparePartStock.Add(sp);
                db.SaveChanges();
            }
        }

        public void EditSPStock(SparePartStock sp)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.SparePartStock.Where(x => x.IdSpStock == sp.IdSpStock).FirstOrDefault();
                s.FkIdCell = sp.FkIdCell;
                s.FkIdSparePart = sp.FkIdSparePart;
                s.Amount = sp.Amount;
                db.SaveChanges();
            }
        }

        public void DelSPStock(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.SparePartStock.Where(x => x.IdSpStock == id).FirstOrDefault();
                db.SparePartStock.Remove(s);
                db.SaveChanges();
            }
        }

        public List<DefectiveGoods> GetDefective()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.DefectiveGoods.ToList();
            }
        }

        public void AddDefective(DefectiveGoods dg)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.DefectiveGoods.Add(dg);
                db.SaveChanges();
            }
        }

        public void EditDefective(DefectiveGoods dg)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var d = db.DefectiveGoods.Where(x => x.IdDefect == dg.IdDefect).FirstOrDefault();
                d.FkIdSupplies = dg.FkIdSupplies;
                d.Amount = dg.Amount;
                db.SaveChanges();
            }
        }

        public void DelDefective(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var dg = db.DefectiveGoods.Where(x => x.IdDefect == id).FirstOrDefault();
                db.DefectiveGoods.Remove(dg);
                db.SaveChanges();
            }
        }

        public List<Clients> GetClients()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Clients.ToList();
            }
        }

        public void AddClient(Clients c)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Clients.Add(c);
                db.SaveChanges();
            }
        }

        public void EditClient(Clients cl)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.Clients.Where(x => x.IdClient == cl.IdClient).FirstOrDefault();
                c.Fio = cl.Fio;
                c.Phone = cl.Phone;
                db.SaveChanges();
            }
        }

        public void DelClient(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var c = db.Clients.Where(x => x.IdClient == id).FirstOrDefault();
                db.Clients.Remove(c);
                db.SaveChanges();
            }
        }

        public List<Sales> GetSales()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Sales.ToList();
            }
        }

        public void AddSale(Sales s)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Sales.Add(s);
                db.SaveChanges();
            }
        }

        public void EditSale(Sales sa)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Sales.Where(x => x.IdSale == sa.IdSale).FirstOrDefault();
                s.Date = sa.Date;
                s.FkIdSparePart = sa.FkIdSparePart;
                s.FkIdClient = sa.FkIdClient;
                s.Amount = sa.Amount;
                s.TotalPrice = sa.TotalPrice;
                db.SaveChanges();
            }
        }

        public void DelSale(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var s = db.Sales.Where(x => x.IdSale == id).FirstOrDefault();
                db.Sales.Remove(s);
                db.SaveChanges();
            }
        }

        public List<Applications> GetApp()
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                return db.Applications.ToList();
            }
        }

        public void AddApp(Applications a)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                db.Applications.Add(a);
                db.SaveChanges();
            }
        }

        public void EditApp(Applications app)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var a = db.Applications.Where(x => x.IdApplication == app.IdApplication).FirstOrDefault();
                
                a.FkIdSparePart = app.FkIdSparePart;
                a.FkIdClient = app.FkIdClient;
                db.SaveChanges();
            }
        }

        public void DelApp(int id)
        {
            using (AutoPartsStoreContext db = new AutoPartsStoreContext())
            {
                var a = db.Applications.Where(x => x.IdApplication == id).FirstOrDefault();
                db.Applications.Remove(a);
                db.SaveChanges();
            }
        }

    }
}
