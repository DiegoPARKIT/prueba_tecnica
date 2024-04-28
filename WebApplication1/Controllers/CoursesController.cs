using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;
using System.Collections.Generic;
namespace WEBAPI.Controllers
{
    [Route("api/[controller]")] // Aquí defines la ruta base para el controlador
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public readonly prueba_tecnicaContext _dbcontext;

        public CoursesController(prueba_tecnicaContext _context)
        {
            _dbcontext = _context;
        }
        //Endpoint para poder buscar todos los estudiantes
        [HttpGet]
        [Route("getCourse")]
        public IActionResult getCourse()
        {
            List<Course> list = new List<Course>();
            try
            {
                list = _dbcontext.Courses.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha realizado correctamente la consulta", response = list, status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error realizando la consulta", status = "200", Error = e });

                throw;
            }

        }
        //Endpoint para buscar un estudiante por id 
        [HttpGet]
        [Route("getCourseById/{CourseId:int}")]
        public IActionResult getCourseById(int CourseId)
        {

            Course list = new Course();
            try
            {

                list = _dbcontext.Courses.Find(CourseId);
                if (list == null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "No se encontró el registro", status = "200" });
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha realizado correctamente la consulta", response = list, status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error realizando la consulta", status = "200", Error = e });

                throw;
            }

        }

        //Enpoint para ingresar un estudiante
        [HttpPost]
        [Route("postCourse")]
        public IActionResult postCourse([FromBody] Course course)
        {
            try
            {
                if (course.Name == null)
                { 
                    return BadRequest("Error");
                }
                _dbcontext.Courses.Add(course);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha guardado correctamente", status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error", status = "200", Error = e });
                throw;
            }

        }
        //Endpoint para eliminar un estudiante 
        [HttpDelete]
        [Route("deleteCourse/{CourseId:int}")]
        public IActionResult deleteStudent(int CourseId)
        {
            try
            {
                Course CourseFind = _dbcontext.Courses.Find(CourseId);

                if (CourseFind == null)
                {
                    return BadRequest("Course not found");
                }
                if(CourseFind != null)
                {
                    _dbcontext.Courses.Remove(CourseFind);
                    _dbcontext.SaveChanges();
                }

                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha eliminado correctamente", status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error", status = "200", Error = e });
                throw;
            }

        }


    }
}
