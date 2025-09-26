using AutoMapper;
using DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;

namespace Traversal_Rezervasyon.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();

            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTO>();
        }
    }
}
