using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TextAnalyzer.API.Models;
using TextAnalyzer.DAL.Entities;
using TextAnalyzer.DAL.Interfaces;

namespace TextAnalyzer.API.Controllers
{
    [Route("data")]
    public class DataController : ApiController
    {
        private IUnitOfWork _uow;

        public DataController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetDataRecords()
        { 
            var dataRecords = await _uow.DataRecords.GetAll().ToListAsync();
            var dataRecordsDTO = Mapper.Map<List<Data>, List<DataDTO>>(dataRecords);
            return Ok(dataRecords);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetData(int id)
        {
            var data = _uow.DataRecords.Get(id);
            if (data == null)
                return NotFound();
            var dataDTO = Mapper.Map<Data, DataDTO>(data);
            return Ok(dataDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostData([FromBody]DataDTO dataDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var data = Mapper.Map<DataDTO, Data>(dataDTO);
            data.CreatedAt = DateTime.Now;
            _uow.DataRecords.Add(data);
            _uow.SaveChanges();

            return Ok(data.Id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutData([FromBody]DataDTO dataDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dataDTO.Id <= 0)
                return BadRequest();

            var data = _uow.DataRecords.Get(dataDTO.Id);
            if (data == null)
                return NotFound();

            Mapper.Map<DataDTO, Data>(dataDTO, data);
            data.CreatedAt = DateTime.Now;
            _uow.DataRecords.Add(data);
            _uow.SaveChanges();

            return Ok(data.Id);
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteData(int id)
        {
            var data = _uow.DataRecords.Get(id);
            if (data == null)
                return NotFound();
            _uow.DataRecords.Remove(data);
            _uow.SaveChanges();
            return Ok(id);
        }

    }
}