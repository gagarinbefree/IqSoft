using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class File : Entity
    {
        public DateTime UploadDateTime { get; set; }

        public virtual ICollection<WorkSheet> WorkSheets { get; set; }
    }
}
