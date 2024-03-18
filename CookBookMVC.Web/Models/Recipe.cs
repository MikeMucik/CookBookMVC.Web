using System.ComponentModel;

namespace CookBookMVC.Web.Models
{
    public class Recipe
    {
       // [DisplayName("Identyfikator")]
        public int Id { get; set; }
     
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
