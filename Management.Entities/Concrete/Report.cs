using Management.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Entities.Concrete
{
    public class Report : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

        public int WorkId { get; set; }
        public Work Work { get; set; }

    }
}
