using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreFirstApp.Models
{
    public class CarModel
    {
        [DisplayName("Id Number")]
        public int Id {  get; set; }

        [DisplayName("Make & Model")]
        public string Name { get; set; }

        [DisplayName("Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Range(1900, 2100)]
        public DateTime Year { get; set; }

        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public int Price {  get; set; }

        public CarModel ()
        {
        }

        public CarModel(int id, string name, DateTime year, int price)
        {
            Id = id;
            Name = name;
            Year = year;
            Price = price;
        }
    }
}
