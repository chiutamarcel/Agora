using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class Entity : IEntity
    {
        public int ID { get; set; }

        public Entity(int id)
        {
            ID = id;
        }
        
    }
}
