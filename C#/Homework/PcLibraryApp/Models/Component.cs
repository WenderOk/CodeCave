using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcLibraryApp.Models
{
    [Table("Components")]
    public class Component
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }

        // Добавляем внешний ключ. int? означает, что деталь может быть не привязана к сборке (свободна)
        public int? BuildId { get; set; }

        public Component() { }

        public Component(int id, string category, string manufacturer, string model, decimal price, string description = "")
        {
            Id = id;
            Category = category;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Description = description;
            BuildId = null; // По умолчанию деталь свободна
        }

        [NotMapped]
        public string FullName => Manufacturer + " " + Model;
    }
}
