using PharmacyEditon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyEditon.Service.Helpers
{
    public class Responce
    {
        //header
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsOk { get; set; }
        //body
        public Medicine medicine { get; set; }
    }
}
