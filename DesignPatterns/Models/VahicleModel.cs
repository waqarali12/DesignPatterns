using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Models
{
    class VahicleModel
    {
        public VahicleModel(int typeCode)
        {
            TypeCode = typeCode;
        }
        public int TypeCode { get; set; }
        public int HorsePower { get; set; }
        public string Engine { get; set; }
        
    }
}
