using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.Service.Services
{
    public class SampleDataService : ISampleDataService
    {
        private readonly IClientService _clientService;
        private readonly ISiteService _siteService;
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;
        private readonly IJobTypeService _jobTypeService;
        private readonly IJobSubTypeService _jobSubTypeService;
        private readonly IContractService _contractService;
        private static readonly Random random = new Random();


        public SampleDataService(IClientService clientService, ISiteService siteService, IContactService contactService, IUserService userService, IJobService jobService,
                                 IJobTypeService jobTypeService, IJobSubTypeService jobSubTypeService, IContractService contractService)

        {
            _clientService = clientService;
            _siteService = siteService;
            _contactService = contactService;
            _userService = userService;
            _jobService = jobService;
            _jobTypeService = jobTypeService;
            _jobSubTypeService = jobSubTypeService;
            _contractService = contractService;

        }
        public async Task<IEnumerable<object>> GenerateSampleData(User user)
        {
            try
            {
                var generatedClients = await generateClients(user);
                var generatedSites = await generateSites(user, generatedClients);
                var generatedContacts = await generateContacts(user, generatedClients);
                var generatedEngineers = await generateEngineers(user);
                var generatedDispatchers = await generateDispatchers(user);
                var generatedJobTypes = await generateJobTypes(user);
                var generatedJobSubTypes = await generateJobSubTypes(user, generatedJobTypes);
                var generatedJobs = await generateJobs(user, generatedClients, generatedEngineers, generatedJobTypes, jobCount:30);
                var generatedContracts= await generateContracts(user, generatedClients, generatedJobTypes, generatedJobSubTypes,contractCount:5);

                var generatedDataList = new List<object>
                {
                    generatedClients,
                    generatedSites,
                    generatedContacts,
                    generatedEngineers,
                    generatedJobTypes,
                    generatedJobSubTypes
                };

                return generatedDataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IEnumerable<Client>> generateClients(User user)
        {
            var clients = new List<Client>
             {
                    new Client
                    {
                        Name = "ClientCell",
                        Code = "CLT-001",
                        PrimaryContactName = "ClientCell",
                        PrimaryContactEmail = "clientcell@gmail.com",
                        PrimaryContactPhone = "1234567890",
                        SiteType = "company",
                        Currency = "EUR",
                        PrimaryFinancialName = "ClientCell_Financial",
                        PrimaryFinancialEmail = "clientcellfinancial@gmail.com",
                        CreatedAt = DateTime.Now,
                        CompanyId = user.CompanyId,
                        Fax = "1234567890",
                        CreatedByUserId = user.Id,
                        IsActive = true,
                        IsDeleted = false
                    },
                    new Client
                    {
                        Name = "Clientex",
                        Code = "CLT-002",
                        PrimaryContactName = "Clientex",
                        PrimaryContactEmail = "clientex@gmail.com",
                        PrimaryContactPhone = "5468940531",
                        SiteType = "company",
                        Currency = "EUR",
                        PrimaryFinancialName = "Clientex_Financial",
                        PrimaryFinancialEmail = "clientexfinancial@gmail.com",
                        CreatedAt = DateTime.Now,
                        CompanyId = user.CompanyId,
                        CreatedByUserId = user.Id,
                        Fax = "5468940531",
                        IsActive = true,
                        IsDeleted = false
                    },

                   new Client
                    {
                        Name = "Tech Solutions Inc.",
                        Code = "CLT-1001",
                        PrimaryContactName = "John Doe",
                        PrimaryContactEmail = "john.doe@techsolutions.com",
                        PrimaryContactPhone = "+1 (555) 123-4567",
                        SiteType = "company",
                        Currency = "USD",
                        PrimaryFinancialName = "Jane Smith",
                        PrimaryFinancialEmail = "jane.smith@techsolutions.com",
                        CreatedAt = DateTime.Now,
                        CompanyId = user.CompanyId,
                        Fax = "+1 (555) 987-6543",
                        CreatedByUserId = user.Id,
                        IsActive = true,
                        IsDeleted = false
                    },
                    new Client
                    {
                        Name = "Global Services Ltd.",
                        Code = "CLT-2002",
                        PrimaryContactName = "Alice Johnson",
                        PrimaryContactEmail = "alice.johnson@globalservices.com",
                        PrimaryContactPhone = "+1 (555) 555-5555",
                        SiteType = "company",
                        Currency = "EUR",
                        PrimaryFinancialName = "Robert Wilson",
                        PrimaryFinancialEmail = "robert.wilson@globalservices.com",
                        CreatedAt = DateTime.Now,
                        CompanyId = user.CompanyId,
                        Fax = "+1 (555) 123-7890",
                        CreatedByUserId = user.Id,
                        IsActive = true,
                        IsDeleted = false
                    },

                        new Client
                        {
                            Name = "Big Tech Corporation",
                            Code = "CLT-004",
                            PrimaryContactName = "Emily Davis",
                            PrimaryContactEmail = "emily.davis@example.com",
                            PrimaryContactPhone = "555-555-5555",
                            SiteType = "company",
                            Currency = "GBP",
                            PrimaryFinancialName = "Robert Wilson",
                            PrimaryFinancialEmail = "robert.wilson@example.com",
                            CreatedAt = DateTime.Now,
                            CompanyId = user.CompanyId,
                            Fax = "555-123-7890",
                            CreatedByUserId = user.Id,
                            IsActive = true,
                            IsDeleted = false
                        }
            };

            foreach (var client in clients)
            {
                await _clientService.AddAsync(client);
            }

            return clients;
        }

        private async Task<IEnumerable<Site>> generateSites(User user, IEnumerable<Client> clients)
        {

            var sites = new List<Site>
            {
                new Site
                {
                    ClientId = clients.FirstOrDefault(x => x.Name == "ClientCell").Id,
                    Name = "SiteCell",
                    ContactName = "SiteCell",
                    ContactEmail = "sitecell@gmail.com",
                    ContactPhone = "1234567890",
                    AddressLine1 = "Holborn Park Plaza, 123 Holborn Street",
                    AddressLine2=" London WC1V 7HH, United Kingdom",
                    City = "London",
                    PostCode = "WC1V 7HH",
                    CompanyId= user.CompanyId,

                },
                new Site
                {
                    ClientId = clients.FirstOrDefault(x => x.Name == "Clientex").Id,
                    Name = "Siteex",
                    ContactName = "Siteex",
                    ContactEmail = "siteex@gmail.com",
                    ContactPhone = "5468940531",
                    AddressLine1 = "20 Deans Yard",
                    AddressLine2="  London, SW1P 3PA",
                    City = "London",
                    PostCode = "SW1P 3PA",
                    CompanyId= user.CompanyId,

                },
                new Site
                    {
                        ClientId = clients.FirstOrDefault(x => x.Name == "Tech Solutions Inc.").Id,
                        Name = "Tech Solutions HQ",
                        ContactName = "John Doe",
                        ContactEmail = "john.doe@techsolutions.com",
                        ContactPhone = "+1 (555) 123-4567",
                        AddressLine1 = "123 Main Street",
                        AddressLine2 = "Suite 100",
                        City = "Techville",
                        PostCode = "12345",
                        CompanyId = user.CompanyId,
                    },
                    new Site
                    {
                        ClientId = clients.FirstOrDefault(x => x.Name == "Global Services Ltd.").Id,
                        Name = "Global Services Regional Office",
                        ContactName = "Alice Johnson",
                        ContactEmail = "alice.johnson@globalservices.com",
                        ContactPhone = "+1 (555) 555-5555",
                        AddressLine1 = "456 Business Avenue",
                        AddressLine2 = "Floor 5",
                        City = "Cityville",
                        PostCode = "54321",
                        CompanyId = user.CompanyId,
                    },
                    new Site
                        {
                            ClientId = clients.FirstOrDefault(x => x.Name == "Big Tech Corporation").Id,
                            Name = "BigTech Corporation Office",
                            ContactName = "Emily Davis",
                            ContactEmail = "emily.davis@example.com",
                            ContactPhone = "555-555-5555",
                            AddressLine1 = "123 Business Boulevard",
                            AddressLine2 = "Suite 200",
                            City = "Corporate City",
                            PostCode = "98765",
                            CompanyId = user.CompanyId
                        }


                };
            foreach (var site in sites)
            {
                await _siteService.AddAsync(site);
            }
            return sites;
        }
        private async Task<IEnumerable<Contact>> generateContacts(User user, IEnumerable<Client> clients)
        {
            var contacts = new List<Contact>
            {
                new Contact
                {
                    ClientId = clients.FirstOrDefault(x => x.Name == "ClientCell").Id,
                    Name = "ContactCell",
                    Email = "contactcell@gmail.com",
                    Phone = "1234567890",
                    SiteId=  clients.FirstOrDefault(x => x.Name == "ClientCell").Sites.FirstOrDefault().Id,
                    ContactType="PRIMARY"
                },
                new Contact
                {
                    ClientId = clients.FirstOrDefault(x => x.Name == "Clientex").Id,
                    Name = "Contactex",
                    Email = "contactex@gmail.com",
                    Phone = "5468940531",
                    SiteId=  clients.FirstOrDefault(x => x.Name == "Clientex").Sites.FirstOrDefault().Id,
                    ContactType="PRIMARY"

                },
            new Contact
                    {
                        ClientId = clients.FirstOrDefault(x => x.Name == "Tech Solutions Inc.").Id,
                        Name = "John Doe",
                        Email = "john.doe@techsolutions.com",
                        Phone = "+1 (555) 123-4567",
                        SiteId = clients.FirstOrDefault(x => x.Name == "Tech Solutions Inc")
                                   ?.Sites.FirstOrDefault()?.Id, 
                        ContactType = "PRIMARY"
                    },


                            new Contact
                            {
                                ClientId = clients.FirstOrDefault(x => x.Name == "Global Services Ltd.").Id,
                                Name = "Alice Johnson",
                                Email = "alice.johnson@globalservices.com",
                                Phone = "+1 (555) 555-5555",
                                SiteId = clients.FirstOrDefault(x => x.Name == "Global Services Ltd")
                                           ?.Sites.FirstOrDefault()?.Id, // Check if Sites is null or empty before accessing the first element
                                ContactType = "PRIMARY"
                            }
                            ,
                                           new Contact
                            {
                                ClientId = clients.FirstOrDefault(x => x.Name == "Big Tech Corporation").Id,
                                Name = "Emily Davis",
                                Email = "emily.davis@example.com",
                                Phone = "555-555-5555",
                                SiteId = clients.FirstOrDefault(x => x.Name == "Big Tech Corporation")
                                           ?.Sites.FirstOrDefault()?.Id, // Check if Sites is null or empty before accessing the first element
                                ContactType = "PRIMARY"
}

            };
            foreach (var contact in contacts)
            {
                await _contactService.AddAsync(contact);
            }
            return contacts;
        }

        private async Task<IEnumerable<User>> generateEngineers(User user)
        {
            var engineers = new List<User>
            {
                new User
                {
                    Initials = "ADE",
                    FirstName = "Andrew",
                    LastName = "Engineer",
                    Email = "eng1@gmail.com",
                    Phone = "1234567890",
                    IsConfirmed = true,
                    UserRoleId=(int)UserRoleEnum.Engineer,
                    PasswordHash = "1234567890",
                    ModifiedDate = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,

                },
                new User
                {
                    Initials = "JE",
                    FirstName = "Jim",
                    LastName = "Engineer",
                    Email = "eng2@gmail.com",
                    Phone = "5468940531",
                    UserRoleId=(int)UserRoleEnum.Engineer,
                     PasswordHash = "1234567890",
                    ModifiedDate = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                },
                new User
                {
                    Initials = "JD",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@afsgo.com",
                    Phone = "5559876543",
                    UserRoleId = (int)UserRoleEnum.Engineer,
                    PasswordHash = "1234567890",
                    ModifiedDate = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id
                },



            };
            foreach (var engineer in engineers)
            {
                await _userService.AddAsync(engineer);
            }
            return engineers;
        }
        private async Task<IEnumerable<User>> generateDispatchers(User user)
        {
            var dispatchers = new List<User>
            {
                     new User
                    {
                        Initials = "DU",
                        FirstName = "Dispatcher",
                        LastName = "Smith",
                        Email = "dispatcher.smith@afsgo.com",
                        Phone = "555-987-6543",
                        UserRoleId = (int)UserRoleEnum.Admin,
                        PasswordHash = "1234567890",
                        ModifiedDate = DateTime.Now,
                        CompanyId = user.CompanyId,
                        CreatedByUserId = user.Id
                    }

            };
            foreach (var dispatcher in dispatchers)
            {
                await _userService.AddAsync(dispatcher);
            }
            return dispatchers;
        }
        private async Task<IEnumerable<JobType>> generateJobTypes(User user)
        {
            var jobTypes = new List<JobType>
            {
                new JobType
                {
                    Name = "Installation",

                    CreatedAt = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                    IsActive = true,
                    IsDeleted = false
                },
                new JobType
                {
                    Name = "Maintenance",
                    CreatedAt = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                    IsActive = true,
                    IsDeleted = false
                }
            };
            foreach (var jobType in jobTypes)
            {
                await _jobTypeService.AddAsync(jobType);
            }
            return jobTypes;

        }
        private async Task<IEnumerable<JobSubType>> generateJobSubTypes(User user, IEnumerable<JobType> jobTypes)
        {
            var jobSubTypes = new List<JobSubType>();

            var installationJobType = jobTypes.FirstOrDefault(x => x.Name == "Installation");
            var maintenanceJobType = jobTypes.FirstOrDefault(x => x.Name == "Maintenance");

            if (installationJobType != null)
            {
                var installationSubTypes = new List<string>
                {
                    "HVAC",
                    "Freezer",
                    "Fridge",
                    "Furnace"
                };

                jobSubTypes.AddRange(installationSubTypes.Select(subTypeName => new JobSubType
                {
                    Name = subTypeName,
                    JobTypeId = installationJobType.Id,
                    CreatedAt = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                    IsActive = true,
                    IsDeleted = false
                }));
            }

            if (maintenanceJobType != null)
            {
                var maintenanceSubTypes = new List<string>
                        {
                            "Cleaning",
                            "Keeping",
                            "Testing",
                            "Fixing"
                        };

                jobSubTypes.AddRange(maintenanceSubTypes.Select(subTypeName => new JobSubType
                {
                    Name = subTypeName,
                    JobTypeId = maintenanceJobType.Id,
                    CreatedAt = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                    IsActive = true,
                    IsDeleted = false
                }));
            }

            await _jobSubTypeService.AddRangeAsync(jobSubTypes);

            return jobSubTypes;
        }

        private async Task<IEnumerable<Job>> generateJobs(User user, IEnumerable<Client> clients, IEnumerable<User> engineers, IEnumerable<JobType> jobTypes, int? jobCount = 30)
        {
            List<JobStatusEnum> statusList = new List<JobStatusEnum>()
    {
        JobStatusEnum.OPEN,
        JobStatusEnum.CLOSED,
        JobStatusEnum.RESOLVED,
        JobStatusEnum.ASSIGNED,
        JobStatusEnum.CANCELLED
    };

            List<JobPriorityEnum> priorityList = new List<JobPriorityEnum>()
    {
        JobPriorityEnum.LOW,
        JobPriorityEnum.MEDIUM,
        JobPriorityEnum.HIGH,
    };

            List<string> descriptionList = new List<string>() {
        "Install and configure new security system in commercial building. This will include running cables, mounting cameras, and programming the system to meet the client's needs.",
        "Install and set up a new server for a small business. This will involve physically installing the server in the designated location, configuring the network settings, and installing any necessary software.",
        "Install and test a new HVAC system in a residential home. This will involve properly sizing the system for the home, installing the equipment, and ensuring that it is functioning correctly.",
        "Perform routine maintenance on a fleet of vehicles. This will involve checking and replacing fluids, performing minor repairs, and keeping records of all maintenance performed.",
        "Maintain and repair production equipment in a manufacturing facility. This will involve troubleshooting problems, performing preventive maintenance, and replacing worn or broken parts as needed.",
        "Maintain and repair electrical systems in a residential or commercial setting. This will involve troubleshooting problems, replacing faulty components, and ensuring that the electrical system is up to code."
    };

            var generatedJobs = new List<Job>(); // Create a list to hold the generated jobs

            for (int i = 0; i < jobCount; i++)
            {
                var client = clients.ElementAt(random.Next(clients.Count()));
                string description = descriptionList.ElementAt(random.Next(descriptionList.Count));
                var jobtype = jobTypes.ElementAt(random.Next(jobTypes.Count()));
                var engineer = engineers.ElementAt(random.Next(engineers.Count()));
                JobPriorityEnum selectedPriority = priorityList.ElementAt(random.Next(priorityList.Count));
                JobStatusEnum selectedStatus = statusList.ElementAt(random.Next(statusList.Count));
                DateTime scheduleTime = GenerateRandomTimesDuringDay();

                // Check if selected status is Resolved or Closed
                if (selectedStatus == JobStatusEnum.RESOLVED || selectedStatus == JobStatusEnum.CLOSED)
                {
                    // Generate a new estimated time until it is earlier than DateTime.Now
                    while (scheduleTime > DateTime.Now)
                    {
                        scheduleTime = GenerateRandomTimesDuringDay();
                    }
                }

                if (selectedStatus == JobStatusEnum.ASSIGNED)
                {
                    // Generate a new estimated time until it is earlier than DateTime.Now
                    while (scheduleTime.Date.Day != DateTime.Now.Day)
                    {
                        scheduleTime = GenerateRandomTimesDuringDay();
                    }
                }

                var estimatedMinutes = random.Next(120);
                // Give Engineer ID if status not open
                int? engineerId;
                if (selectedStatus == JobStatusEnum.OPEN)
                    engineerId = null;
                else
                    engineerId = engineer.Id;

                var generatedJob = await generateSingleJob(user, client, jobtype, engineerId, description, selectedPriority, scheduleTime, estimatedMinutes, selectedStatus);

                generatedJobs.Add(generatedJob);
            }

            return generatedJobs;
        }

        private async Task<Job> generateSingleJob(User user, Client client, JobType jobType, int? engineerId, string description, JobPriorityEnum priority,
                                                     DateTime? scheduleTime, int estimatedMinutes, JobStatusEnum status)
        {
            try
            {
                Job job = new Job
                {
                    ClientId = client.Id,
                    SiteId = client.Sites?.FirstOrDefault()?.Id, 
                    ContactId = client.Contacts?.FirstOrDefault()?.Id,
                    JobTypeId = jobType.Id,
                    JobSubTypeId = jobType.JobSubTypes?.FirstOrDefault()?.Id,
                    EngineerId = engineerId,
                    Description = description,
                    PriorityId = (int?)priority,
                    ScheduleDateEnd = scheduleTime,
                    JobDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    EstimatedDuration = estimatedMinutes,
                    JobStatusId = (int?)status,
                    CreatedAt = DateTime.Now,
                    CompanyId = user.CompanyId,
                    CreatedByUserId = user.Id,
                    IsActive = true,
                    IsDeleted = false
                };

                await _jobService.AddAsync(job);

                return job;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static DateTime GenerateRandomTimesDuringDay()
        {
            var today = DateTime.UtcNow;
            var date = today;

            DateTime randomDateTime = new DateTime(date.Year, date.Month, date.Day, random.Next(8, 14), 0, 0)
                .AddDays(random.Next(-7, 8));

            return randomDateTime;
        }

        private async Task<IEnumerable<Contract>> generateContracts(User user, 
            IEnumerable<Client> clients,
            IEnumerable<JobType> jobTypes,
            IEnumerable<JobSubType> jobSubTypes,
            int? contractCount = 5)
            {
                var generatedContracts = new List<Contract>();
                List<string> contractDescription = new List<string>()
                            {
                                "This contract outlines the terms and conditions for the provision of field service software solutions by our company.",
                                "The scope of this contract includes software development, implementation, and ongoing support services.",
                                "Our company agrees to provide the necessary software licenses for your organization's use during the contract period.",
                                "The contract duration is for a period of [duration], starting from the effective date.",
                                "Both parties agree to maintain confidentiality regarding any proprietary information shared during the course of this contract.",
                                "Our company will provide regular software updates and bug fixes to ensure optimal performance.",
                                "The pricing structure for this contract is based on [pricing model], as detailed in the attached pricing schedule.",
                                "In the event of any disputes, both parties agree to engage in good faith negotiations to reach an amicable resolution.",
                                "Either party may terminate this contract with [notice period] days written notice if the terms of the agreement are not met.",
                                "This contract may be renewed upon mutual agreement by both parties, subject to renegotiation of terms and conditions.",
                                "Our company is committed to providing high-quality field service software solutions and excellent customer support throughout the contract period.",
                                "All changes to the scope of work must be documented in writing and agreed upon by both parties.",
                                "This contract is binding upon the signing parties and their respective successors and assigns.",
                                "Any modifications to this contract must be made in writing and signed by both parties to be considered valid."
                            };

            List<int> frequencyTypes = new List<int> {1,7, 30, 90,120, 180, 360 };
            List<string> billingTypes = new List<string> { "INVOICE_PER_CONTRACT", "INVOICE_PER_VISIT" };
            List<DateTime> startDate = new List<DateTime>{
                 DateTime.Now.Date,
                 DateTime.Now.AddDays(2).Date,
                 DateTime.Now.AddDays(4).Date,
                 DateTime.Now.AddDays(7).Date,
                 DateTime.Now.AddDays(1).Date,
            };
            List<DateTime> expiryDate = new List<DateTime>
            {
                 DateTime.Now.AddYears(1).Date,
                 DateTime.Now.AddMonths(15).Date,
                 DateTime.Now.AddMonths(6).Date,
                 DateTime.Now.AddMonths(8).Date,
                 DateTime.Now.AddMonths(14).Date,
            };
            for (int i = 0; i < contractCount; i++)
                {
                    var client = clients.ElementAt(random.Next(clients.Count()));
                    var jobtype = jobTypes.ElementAt(random.Next(jobTypes.Count()));
                    var jobSubType= jobSubTypes.ElementAt(random.Next(jobSubTypes.Count()));
                    int frequencyType = frequencyTypes.ElementAt(random.Next(frequencyTypes.Count()));
                    string billingType = billingTypes.ElementAt(random.Next(billingTypes.Count()));
                    string description = contractDescription.ElementAt(random.Next(contractDescription.Count));
                    DateTime startdate = startDate.ElementAt(random.Next(startDate.Count));
                    DateTime expirydate = expiryDate.ElementAt(random.Next(expiryDate.Count));



                    var generatedContract = await generateSingleContract(user, client, jobtype.Id,jobSubType.Id,frequencyType,description, billingType,startdate,expirydate);

                    generatedContracts.Add(generatedContract);
                }

                return generatedContracts;
            }
        private async Task<Contract> generateSingleContract(User user, Client client, int jobtypeId,int jobSubtypeId,int frequencyType,string description,string billingtype, DateTime startdate, DateTime expirydate)
        {
            try
            {


                Contract contract = new Contract()
                {
                    Client = client,
                    ClientId= client.Id,
                    JobTypeId = jobtypeId,
                    JobSubTypeId = jobSubtypeId,
                    EstimatedDurationMinutes = random.Next(240),
                    Description = description,
                    FrequencyType = frequencyType,
                    FrequencyCount = 1,
                    ContractCharge = random.Next(120),
                    StartDate = startdate,
                    ModifiedDate = DateTime.Now.Date,
                    ExpiryDate = expirydate,
                    BillingType = billingtype,
                    CreatedByUserId = user.Id,
                    CreatedAt = DateTime.Now,

                };
                await _contractService.CreateContract(contract);

                return contract;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
