using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class WorkSheet : Entity
    {
        public int Number { get; set; }

        public int FileId { get; set; }
        public virtual File File { get; set; }

        public virtual ICollection<Row> Rows { get; set; }
    }
}
