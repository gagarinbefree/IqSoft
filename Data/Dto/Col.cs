using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class Col : Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int RowId { get; set; }
        public virtual Row Row { get; set; }
    }
}
