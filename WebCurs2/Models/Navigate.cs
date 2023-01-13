using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCurs2.Models
{
    public class Navigate
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public long? ParentId { get; set; }

        public long OrderId { get; set; }


    }
}
