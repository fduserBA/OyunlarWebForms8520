using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunlarWinForms._1_Entities;
using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;

namespace OyunlarWinForms._2_Business.Services
{
    public class OyunService
    {
        private OyunlarDB db = new OyunlarDB();

        public List<OyunModel> GetList()
        {
            try
            {
                // SQL Ortamı
                /*
                select Oyun.Adi, Oyun.Id, Oyun.Kazanci, Oyun.Maliyeti, Oyun.YilId, 
                Tur.Id, Tur.Adi
                from Oyun 
                left outer join OyunTur on Oyun.Id = OyunTur.OyunId
                left outer join Tur on OyunTur.TurId = Tur.Id
                order by Oyun.Adi
                */
                List<OyunModel> oyunlar = db.Oyun.OrderBy(o => o.Adi).Select(o => new OyunModel()
                {
                    Adi = o.Adi,
                    Id = o.Id,
                    Kazanci = o.Kazanci,
                    Maliyeti = o.Maliyeti,
                    YilId = o.YilId,
                    Turler = o.OyunTur.Select(ot => new TurModel()
                    {
                        Id = ot.Tur.Id, // ot.TurId
                        Adi = ot.Tur.Adi
                    }).ToList()
                }).ToList();

                // C# Ortamı
                oyunlar = oyunlar.Select(o => new OyunModel()
                {
                    Adi = o.Adi,
                    Id = o.Id,
                    Kazanci = o.Kazanci,
                    Maliyeti = o.Maliyeti,
                    YilId = o.YilId,
                    Turler = o.Turler,

                    KarZarar = ((o.Kazanci ?? 0) - (o.Maliyeti ?? 0)).ToString(new CultureInfo("tr")) + " TL"
                }).ToList();
                return oyunlar;
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public OyunModel GetById(int id)
        {
            try
            {
                // select * from Oyun where Id = id
                var entity = db.Oyun.Find(id); // db.Oyun: SQL Ortamı

                // C# Ortamı
                return new OyunModel()
                {
                    Adi = entity.Adi,
                    Id = entity.Id,
                    Kazanci = entity.Kazanci,
                    Maliyeti = entity.Maliyeti,
                    YilId = entity.YilId,
                    Turler = entity.OyunTur.Select(ot => new TurModel()
                    {
                        Id = ot.TurId,
                        Adi = ot.Tur.Adi
                    }).ToList()
                };
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public Islem Add(OyunModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizDegerBos;
                }
                if (model.YilId == -1)
                {
                    return Islem.BasarisizDegerBos;
                }

                //var oyunEntity = db.Oyun.SingleOrDefault(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim());
                //if (oyunEntity != null)
                //{
                //    return Islem.BasarisizKayitVar;
                //}
                //int oyunCount = db.Oyun.Count(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim());
                //if (oyunCount > 0)
                //{
                //    return Islem.BasarisizKayitVar;
                //}
                if (db.Oyun.Any(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim()))
                {
                    return Islem.BasarisizKayitVar;
                }

                var entity = new Oyun()
                {
                    //Id = 0,
                    Adi = model.Adi.Trim(),
                    Kazanci = model.Kazanci,
                    Maliyeti = model.Maliyeti,
                    YilId = model.YilId,
                    OyunTur = model.Turler.Select(t => new OyunTur()
                    {
                        //OyunId = 0,
                        TurId = t.Id
                    }).ToList()
                };
                db.Oyun.Add(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                //throw e;
                return Islem.Hata;
            }
        }

        public Islem Update(OyunModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Adi))
                {
                    return Islem.BasarisizDegerBos;
                }
                if (model.YilId == -1)
                {
                    return Islem.BasarisizDegerBos;
                }
                if (db.Oyun.Any(o => o.Adi.ToUpper() == model.Adi.ToUpper().Trim() && o.Id != model.Id))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = db.Oyun.Find(model.Id);
                entity.Adi = model.Adi.Trim();
                entity.Kazanci = model.Kazanci;
                entity.Maliyeti = model.Maliyeti;
                entity.YilId = model.YilId;
                db.OyunTur.RemoveRange(entity.OyunTur);
                entity.OyunTur = model.Turler.Select(t => new OyunTur()
                {
                    //OyunId = entity.Id,
                    TurId = t.Id
                }).ToList();
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                //throw e;
                return Islem.Hata;
            }
        }

        public Islem Delete(int id)
        {
            try
            {
                var entity = db.Oyun.Find(id);
                db.OyunTur.RemoveRange(entity.OyunTur);
                db.Oyun.Remove(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                //throw e;
                return Islem.Hata;
            }
        }
    }
}

