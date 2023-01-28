using Microsoft.AspNetCore.Mvc;
using CarseerAssignment.Models;
using CarseerAssignment.Repos;
using CsvHelper;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Text.Json;
using System.Diagnostics.Metrics;

namespace CarseerAssignment.Controllers
{
    //to implement the Web API controller in ASP.NET Core.
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICSVService _csvService;
        private readonly DBcontext _DB;
        private readonly IFilterCars _filterCars;
        public CarController(ICSVService csvService, DBcontext dB, IFilterCars filterCar)
        {
            // injected the ICSVService to use the read operation for CSV files.
            _csvService = csvService;
            _DB = dB;
            _filterCars = filterCar;    
        }

        [HttpPost("LoadCarsData")]
        public async Task<IActionResult> LoadCarsData([FromForm] IFormFileCollection file)
        {

            //used the ReadCSV method of the CSVService to get the data of the CSV file after reading it.
            try
            {
                var records = _csvService.ReadCSV<Car>(file[0].OpenReadStream());

                foreach (var record in records)
                {

                    _DB._car.Add(record);


                }

                return Ok(_DB._car);
            }catch(Exception ex) { return NotFound( ex.Message); }

        }

        [HttpGet("GetCars")]
        public IActionResult GetCars() {
            try { return Ok(_filterCars.GetCars(_DB)); }
            catch(Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet("GetCarByCarMaker")]

        public  IActionResult GetCarByCarMaker(string maker)
        {

            try {
                return Ok(_filterCars.GetCarByCarMaker(_DB,maker));
            }catch(Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet("GetCarByNumofdoors")]
        public IActionResult GetCarByNumofdoors( string numofdoors) {

            try
            {
                return Ok(_filterCars.GetCarByNumofdoors(_DB, numofdoors));
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet("GetCarBynumofCylinders")]
        public IActionResult GetCarBynumofCylinders(string numofCylinders)
        {
            try
            {
                return Ok(_filterCars.GetCarBynumofCylinders(_DB, numofCylinders));
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet("GetCarByPriceRange")]
        public IActionResult GetCarByPriceRange(int min, int max) {
            try
            {
                return Ok(_filterCars.GetCarByPriceRange(_DB, min, max));
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }

        [HttpGet("GetCarByHorsePowerRange")]
        public IActionResult GetCarByHorsePowerRange(int min, int max) {
            try
            {
                return Ok(_filterCars.GetCarByHorsePowerRange(_DB, min, max));
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }
    }
}
