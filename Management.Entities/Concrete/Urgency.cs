using Management.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Entities.Concrete
{
    public class Urgency : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Work> Works { get; set; }
    }
}
