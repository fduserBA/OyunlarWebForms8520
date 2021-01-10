using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;

namespace OyunlarWebForms.BaBusiness
{
    public class YilService
    {
        private OyunlarContext db = new OyunlarContext();

        public List<YilModel> GetList()
        {
            try
            {
                return db.Yil.OrderBy(yil => yil.Degeri).Select(yil => new YilModel()
                {
                    Id = yil.Id,
                    Degeri = yil.Degeri
                }).ToList();
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public YilModel GetById(int id)
        {
            try
            {
                var entity = db.Yil.Find(id);
                return new YilModel()
                {
                    Id = entity.Id,
                    Degeri = entity.Degeri
                };
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public Islem Add(YilModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Degeri))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Yil.Any(yil => yil.Degeri == model.Degeri.Trim()))
                {
                    return Islem.BasarisizKayitVar;
                }
                var entity = new Yil()
                {
                    Degeri = model.Degeri.Trim()
                };
                db.Yil.Add(entity);
                db.SaveChanges();
                return Islem.Basarili;
            }
            catch (Exception e)
            {
                //throw e;
                return Islem.Hata;
            }
        }

        public Islem Update(YilModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Degeri))
                {
                    return Islem.BasarisizBosDeger;
                }
                if (db.Yil.Any(yil => yil.Degeri == model.Degeri.Trim() && yil.Id != model.Id))
                {
                    return Islem.BasarisizKayitVar;
                }

                var entity = db.Yil.Find(model.Id);
                entity.Degeri = model.Degeri;
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
                var entity = db.Yil.Find(id);
                if (entity.Oyun != null && entity.Oyun.Count > 0)
                {
                    return Islem.BasarisizIliskiliKayitVar;
                }
                db.Yil.Remove(entity);
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