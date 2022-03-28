using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Noticia_API.Models
{
    public class Noticia
    {
        //ID não precisa aparecer no metodo PUT (supondo que o banco seja com o id primery key auto_increment)
        // caso fosse auto_increment apenas comentar aqui e modificar no metodo put no NoticiaController
        [Key]
        [Required]
        [Obsolete]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string TITULO { get; set; }
        [Required(ErrorMessage = "O campo Texto é obrigatório")]
        public string TEXTO { get; set; }
        [Key]
        [Required(ErrorMessage = "O campo Id do Autor é obrigatório e Precisa ser um Autor já cadastrado")]
        public int ID_AUTOR { get; set; }
    }
}
