using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateMSAccessAppTemplate.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual int Age { get; set; }
    }
}
