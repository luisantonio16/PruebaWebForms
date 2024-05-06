using CapaDatos.Modelos;
using CapaDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNeocio
{
    public class PersonaNeocio
    {
        private int id;
        private string nombre;
        private string apellido;
        private int edad;

        public int Id { get => id; set => id = value; }
        [Required]
        public string Nombre { get => nombre; set => nombre = value; }
        [Required]
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }


        private List<PersonaNeocio> personaNegocioLista;
        private RepositorioMaestro sql = new RepositorioMaestro();

        public EstadoEntidad estado { private get; set; }

        public string agregarPersona()
        {
            string mensanje = "";

            try
            {
                var PersonasData = new Persona();

                PersonasData.id = Id;
                PersonasData.Nombre = Nombre;
                PersonasData.Apellido = Apellido;
                PersonasData.Edad = Edad;


                switch (estado)
                {
                    case EstadoEntidad.Agregar:
                        sql.AgregarPersona(PersonasData);
                        mensanje = "SE AGREGO CORRECTAMENTE";
                        break;

                    case EstadoEntidad.Actualizar:
                        sql.ActualizarPersona(PersonasData);
                        mensanje = "SE ACTUALIZO CORRECTAMENTE";
                        break;

                    case EstadoEntidad.Eliminar:
                        sql.eliminarPersona(id);
                        break;

                }


            }
            catch (Exception ex)
            {

            }

            return mensanje;


        }

        public List<PersonaNeocio> ObtenerLista()
        {

            var personaData = sql.ObtenerLista();
            personaNegocioLista = new List<PersonaNeocio>();
            foreach (Persona item in personaData)
            {
                personaNegocioLista.Add(new PersonaNeocio
                {

                    id = item.id,
                    nombre = item.Nombre,
                    apellido = item.Apellido,
                    edad = item.Edad



                });
            }
            return personaNegocioLista;


        }

        public IEnumerable<PersonaNeocio> buscarPersona(string filtro)
        {
            return personaNegocioLista.FindAll(a => a.nombre.Contains(filtro) || a.apellido.Contains(filtro));
        }

        public DataTable buscar(string codigo)
        {
            return sql.buscar(codigo);
        }
    }
}
