using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ODataTest.Models;
using ODataTest.Services;

namespace ODataTest.Controllers
{
    public class StudentsController : ODataController
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get(ODataQueryOptions<Student> opts)
        {
            return Ok(
                opts.RawValues.Select == null ? _studentService.GetAll(opts) : _studentService.GetAllDynamic(opts));
        }
    }
}