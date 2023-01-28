using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CarseerAssignment.Models
{
    [Table("Cars")]
    public class Car
    {
        
        public long id { get; set; }
        
        [AllowNull]
        public string make { get; set; }
        
        [Name("num-of-doors")]
        [AllowNull]
        public string numofdoors { get; set; }
        
        [Name("body-style")]
        [AllowNull]
        public string bodystyle { get; set; }
        [Name("engine-location")]
        [AllowNull]
        public string enginelocation { get; set; }
        [Name("num-of-cylinders")]
        [AllowNull]
        public string numofcylinders { get; set; }

        [AllowNull]
        public string horsepower { get; set; }
        [AllowNull]
        public string price { get; set; }
    }
}
