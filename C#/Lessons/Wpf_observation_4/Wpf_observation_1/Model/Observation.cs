using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wpf_observation_1.Model
{
	public class Observation
	{
		public int Id { get; set; }
		public ObjectOfObservation Object { get; set; }
		public int DateDay { get; set; }
		public int DateMonth { get; set; }
		public int DateYear { get; set; }
		public Classification Classification { get; set; }
		public string Text { get; set; }
		public Rating Rating { get; set; }
		[XmlIgnore]
		public string Display { get { return $"{DateDay}.{DateMonth}.{DateYear}-{Object.Name}-{Text}"; } }
		
		public Observation() 
		{
			DateTime dateTime = DateTime.Now;
			DateDay = dateTime.Day;
			DateMonth = dateTime.Month;
			DateYear = dateTime.Year;
		}
        public Observation(int idP, ObjectOfObservation objectP, Classification classificationP, string textP, Rating ratingP)
        {
            Id = idP;
			Object = objectP;
			DateTime dateTime = DateTime.Now;
			DateDay = dateTime.Day;
			DateMonth = dateTime.Month;
			DateYear = dateTime.Year; ;
			Classification = classificationP;
			Text = textP;
			Rating = ratingP;
		}

    }
}
