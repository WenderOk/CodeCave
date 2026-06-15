using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_15_06.Model
{
    public class ObservationObject
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public ObservationObject() { }
        public ObservationObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
