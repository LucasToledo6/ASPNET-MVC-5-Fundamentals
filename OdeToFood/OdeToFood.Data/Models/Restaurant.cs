using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        [Required] //data annotation
                   //it means that when we try to create or edit the name of a restaurant, the Name field cannot be left empty

        [MaxLength(255)] //this specifies that the Name field can have a maximum length of 255 characters
        public string Name { get; set; }
        public int Id { get; set; }

        // Another attributes
        // [DisplayFormat(DataFormatString =)] //used to specify how a property's value is displayed and formatted
        // [DisplayFormat(NullDisplayText =)]
        // [DataType(DataType.Password)] //used to specify that a property should be treated as a password

        [Display(Name="Type of food")] //this annotation is used to specify how the Cuisine field should be labeled when it is rendered in a view.
                                       //it's more user-friendly
        public CuisineType Cuisine { get; set; }
    }
}
