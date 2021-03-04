using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.OData.Query;
using ODataTest.Models;
using ODataTest.Repositories;

namespace ODataTest.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(StudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> GetAll(ODataQueryOptions<Student> opts)
        {
            var students = _studentRepository.GetAll(opts);
            return students.Select(_mapper.Map<StudentDto>);
        }

        public IEnumerable GetAllDynamic(ODataQueryOptions<Student> opts)
        {
            return _studentRepository.GetAllDynamic(opts);
        }

        public StudentDto GetById(long key)
        {
            return _mapper.Map<StudentDto>(_studentRepository.GetById(key));
        }
        
        public dynamic GetByIdDynamic(long key,ODataQueryOptions<Student> opts)
        {
            return _studentRepository.GetByIdDynamic(key,opts);
        }
    }
}