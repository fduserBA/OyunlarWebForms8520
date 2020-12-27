using System.Collections.Generic;
using System.Linq;
using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;

namespace OyunlarWebForms.BaBusiness
{
    /// <summary>
    /// Entity ve modeller üzerinden listeleme, detay, ekleme, güncelleme ve silme işlemlerini gerçekleştirdiğimiz sınıf
    /// </summary>
    public class TurService
    {
        private OyunlarContext db = new OyunlarContext();

        /// <summary>
        /// Entity listesini modele dönüştürerek geri dönen listeleme methodu
        /// </summary>
        /// <returns></returns>
        public List<TurModel> GetList()
        {
            return db.Tur.Select(tur => new TurModel()
            {
                Id = tur.Id,
                Adi = tur.Adi
            }).ToList();
        }

        /// <summary>
        /// Herhangi bir id'ye sahip tek bir entity'i modele dönüştürerek geri dönen detay methodu
        /// </summary>
        /// <returns></returns>
        public TurModel GetById(int id)
        {
            var entity = db.Tur.SingleOrDefault(tur => tur.Id == id);
            return new TurModel()
            {
                Id = entity.Id,
                Adi = entity.Adi
            };
        }
    }
}