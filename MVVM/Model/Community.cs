using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class Community : Entity, ICommunity
    {
        public Community(int id) : base(id)
        {
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OwnerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CategoryID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
