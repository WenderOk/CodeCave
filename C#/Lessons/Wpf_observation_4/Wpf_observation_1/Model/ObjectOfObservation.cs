using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_observation_1.Model
{
	public class ObjectOfObservation
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public ObjectOfObservation()
        {
            
        }
        public ObjectOfObservation(int idP, string nameP)
        {
            Id = idP;
            Name = nameP;
        }
    }
}
