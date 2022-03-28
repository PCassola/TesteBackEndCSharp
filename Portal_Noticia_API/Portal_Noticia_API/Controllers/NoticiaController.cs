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
    public class NoticiaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NoticiaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("Visualização De Notícias")]
        public IActionResult GetNoticia()
        {
            try
             {
                string query = @"SELECT ID , TITULO , TEXTO , ID_AUTOR AS 'ID DO AUTOR', (SELECT NOME FROM AUTOR WHERE ID = ID_AUTOR) AS 'NOME' FROM NOTICIA";

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

        [HttpGet("Pesquisa De Notícias")]
        public IActionResult GetNoticiaPalavraChave(string parametro)
        {
            try
            {
                string query;
                if(parametro == null)
                {
                     query = @"SELECT ID , TITULO , TEXTO , ID_AUTOR AS 'ID DO AUTOR', (SELECT NOME FROM AUTOR WHERE ID = ID_AUTOR) AS 'NOME' FROM NOTICIA";

                }
                else
                {
                    query = @"SELECT NT.ID , NT.TITULO , NT.TEXTO , AT.ID AS 'ID/AUTOR', AT.NOME AS 'NOME' FROM NOTICIA NT
                              INNER JOIN AUTOR AT ON AT.ID = NT.ID_AUTOR
                              WHERE TITULO LIKE @NoticiaParametro OR TEXTO LIKE @NoticiaParametro OR AT.NOME LIKE @NoticiaParametro";
                }

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NoticiaParametro",  "%" + parametro + "%");

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

        [HttpGet("Pesquisa Por Título")]
        public IActionResult GetNoticiaTitulo(string parametro)
        {
            try
            {
                string query;
                if (parametro == null)
                {
                    query = @"SELECT ID , TITULO , TEXTO , ID_AUTOR AS 'ID DO AUTOR', (SELECT NOME FROM AUTOR WHERE ID = ID_AUTOR) AS 'NOME' FROM NOTICIA";

                }
                else
                {
                    query = @"SELECT NT.ID , NT.TITULO , NT.TEXTO , AT.ID AS 'ID/AUTOR', AT.NOME AS 'NOME' FROM NOTICIA NT
                              INNER JOIN AUTOR AT ON AT.ID = NT.ID_AUTOR
                              WHERE TITULO LIKE @NoticiaParametro ";
                }

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NoticiaParametro", "%" + parametro + "%");

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

        [HttpGet("Pesquisa Por Texto")]
        public IActionResult GetNoticiaTexto(string parametro)
        {
            try
            {
                string query;
                if (parametro == null)
                {
                    query = @"SELECT ID , TITULO , TEXTO , ID_AUTOR AS 'ID DO AUTOR', (SELECT NOME FROM AUTOR WHERE ID = ID_AUTOR) AS 'NOME' FROM NOTICIA";

                }
                else
                {
                    query = @"SELECT NT.ID , NT.TITULO , NT.TEXTO , AT.ID AS 'ID/AUTOR', AT.NOME AS 'NOME' FROM NOTICIA NT
                              INNER JOIN AUTOR AT ON AT.ID = NT.ID_AUTOR
                              WHERE TEXTO LIKE @NoticiaParametro ";
                }


                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NoticiaParametro", "%" + parametro + "%");

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

        [HttpGet("Pesquisa Por Autor")]
        public IActionResult GetNoticiaAutor(string parametro)
        {
            try
            {
                string query;
                if (parametro == null)
                {
                    query = @"SELECT ID , TITULO , TEXTO , ID_AUTOR AS 'ID DO AUTOR', (SELECT NOME FROM AUTOR WHERE ID = ID_AUTOR) AS 'NOME' FROM NOTICIA";

                }
                else
                {
                    query = @"SELECT NT.ID , NT.TITULO , NT.TEXTO , AT.ID AS 'ID/AUTOR', AT.NOME AS 'NOME' FROM NOTICIA NT
                              INNER JOIN AUTOR AT ON AT.ID = NT.ID_AUTOR
                              WHERE AT.NOME LIKE @NoticiaParametro";
                }

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NoticiaParametro", "%" + parametro + "%");

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


        [HttpPost("Criar Notícia")]
        public IActionResult PostNoticia(Noticia noticia)
        {
            try
            {
                //Validação comentada pressupondo que o ID no banco é primary key auto increment
                //if (noticia.ID == null || noticia.ID == 0)
                //{
                //    return NotFound("O campo Id é obrigatório");
                //}
                if (noticia.TITULO == null || noticia.TITULO == "")
                {
                    return NotFound("O campo Título é obrigatório");
                }
                if (noticia.TEXTO == null || noticia.TEXTO == "")
                {
                    return NotFound("O campo Texto é obrigatório");
                }
                if (noticia.ID_AUTOR == null || noticia.ID_AUTOR == 0)
                {
                    return NotFound("O campo Id do Autor é obrigatório e Precisa ser um Autor já cadastrado");
                }

                string query = @"INSERT INTO NOTICIA (TITULO,TEXTO,ID_AUTOR) VALUES (@NoticiaTitulo,@NoticiaTexto,@AutorID)";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@NoticiaTitulo", noticia.TITULO);
                        myCommand.Parameters.AddWithValue("@NoticiaTexto", noticia.TEXTO);
                        myCommand.Parameters.AddWithValue("@AutorID", noticia.ID_AUTOR);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Noticia Adicionada Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutNoticia(Noticia noticia, int id)
        {
            try
            {

                //Validação comentada pressupondo que o ID no banco é primary key auto increment
                //if (noticia.ID == null || noticia.ID == 0)
                //{
                //    return NotFound("O campo Id é obrigatório");
                //}
                if (noticia.TITULO == null || noticia.TITULO == "")
                {
                    return NotFound("O campo Título é obrigatório");
                }
                if (noticia.TEXTO == null || noticia.TEXTO == "")
                {
                    return NotFound("O campo Texto é obrigatório");
                }
                if (noticia.ID_AUTOR == null || noticia.ID_AUTOR == 0)
                {
                    return NotFound("O campo Id do Autor é obrigatório e Precisa ser um Autor já cadastrado");
                }
                if (id == null || id == 0)
                {
                    return NotFound("O campo Id é obrigatório para poder saber qual Noticia modificar");
                }


                string query = @"UPDATE NOTICIA SET TITULO = @NoticiaTitulo, TEXTO = @NoticiaTexto, ID_AUTOR = @AutorID WHERE ID = @NoticiaId";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {

                        myCommand.Parameters.AddWithValue("@NoticiaTitulo", noticia.TITULO);
                        myCommand.Parameters.AddWithValue("@NoticiaTexto", noticia.TEXTO);
                        myCommand.Parameters.AddWithValue("@AutorID", noticia.ID_AUTOR);
                        myCommand.Parameters.AddWithValue("@NoticiaId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Noticia Alterada Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNoticia(int id)
        {
            try
            {

                if (id == null || id == 0)
                {
                    return NotFound("O campo Id é obrigatório para poder saber qual Noticia deletar");
                }

                string query = @"DELETE FROM NOTICIA WHERE ID = @NoticiaId";

                DataTable table = new DataTable();

                string sqlDataSource = _configuration.GetConnectionString("PortalDBCon");
                MySqlDataReader myReader;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@NoticiaId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                    return Ok("Noticia Deletada Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro: " + ex);
            }
        }

    }
}
