﻿namespace MovieECommerce.Services
{
    public class CloudinaryConfiguration
    {
        //These properties will be bound to the Cloudinary section in appsettings.json file 
        //and will be used to configure the Cloudinary service. 
        //A services will be created in Program.cs file to Map to the CloudinaryConfig class.
        public string? Name { get; set; }
        public string? ApiKey { get; set; }
        public string? ApiSecret { get; set; }
    }
}
