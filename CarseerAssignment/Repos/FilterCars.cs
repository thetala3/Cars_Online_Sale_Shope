using CarseerAssignment.Models;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CarseerAssignment;
using Microsoft.EntityFrameworkCore;
using System.Xml;


namespace CarseerAssignment.Repos
{
    public class FilterCars : IFilterCars
    {
 
        public List<Car> GetCarByCarMaker(DBcontext context, string _make)
        {
            var myTableData = context.Set<Car>().Where(e => e.make.Equals(_make)).ToList();


            return myTableData;
        }

        public List<Car> GetCarByHorsePowerRange(DBcontext context, int min, int max)
        {
            var myTableData = context.Set<Car>().Where(e => !string.IsNullOrEmpty(e.horsepower) && Convert.ToInt32(e.horsepower) >= min && Convert.ToInt32(e.horsepower) <= max).ToList();
            return myTableData;
        }

        public List<Car> GetCarBynumofCylinders(DBcontext context, string numofCylinders)
        {
            var myTableData = context.Set<Car>().Where(e => e.numofcylinders.Equals(numofCylinders.ToLower())).ToList();


            return myTableData;
        }

        public List<Car> GetCarByNumofdoors(DBcontext context, string numofdoors)
        {
            var myTableData = context.Set<Car>().Where(e => e.numofdoors.Equals(numofdoors.ToLower())).ToList();


            return myTableData;
        }

        public List<Car> GetCarByPriceRange(DBcontext context, int min, int max)
        {
            var myTableData = context.Set<Car>().Where(e => !string.IsNullOrEmpty(e.price) && Convert.ToInt32(e.price) >= min && Convert.ToInt32(e.price) <= max ).ToList();
            return myTableData;
        }

        public List<Car> GetCars(DBcontext context)
        {
            var myTableData = context.Set<Car>().ToList();


            return myTableData;
        }
    }
}
