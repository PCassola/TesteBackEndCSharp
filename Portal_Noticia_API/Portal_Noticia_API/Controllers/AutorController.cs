using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Portal_Noticia_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Noticia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AutorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("Visualização De Autores")]
        public IActionResult GetAutor()
        {
            try
            {
                string query = @"SELECT * FROM AUTOR";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok(table);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpGet("Pesquisa Por Id")]
        public IActionResult GetAutorId(string parametro)
        {
            try
            {
                string query;
                if (parametro == null)
                {
                    query = @"SELECT * FROM AUTOR";

                }
                else
                {
                    query = @"SELECT * FROM AUTOR WHERE ID = @NomeParametro";
                }

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NomeParametro", parametro);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok(table);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpGet("Pesquisa Por Nome")]
        public IActionResult GetAutorNome(string parametro)
        {
            try
            {
                string query;
                if (parametro == null)
                {
                    query = @"SELECT * FROM AUTOR";

                }
                else
                {
                    query = @"SELECT * FROM AUTOR WHERE NOME LIKE @NomeParametro";
                }

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NomeParametro", "%" + parametro + "%");

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok(table);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpPost("Criar Autor")]
        public IActionResult PostAutor(Autor autor)
        {
            try
            {

                //Validação comentada pressupondo que o ID no banco é primary key auto increment
                //if (autor.ID == null || autor.ID == 0)
                //{
                //    return NotFound("O campo Id é obrigatório");
                //}
                if (autor.NOME == null || autor.NOME == "")
                {
                    return NotFound("O campo Nome é obrigatório");
                }

                string query = @"INSERT INTO AUTOR (NOME) VALUES (@AutorNome)";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@AutorNome", autor.NOME);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Autor Adicionado Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutAutor(Autor autor, int id)
        {
            try
            {

                //Validação comentada pressupondo que o ID no banco é primary key auto increment
                //if (autor.ID == null || autor.ID == 0)
                //{
                //    return NotFound("O campo Id é obrigatório");
                //}
                if (autor.NOME == null || autor.NOME == "")
                {
                    return NotFound("O campo Nome é obrigatório");
                }
                if (id == null || id == 0)
                {
                    return NotFound("O campo Id é obrigatório para poder saber qual Autor modificar");
                }

                string query = @"UPDATE AUTOR SET NOME = @AutorNome WHERE ID = @AutorId";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@AutorNome", autor.NOME);
                        myCommand.Parameters.AddWithValue("@AutorId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Autor Alterado Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAutor(int id)
        {
            try
            {

                if (id == null || id == 0)
                {
                    return NotFound("O campo Id é obrigatório para poder saber qual Autor deletar");
                }

                string query = @"DELETE FROM AUTOR WHERE ID = @AutorId";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@AutorId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Autor Deletado Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }
    }
}
