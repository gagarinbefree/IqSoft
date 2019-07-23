using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class DomainRow
    {
        public string Id { get; set; }
        public DateTime UploadDateTime { get; set; }
        public List<DomainCol> Cols { get; set; } = new List<DomainCol>();
    }
}
