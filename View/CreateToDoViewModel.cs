using System.ComponentModel.DataAnnotations;

namespace WebAPII.View
{
    //Cria os verbos de manipulação de dados (CRUD)
    //ToDo: 6.2 - Cria a estrutura View e a classe CreateToDoViewModel
    public class CreateToDoViewModel
    {
        //ToDo: 6.2.1 - Adiciona o método Title como exigido
        [Required]
        public string Title { get; set; }

    }
}