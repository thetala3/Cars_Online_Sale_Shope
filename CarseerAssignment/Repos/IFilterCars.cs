using CarseerAssignment.Models;

namespace CarseerAssignment.Repos
{
    public interface IFilterCars
    {
        public List<Car> GetCars(DBcontext context);

        public List<Car> GetCarByCarMaker(DBcontext context, string _make);
        public List<Car> GetCarByHorsePowerRange(DBcontext context, int min, int max);
        public List<Car> GetCarByPriceRange(DBcontext context,int min, int max);
        public List<Car> GetCarByNumofdoors(DBcontext context, string numofdoors);
        public List<Car> GetCarBynumofCylinders(DBcontext context, string numofCylinders);
    }
}
