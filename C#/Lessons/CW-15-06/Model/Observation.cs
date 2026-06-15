using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CW_15_06.Model
{
    public class Observation
    {
        public int Id { get; set; }
        public ObservationObject Object { get; set; }
        public int DateDay { get; set; }
        public int DateMonth {  get; set; }
        public int DateYear { get; set; }
        public Classification Classification { get; set; }
        public string Text { get; set; }
        public Rating Rating { get; set; }
        //[XmlIgnore]

        public Observation() 
        {
            DateTime time = DateTime.Now;
            DateDay = time.Day;
            DateMonth = time.Month;
            DateYear = time.Year;
        }

        public Observation(int id, ObservationObject @object, int dateDay, int dateMonth, int dateYear, Classification classification, string text, Rating rating)
        {
            DateTime time = DateTime.Now;
            DateDay = time.Day;
            DateMonth = time.Month;
            DateYear = time.Year;

            Id = id;
            Object = @object;
            DateDay = dateDay;
            DateMonth = dateMonth;
            DateYear = dateYear;
            Classification = classification;
            Text = text;
            Rating = rating;
        }
    }
}
