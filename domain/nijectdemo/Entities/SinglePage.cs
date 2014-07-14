using System;

namespace Entities
{
    public class SinglePage
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Contents { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
