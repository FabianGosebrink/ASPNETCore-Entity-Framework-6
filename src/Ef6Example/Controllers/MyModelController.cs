using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Ef6Example.Models;
using Ef6Example.Repositories;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace Ef6Example.Controllers
{
    [Route("api/[controller]")]
    public class MyModelController
    {
        private readonly IExampleRepository _exampleRepository;

        public MyModelController(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        // GET: api/mymodel
        [HttpGet("", Name = "GetAll")]
        public IActionResult Get()
        {
            try
            {
                List<MyModel> MyModels = _exampleRepository.GetAll().ToList();
                return new JsonResult(MyModels.Select(x => Mapper.Map<MyModelViewModel>(x)));
            }
            catch (Exception)
            {
                //Do something with the exception
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingle")]
        public IActionResult Get(int id)
        {
            try
            {
                MyModel MyModel = _exampleRepository.GetSingleById(id);

                if (MyModel == null)
                {
                    return new HttpNotFoundResult();
                }

                return new HttpOkObjectResult(Mapper.Map<MyModelViewModel>(MyModel));
            }
            catch (Exception ex)
            {
                //Do something with the exception
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]MyModelViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return new BadRequestResult();
                }

                MyModel item = Mapper.Map<MyModel>(viewModel);

                _exampleRepository.Add(item);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return new CreatedAtRouteResult("GetSingle", new { controller = "MyModel", id = item.Id }, item);
                }

                return new BadRequestResult();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MyModelViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return new BadRequestResult();
                }

                MyModel singleById = _exampleRepository.GetSingleById(id);

                if (singleById == null)
                {
                    return new HttpNotFoundResult();
                }

                singleById.Name = viewModel.Name;

                _exampleRepository.Update(singleById);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return new HttpOkObjectResult(Mapper.Map<MyModelViewModel>(singleById));
                }

                return new BadRequestResult();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                MyModel singleById = _exampleRepository.GetSingleById(id);

                if (singleById == null)
                {
                    return new HttpNotFoundResult();
                }

                _exampleRepository.Delete(id);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return new NoContentResult();
                }

                return new BadRequestResult();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
