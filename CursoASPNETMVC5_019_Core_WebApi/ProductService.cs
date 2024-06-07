using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPNETMVC5_019_Core_WebApi
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Price: {2}, Descripcion {3}", Id, Name,  Price, Descripcion );
        }

    }

}
