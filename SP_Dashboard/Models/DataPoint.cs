﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace SP_Dashboard.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(long x, double y)
        {
            this.X = x;
            this.Y = y;

        }
        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<long> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}