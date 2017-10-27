using EmbeddedStock.Models;

namespace EmbeddedStock.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class ESImageRepository : IESImageRepository
    {
        public void CreateESImage(ESImage image)
        {
            using (var db = new DatabaseContext())
            {
                db.EsImages.Add(image);
                db.SaveChanges();
            }
        }

        public ESImage GetESImage(long esimageId)
        {
            using (var db = new DatabaseContext())
            {
                return db.EsImages.Find(esimageId);
            }
        }

        public void UpdateESIamge(ESImage newImage)
        {
            using (var db = new DatabaseContext())
            {
                var esimage = db.EsImages.Find(newImage.ESImageId);
                db.Entry(esimage).CurrentValues.SetValues(newImage);
                db.SaveChanges();
            }
        }

        public void DeleteESImage(long esimageId)
        {
            using (var db = new DatabaseContext())
            {
                db.EsImages.Remove(db.EsImages.Find(esimageId));
                db.SaveChanges();
            }
        }
    }
}