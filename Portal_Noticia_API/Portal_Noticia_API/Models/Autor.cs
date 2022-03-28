using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Noticia_API.Models
{
    public class Autor
    {
        //ID não precisa aparecer no metodo PUT (supondo que o banco seja com o id primery key auto_increment)
        // caso fosse auto_increment apenas comentar aqui e modificar no metodo put no AutorController
        [Key]
        [Required]
        [Obsolete]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MinLength(3,ErrorMessage ="O Nome deve conter no mínimo 3 Caracteres")]
        public string NOME { get; set; }
    }
}
