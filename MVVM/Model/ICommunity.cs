using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal interface ICommunity
    {
        //TODO: implementare TRIE pentru postari pentru a fi cat mai rapid
        string Name { get; set; }
        string Description { get; set; }
        int OwnerID { get; set; }       //User type
        int CategoryID { get; set; }    //User type

        void Save();
        void Delete();
    }
}
