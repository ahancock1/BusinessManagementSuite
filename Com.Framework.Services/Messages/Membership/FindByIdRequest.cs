﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class FindByIdRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public Guid UserId { get; set; }


    }
}