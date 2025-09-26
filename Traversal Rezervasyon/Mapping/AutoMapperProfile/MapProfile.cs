using AutoMapper;
using DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;

namespace Traversal_Rezervasyon.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementDTOs>();
        }
    }
}
