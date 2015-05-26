using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Restaurant.DataModels.Management.Menus
{
    [Serializable]
    public class Menu : Entity
    {
        public int MenuID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<MenuItem> Items { get; set; }

        [Required]
        public MenuType MenuType { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool Available { get; set; }
        
        
        public Menu()
        {
            Created = DateTime.Now;
            Items = new List<MenuItem>();
        }

        public IList<T> GetItems<T>() where T : MenuItem
        {
            return Items.Where(i => i.GetType() == typeof (T)).Cast<T>().ToList();
        } 
    }
}
