using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Containers
{
    public static class ExtensionContainers
    {
        public static void Containers(this IServiceCollection builder)
        {
            builder.AddScoped<ICommentServices, CommentManager>();
            builder.AddScoped<IComment, EFComment>();
            builder.AddScoped<IDestinationServices, DestinationManager>();
            builder.AddScoped<IDestination, EFDestination>();
            builder.AddScoped<IAppUserServices, AppUserManager>();
            builder.AddScoped<IAppUser, EFAppUser>();
            builder.AddScoped<IReservationServices, ReservationManager>();
            builder.AddScoped<IReservation, EFReservation>();
            builder.AddScoped<IGuideServices, GuideManager>();
            builder.AddScoped<IGuide, EFGuide>();
            builder.AddScoped<IContentUsServices, ContentUsManager>();
            builder.AddScoped<IContentUs, EFContentUs>();
            builder.AddScoped<IAnnouncementServices, AnnouncementManager>();
            builder.AddScoped<IAnnouncement, EFAnnouncement>();
        }

        public static void CustomerValidator(this IServiceCollection builder)
        {
            builder.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidation>();
        }
    }
}
