using System;

namespace ProjetoPetshop.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeDono { get; set; }
        public string EnderecoDono { get; set; }
        public string TelefoneDono { get; set; }
        public string EstadoSaude { get; set; }
        public string MotivoInternacao { get; set; }
        public string Foto { get; set; }
        public int IdPetshop { get; set; }
    }
}
