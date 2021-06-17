using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcoVaccine.Application.Models.Patient.Request
{
    public class PatientRequest
    {
        #region Properties

        [JsonProperty("email")]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [JsonProperty("usu_nome")]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [JsonProperty("telefone")]
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Phone { get; set; }

        #endregion Properties
    }
}