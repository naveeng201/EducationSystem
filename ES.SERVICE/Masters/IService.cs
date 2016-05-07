using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.SERVICE
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Insert(T asset);
        void Update(T asset);
        void SingleOrDefault(int ID);
    }


}
