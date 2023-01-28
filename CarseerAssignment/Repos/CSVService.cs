using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using CarseerAssignment;
using CarseerAssignment.Models;
using System.Text.Json;
using System.Linq;

namespace CarseerAssignment.Repos
{
    public class CSVService : ICSVService
    {
        //method-level generic to deal with the model class.
        //passed the file stream as a parameter to the ReadCSV method
        //The StreamReader reads the text and characters from the file stream.
        //used CsvReader to transfer the content read from StreamReader into the memory
        //GetRecords method returned the data of CSV files
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var options = new JsonSerializerOptions
            {
                // Set the maximum depth to 64
                MaxDepth = 64
            };
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<T>();
            long i = 0;
            string[] lines = reader.ReadToEnd().Split(new char[] { '{', '}', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var entities = lines.Skip(1)
               .Select(x => x.ToString().Split(','))
               .Select(x => new Car
               {
                   id = i++,
                   make = x[0],
                   numofdoors = x[1],
                   bodystyle = x[2],
                   enginelocation = x[3],
                   numofcylinders = x[4],
                   horsepower =  x[5],
                   price =x[6]

               }); ;

            return (IEnumerable<T>)entities;
        }
    }
}
