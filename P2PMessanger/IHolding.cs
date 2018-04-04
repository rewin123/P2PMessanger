using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2PMessanger
{
    /// <summary>
    /// Интерфейс элементов, что могут храниться в JHolder
    /// </summary>
    interface IHolding : IEquatable<IHolding>
    {
        void Save(string path);
        void Load(string path);

    }
}
