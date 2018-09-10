// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class PointOfInterest
    {
        // TODO: Annotations, nuestro domino con depencencias a una implementacion de persistencia,
        // cosiderar separar domino de negocio, del modelo de entidades necesario para el ORM, comparar vs FluentAPI y/o follow conventions

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // id will be genereted on add
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[ForeignKey("CityId")]
        public City City { get; set; } // here will be consider as navigation property since we are follow the convention

        /* By convention:
         a relation will be created when there is a navigation property discovered on a type. 
         And a property is considered a navigation property if the type it points cannot be mapped to a scalar type by the current database provider 
         */

        public int CityId { get; set; }

        
        public string Description { get; set; }
    }
}
