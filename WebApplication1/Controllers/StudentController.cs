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
    public class StudentController : ControllerBase
    {
        public readonly prueba_tecnicaContext _dbcontext;

        public StudentController(prueba_tecnicaContext _context)
        {
            _dbcontext = _context;
        }
        //Endpoint para poder buscar todos los estudiantes
        [HttpGet]
        [Route("getStudents")]
        public IActionResult getStundent()
        {
            List<Student> list = new List<Student>();
            try
            {
                list = _dbcontext.Students.ToList();
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
        [Route("getStudentById/{StudentId:int}")]
        public IActionResult getStudentById(int StudentId)
        {

            Student list = new Student();
            try
            {

                list = _dbcontext.Students.Find(StudentId);
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

        [HttpGet]
        [Route("listStudents")]
        public IActionResult GetListStudents(int page = 1, int limit = 10)
        {
            try
            {
                // Calcula el índice de inicio de la página
                int startIndex = (page - 1) * limit;

                // Obtiene los estudiantes paginados
                var students = _dbcontext.Students.Skip(startIndex).Take(limit).ToList();

                // Construye la respuesta
                var response = new
                {
                    data = students.Select(s => new
                    {
                        id = s.StudentId,
                        firstName = s.FirstName,
                        lastName = s.LastName,
                        dateOfBirth = s.DateOfBirth,
                    }),
                    total = _dbcontext.Students.Count(),
                    page,
                    limit
                };

                // Devuelve la respuesta
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error interno del servidor", error = e.Message });
            }
        }

        //Enpoint para ingresar un estudiante
        [HttpPost]
        [Route("postStudent")]
        public IActionResult postStudent([FromBody] Student student)
        {
            try
            {


                if (student.FirstName == null)
                {
                    return BadRequest("Error");
                }
                _dbcontext.Students.Add(student);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha guardado correctamente", status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error", status = "200", Error = e });
                throw;
            }

        }
        //Endpoint para actualizar un estudiante
        [HttpPut]
        [Route("putStudent")]
        public IActionResult postPokemon([FromBody] Student student)
        {
            try
            {
                Student studentFind = _dbcontext.Students.Find(student.StudentId);

                if (studentFind == null)
                {
                    return BadRequest("Student not found");
                }
                studentFind.FirstName = student.FirstName is null ? studentFind.FirstName: student.FirstName;
                studentFind.LastName = student.LastName is null ? studentFind.LastName : student.LastName;
                studentFind.DateOfBirth = student.DateOfBirth is null ? studentFind.DateOfBirth : student.DateOfBirth;
                studentFind.CourseId = student.CourseId is null ? studentFind.CourseId : student.CourseId;
                studentFind.CourseId = student.CourseId is null ? studentFind.CourseId : student.CourseId;
                _dbcontext.Students.Update(studentFind);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha actualizado correctamente", status = "200" });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "Error", status = "200", Error = e });
                throw;
            }

        }
        //Endpoint para eliminar un estudiante 
        [HttpDelete]
        [Route("deleteStudent/{StudentId:int}")]
        public IActionResult deleteStuent(int StudentId)
        {
            try
            {
                Student studentFind = _dbcontext.Students.Find(StudentId);

                if (studentFind == null)
                {
                    return BadRequest("Student not found");
                }
                _dbcontext.Students.Remove(studentFind);
                _dbcontext.SaveChanges();
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
