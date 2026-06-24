using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PcLibraryApp.Models
{
    [Table("PcBuilds")]
    public class PcBuild : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Component> Components { get; set; } = new List<Component>();

        [NotMapped]
        public decimal TotalPrice => Components != null ? Components.Sum(c => c.Price) : 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RefreshPrice()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPrice)));
        }
    }
}
