using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using studentbackend.Model;
using System.Data.SqlClient;
using System.Data;

namespace studentbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student : ControllerBase
    {
        static string constring = "server=192.168.1.252;database=harshitStudent;uid=harshitchaudhary;password=8Eg8d@B$";
        [HttpGet]
        public async Task<ActionResult<List<studentData>>> Get()
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = "xspgetStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                string result = JsonConvert.SerializeObject(dt);
                return CreatedAtAction(nameof(this.Get), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        [HttpPost]
        public async Task<ActionResult<studentData>> Post(studentData std)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = "xspInsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", std.name);
                cmd.Parameters.AddWithValue("emailid", std.emailid);
                cmd.Parameters.AddWithValue("city", std.city);
                cmd.Parameters.AddWithValue("phoneNo", std.phoneNo);
                cmd.ExecuteReader();
                return CreatedAtAction(nameof(this.Post), std);
            }
            catch
            (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int id)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = "xspDeleteStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "StudentId Not Found!!");
                }
                return CreatedAtAction(nameof(this.Get), "");
            }
            catch
            (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        [HttpGet]
        [Route("GetByID")]
        public async Task<ActionResult<studentData>> Get(int id)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = "xspgetByIdStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string result = JsonConvert.SerializeObject(dt);
                if (result == "[]")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "StudentID Not Found!!");
                }
                return CreatedAtAction(nameof(this.Get), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        [HttpPut]

        public async Task<ActionResult<string>> Put([FromBody] studentData std)

        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.CommandText = "xspUpdateStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", std.name);
                cmd.Parameters.AddWithValue("emailid", std.emailid);
                cmd.Parameters.AddWithValue("city", std.city);
                cmd.Parameters.AddWithValue("phoneNo", std.phoneNo);
                cmd.Parameters.AddWithValue("id", std.id);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt < 1)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Student Not Found!!");
                }
                return CreatedAtAction(nameof(this.Get), "");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
