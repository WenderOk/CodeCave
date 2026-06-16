using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_15_06.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }
        public Rating() { }
        public Rating(int id, int ratingValue)
        {
            Id = id;
            RatingValue = ratingValue;
        }

        public ObservableCollection<Rating> Init()
        {
            ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
            for (int i = 0; i < 10; i++)
            {
                Rating r = new Rating();
                r.Id = i;
                r.RatingValue = i+1;
                ratings.Add(r);
            }
            return ratings;
        }
    }
}
