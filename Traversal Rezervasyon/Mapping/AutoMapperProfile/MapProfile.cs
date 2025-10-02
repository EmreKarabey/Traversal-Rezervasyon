using AutoMapper;
using DTOs.AnnouncementDTOs;
using DTOs.ContentDTOs;
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

            CreateMap<ContentUs, SendContentDTOs>();
            CreateMap<SendContentDTOs, ContentUs>();

           
        }
    }
}
