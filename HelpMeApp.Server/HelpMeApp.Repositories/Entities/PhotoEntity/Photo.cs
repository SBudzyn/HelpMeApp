using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;

namespace HelpMeApp.DatabaseAccess.Entities.PhotoEntity
{
    public class Photo
    {
        public int Id { get; set; }

        public int AdvertId { get; set; }
        public Advert Advert { get; set; } = null!;

        public byte[] Data { get; set; } = null!;
    }
}