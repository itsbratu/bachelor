using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    interface IRepository <T, Tid>
    {
        void Add(T elem);

        void Delete(Tid id);

        void Update(T elem);

        T FindByID(Tid id);

        IList<T> GetAll();

    }
}
