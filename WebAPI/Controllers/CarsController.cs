﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        //public List<Car> Get()
        //{
            //return new List<Car> 
            //{
            //    new Car{ ID= 1, CarName= "Fiat Linea"},
            //    new Car{ ID= 2, CarName= "Renault Clio"},
            //};

            //ICarService carService = new CarManager(new EfCarDal());
            //var result = carService.GetAll();
            //return result.Data;

            //var result = _carService.GetAll();
            //return result.Data;

        //}

        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
