using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_Kelompok_3.Interface
{
    public interface IGameObserver<T>
    {
        void UpdateData(T payload);
    }
}
