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

        //[ResponseType(typeof(Data))]
        [HttpGet]
        public IHttpActionResult GetData(int id)
        {
            var data = _uow.DataRecords.Get(id);
            if (data == null)
                return NotFound();
            var dataDTO = Mapper.Map<Data, DataDTO>(data);
            return Ok(dataDTO);
        }

        //[ResponseType(typeof(void))]
        //[HttpPut]
        //public async Task<IHttpActionResult> PutData(int id, Data data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != data.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(data).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DataExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Data
        //[ResponseType(typeof(Data))]
        //public async Task<IHttpActionResult> PostData(Data data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DataRecords.Add(data);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = data.Id }, data);
        //}

        //// DELETE: api/Data/5
        //[ResponseType(typeof(Data))]
        //public async Task<IHttpActionResult> DeleteData(int id)
        //{
        //    Data data = await db.DataRecords.FindAsync(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    db.DataRecords.Remove(data);
        //    await db.SaveChangesAsync();

        //    return Ok(data);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DataExists(int id)
        //{
        //    return db.DataRecords.Count(e => e.Id == id) > 0;
        //}
    }
}