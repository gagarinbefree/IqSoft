using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class File : Entity
    {
        public string Name { get; set; }
        public string NameTmp { get; set; }
        public DateTime UploadDateTime { get; set; }

        public virtual ICollection<WorkSheet> WorkSheets { get; set; }
    }
}
