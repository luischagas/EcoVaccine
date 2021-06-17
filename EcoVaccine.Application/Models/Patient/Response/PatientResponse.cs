using Newtonsoft.Json;
using System.ComponentModel;

namespace EcoVaccine.Application.Models.Patient.Response
{
    public class PatientResponse
    {
        #region Constructors

        public PatientResponse(string email, string gender, string name, string neighborhood, string phone)
        {
            Email = email;
            Gender = gender;
            Name = name;
            Neighborhood = neighborhood;
            Phone = phone;
        }

        #endregion Constructors

        #region Properties

        [JsonProperty("email")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [JsonProperty("sexo")]
        [DisplayName("Sexo")]
        public string Gender { get; set; }

        [JsonProperty("usu_nome")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [JsonProperty("bairro")]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [JsonProperty("telefone")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        #endregion Properties
    }
}