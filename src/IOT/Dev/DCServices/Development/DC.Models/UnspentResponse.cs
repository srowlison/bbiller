﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace DC.Common.Models
{
    [DataContract]
    public class UnspentResponse
    {

        [DataMember(Name = "unspent_outputs")]
        public UnspentOutput[] UnspentOutputs { get; set; }
    }
}
