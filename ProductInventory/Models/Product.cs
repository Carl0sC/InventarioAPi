using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductInventory.Models
{
    public enum ProductState
    {
        Available,
        OutOfStock,
        Defective
    }

    public enum ManufacturingType
    {
        Handmade,
        HandAndMachineMade
    }

    public class Product
    {
        [Key] // Marca el campo Id como la clave primaria.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Genera automáticamente el valor del Id.
        public int Id { get; set; }

        [Required] // Hace que el campo Name sea obligatorio.
        [StringLength(100)] // Limita la longitud del nombre a 100 caracteres.
        public string Name { get; set; }

        [Required] // Hace que el campo ManufacturingType sea obligatorio.
        [Column("ManufacturingType")] // Opcional: nombre de la columna en la base de datos.
        public ManufacturingType ManufacturingType { get; set; }

        [Required] // Hace que el campo State sea obligatorio.
        [Column("State")] // Opcional: nombre de la columna en la base de datos.
        public ProductState State { get; set; }
    }
}
