﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Department_name { get; set; }
        public int Clinic_id { get; set; }
    }
}