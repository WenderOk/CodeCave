using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_observation_1.Model
{
	public class Classification
	{
		public int Id { get; set; }
		public string ClassificationName { get; set; }
        public Classification()
        {
            
        }
        public Classification(int idP, string classifNameP)
        {
            Id = idP;
            ClassificationName = classifNameP;
        }
    }
    public class Rating
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }
        public Rating() { }
        public Rating(int idP, int valueP)
        {
            Id = idP;
            RatingValue = valueP;
        }
    }
}
