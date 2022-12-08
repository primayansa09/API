using API.Repositories.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        public ActionResult<Entity> Get()
        {
            var get = repository.Get();
            if (get.Count() != 0)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = get.Count() + " Data Berhasil Ditemukan",
                        Data = get
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Tidak Ditemukan",
                        Data = get
                    });
            }
            
        }

        [HttpGet]
        [Route("{key}")]
        //[EnableCors("AllowOrigin")]
        public ActionResult Get(Key key)
        {
            var get = repository.Get(key);
            if (get != null)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Ditemukan",
                        Data = get
                    });

            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Tidak Ditemukan",
                        Data = get
                    });
            }

        }

        [HttpPost]
        //[EnableCors("AllowOrigin")]
        public ActionResult Insert(Entity entity)
        {
            var insert = repository.Insert(entity);
            if(insert >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Dimasukan",
                        Data = insert
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Gagal Dimasukan",
                        Data = insert
                    });
            }
        }

        [HttpPut]
        //[EnableCors("AllowOrigin")]
        public ActionResult Update(Entity entity, Key key)
        {
            var update = repository.Update(entity, key);
            if (update >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Diupdate",
                        Data = update
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Gagal Diupdate",
                        Data = update
                    });
            }
        }
        [HttpDelete]
        [Route("{key}")]
        //[EnableCors("AllowOrigin")]
        public ActionResult Delete(Key key)
        {
            var delete = repository.Delete(key);
            if(delete >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Di hapus",
                        Data = delete
                    });
            }
            else if(delete == 0)
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Gagal Di hapus",
                        Data = delete
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        nessage = "Error",
                        Data = delete
                    });
            }
        }
    }
}
