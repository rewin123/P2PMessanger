using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P2PMessanger
{
    /// <summary>
    /// Хранилище данных в папке
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class JHolder<T> : IList<T> where T : IHolding
    {
        const string format = ".pat";
        string folder;
        public delegate T Creator();

        int count = 0;
        Creator creator;

        public JHolder(Creator creator, string folder)
        {
            this.creator = creator;
            this.folder = folder;
        }

        string GetPath(int index)
        {
            return folder + "/" + index + format;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                var val = creator();
                val.Load(GetPath(index));
                return val;
            }
            set
            {
                value.Save(GetPath(index));
            }
        }

        /// <summary>
        /// Сдвигает файлы на 1
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dpos"></param>
        void ShiftRight(int start)
        {
            for(int i = count - 1;i >= start;i--)
            {
                File.Move(GetPath(i), GetPath(i + 1));
            }
        }

        /// <summary>
        /// Сдвигаем файлы на -1
        /// </summary>
        /// <param name="start"></param>
        void ShiftLeft(int start)
        {
            for (int i = start; i < count; i++)
            {
                File.Move(GetPath(i), GetPath(i - 1));
            }
        }

        public int IndexOf(T item)
        {
            for(int i = 0;i < count;i++)
            {
                if (item.Equals(this[i]))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            count++;
            this[count - 1] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
                File.Delete(GetPath(i));
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
                if (item.Equals(this[i]))
                    return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
