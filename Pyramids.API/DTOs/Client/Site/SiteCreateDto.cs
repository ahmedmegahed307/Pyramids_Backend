﻿using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Client.Site
{
    public class SiteCreateDto : EntityBaseDto
    {
        public int CompanyId { get; set; }

        public required int ClientId { get; set; }
        public required string Name { get; set; }
        public required string ContactName { get; set; }
        public required string ContactEmail { get; set; }
        public required string ContactPhone { get; set; }

        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string? City { get; set; }
        public string? PostCode { get; set; }
    }
}
