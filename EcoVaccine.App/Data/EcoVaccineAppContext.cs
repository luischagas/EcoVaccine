using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcoVaccine.Application.Models.Patient.Request;

namespace EcoVaccine.App.Data
{
    public class EcoVaccineAppContext : DbContext
    {
        public EcoVaccineAppContext (DbContextOptions<EcoVaccineAppContext> options)
            : base(options)
        {
        }

        public DbSet<EcoVaccine.Application.Models.Patient.Request.PatientRequest> PatientRequest { get; set; }
    }
}
