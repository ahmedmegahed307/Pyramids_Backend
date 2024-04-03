using AutoMapper;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.Address;
using Pyramids.API.DTOs.Asset;
using Pyramids.API.DTOs.AssetManufacturer;
using Pyramids.API.DTOs.AssetModel;
using Pyramids.API.DTOs.AssetType;
using Pyramids.API.DTOs.Auth;
using Pyramids.API.DTOs.Category;
using Pyramids.API.DTOs.Client;
using Pyramids.API.DTOs.Client.Contact;
using Pyramids.API.DTOs.Client.Site;
using Pyramids.API.DTOs.Company;
using Pyramids.API.DTOs.Data;
using Pyramids.API.DTOs.Job;
using Pyramids.API.DTOs.JobAction;
using Pyramids.API.DTOs.JobAttachment;
using Pyramids.API.DTOs.JobIssue;
using Pyramids.API.DTOs.JobPart;
using Pyramids.API.DTOs.JobSubType;
using Pyramids.API.DTOs.JobType;
using Pyramids.API.DTOs.Notification;
using Pyramids.API.DTOs.PPM.Contract;
using Pyramids.API.DTOs.PPM.Reminder;
using Pyramids.API.DTOs.PPM.Visit;
using Pyramids.API.DTOs.Priority;
using Pyramids.API.DTOs.Product;
using Pyramids.API.DTOs.Reports.JobQuery;
using Pyramids.API.DTOs.Scheduler;
using Pyramids.API.DTOs.User;
using Pyramids.API.DTOs.UserRole;
using Pyramids.Core.Models;

namespace Pyramids.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Address
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();

            //Asset
            CreateMap<Asset, AssetDto>().ReverseMap();
            CreateMap<Asset, AssetCreateDto>().ReverseMap();
            CreateMap<Asset, AssetUpdateDto>().ReverseMap();

            //AssetType
            CreateMap<AssetType, AssetTypeDto>().ReverseMap();
            CreateMap<AssetType, AssetTypeCreateDto>().ReverseMap();
            CreateMap<AssetType, AssetTypeUpdateDto>().ReverseMap();
            CreateMap<AssetCreateDto, Asset>()
                .ForMember(dest => dest.AssetManufacturer, opt => opt.MapFrom(src => src.AssetManufacturerDto))
                .ForMember(dest => dest.AssetModel, opt => opt.MapFrom(src => src.AssetModelDto))
                .ForMember(dest => dest.AssetType, opt => opt.MapFrom(src => src.AssetTypeDto));

            //AssetModel
            CreateMap<AssetModel, AssetModelDto>().ReverseMap();
            CreateMap<AssetModel, AssetModelCreateDto>().ReverseMap();
            CreateMap<AssetModel, AssetModelUpdateDto>().ReverseMap();

            //AssetManufacturer
            CreateMap<AssetManufacturer, AssetManufacturerDto>().ReverseMap();
            CreateMap<AssetManufacturer, AssetManufacturerCreateDto>().ReverseMap();
            CreateMap<AssetManufacturer, AssetManufacturerUpdateDto>().ReverseMap();

           

            //Client
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, ClientCreateDto>().ReverseMap();
            CreateMap<Client, ClientUpdateDto>().ReverseMap();

            //ClientContact
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();

            //Company
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();

            //Contact
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();

            // DataDtos
            CreateMap<Client, ClientDataDto>().ReverseMap();
            CreateMap<Site, SiteDataDto>().ReverseMap();
            CreateMap<Contact,ContactDataDto>().ReverseMap();
            CreateMap<User, UserDataDto>().ReverseMap();
            CreateMap<Priority, JobPriorityDataDto>().ReverseMap();
            CreateMap<JobType, JobTypeDataDto>().ReverseMap();
            CreateMap<JobSubType, JobSubTypeDataDto>().ReverseMap();
            CreateMap<AssetModel, AssetModelDataDto>().ReverseMap();
            CreateMap<AssetType, AssetTypeDataDto>().ReverseMap();
            CreateMap<AssetManufacturer, AssetManufacturerDataDto>().ReverseMap();

            //Job
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, JobCreateDto>().ReverseMap();
            CreateMap<Job, JobUpdateDto>().ReverseMap();
            CreateMap<Client, JobClientDto>().ReverseMap();
            CreateMap<JobType, JobJobTypeDto>().ReverseMap();
            CreateMap<Site, JobSiteDto>().ReverseMap();
            CreateMap<User, JobUserDto>().ReverseMap();
            CreateMap<JobSubType, JobJobSubTypeDto>().ReverseMap();
            CreateMap<JobStatus, JobStatusDto>().ReverseMap();
            CreateMap<Priority, PriorityDto>().ReverseMap();
            CreateMap<JobPart, JobCreateJobPart>().ReverseMap();
            CreateMap<JobIssue, JobJobIssueDto>().ReverseMap();
            CreateMap<Asset, JobIssueAssetDto>().ReverseMap();
            CreateMap<Contact, JobContactDto>().ReverseMap();

            //Job Attachment
            CreateMap<JobAttachment, JobAttachmentDto>().ReverseMap();
            CreateMap<JobAttachment, JobAttachmentCreateDto>().ReverseMap();
            CreateMap<JobAttachment, JobAttachmentUpdateDto>().ReverseMap();


            //Job Part
            CreateMap<JobPart, JobPartDto>().ReverseMap();
            CreateMap<JobPart, JobPartCreateDto>().ReverseMap();
            CreateMap<JobPart, JobPartUpdateDto>().ReverseMap();

            //JobAction
            CreateMap<JobAction, JobActionDto>().ReverseMap();
            CreateMap<JobAction, JobActionCreateDto>().ReverseMap();
            CreateMap<User, JobActionUserDto>().ReverseMap();
            CreateMap<JobActionType, JobActionJobActionTypeDto>().ReverseMap();


            //Job Type
            CreateMap<JobType, JobTypeDto>().ReverseMap();
            CreateMap<JobType, JobTypeCreateDto>().ReverseMap();
            CreateMap<JobType, JobTypeUpdateDto>().ReverseMap();
            CreateMap<JobType, SubTypeJobTypeDto>().ReverseMap();
            CreateMap<JobSubType, JobSubTypeDto>().ReverseMap();

            // Job SubType

            CreateMap<JobSubType, JobSubTypeDto>().ReverseMap();
            CreateMap<JobSubType, JobSubTypeCreateDto>().ReverseMap();
            CreateMap<JobSubType, JobSubTypeUpdateDto>().ReverseMap();


            //Job Issue
            CreateMap<JobIssue, JobIssueDto>().ReverseMap();
            CreateMap<JobIssue, JobIssueCreateDto>().ReverseMap();
            CreateMap<JobIssue, JobIssueUpdateDto>().ReverseMap();




            //Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            //Site
            CreateMap<Site, SiteDto>().ReverseMap();
            CreateMap<Site, SiteCreateDto>().ReverseMap();
            CreateMap<Site, SiteUpdateDto>().ReverseMap();

           

            //User 
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, RegisterEngineerDto>().ReverseMap();
            CreateMap<User, RegisterAdminDto>().ReverseMap();

            //UserRole 
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<UserRole, UserRoleCreateDto>().ReverseMap();
            CreateMap<UserRole, UserRoleUpdateDto>().ReverseMap();

           

            //Reports - JobQuery
            CreateMap<Job, JobQueryResultDto>()
                .ForMember(dest=> dest.EngineerName, opt=>opt.MapFrom(src=>src.Engineer !=null ? src.Engineer.FirstName + " " + src.Engineer.LastName :null))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.JobStatus != null ? src.JobStatus.Name : null))
                .ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.Priority != null ? src.Priority.Name : null))
                .ForMember(dest => dest.JobTypeName, opt => opt.MapFrom(src => src.JobType != null ? src.JobType.Name : null))
                .ForMember(dest => dest.JobSubTypeName, opt => opt.MapFrom(src => src.JobSubType != null ? src.JobSubType.Name : null))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : null))
                .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<Site, JobQuerySiteDto>().ReverseMap();
           
            //Notification
            CreateMap<Notification, NotificationCreateDto>().ReverseMap();
            CreateMap<Notification, NotificationUpdateDto>().ReverseMap();

            //Contract
            CreateMap<Contract, ContractDto>()
             .ForMember(dest => dest.JobTypeId, opt => opt.MapFrom(src => src.JobType.Id))
             .ForMember(dest => dest.JobTypeName, opt => opt.MapFrom(src => src.JobType.Name))
             .ForMember(dest => dest.JobSubTypeId, opt => opt.MapFrom(src => src.JobSubType.Id))
             .ForMember(dest => dest.JobSubTypeName, opt => opt.MapFrom(src => src.JobSubType.Name))
             .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
             .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
             .ForMember(dest => dest.NextVisitDate, opt => opt.MapFrom(src => src.NextVisitDate.HasValue ? src.NextVisitDate.Value : (DateTime?)null))
             .ReverseMap();
            CreateMap<Contract, ContractCreateDto>().ReverseMap();
            CreateMap<Contract, ContractUpdateDto>().ReverseMap();

            //Visits
            CreateMap<Visit, VisitDto>()
                .ForMember(dest => dest.ContractRef, opt => opt.MapFrom(src => src.Contract.ContractRef))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Contract.Client.Name))
                .ForMember(dest => dest.JobStatus, opt => opt.MapFrom(src => src.Job.JobStatus != null ? src.Job.JobStatus.Name : null))
                .ForMember(dest => dest.InvoiceRow, opt => opt.MapFrom(src => src.Contract.BillingType == "INVOICE_PER_VISIT"))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Job.JobIssues != null && src.Job.JobIssues.Any()?
                                src.Job.JobIssues.First().Description : src.Contract.Description))
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom(src =>
                            src.Job.JobSessions != null && src.Job.JobSessions.Any(a => a.EngineerAssignedId.HasValue) ?
                            src.Job.JobSessions.OrderByDescending(a => a.Id).First().EngineerAssigned.FirstName + " " +
                            src.Job.JobSessions.OrderByDescending(a => a.Id).First().EngineerAssigned.LastName : ""))
                .ReverseMap();

            //Reminders
            CreateMap<Reminder, ReminderDto>()
                .ForMember(dest => dest.ContractRef, opt => opt.MapFrom(src => src.Contract.ContractRef))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Contract.Client.Name))
                .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.JobId))
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom(src => src.Contract.DefaultEngineerId.HasValue ?
                                   src.Contract.DefaultEngineer.FirstName + "" + src.Contract.DefaultEngineer.LastName : "")).ReverseMap();




            //Scheduler
            CreateMap<SchedulerEvent, SchedulerEventDto>().ReverseMap();
            CreateMap<SchedulerEvent, SchedulerEventCreateDto>().ReverseMap();
            CreateMap<SchedulerEvent, SchedulerEventUpdateDto>().ReverseMap();




        }
    }
}
