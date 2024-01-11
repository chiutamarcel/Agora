using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class Community
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerID { get; set; }
        public int CategoryID { get; set; }

        public Community()
        {
        }

        public Community(string name, string description, int ownerID, int categoryID)
        {
            Name = name;
            Description = description;
            OwnerID = ownerID;
            CategoryID = categoryID;
        }
    }
}
