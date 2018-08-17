using System;
using System.Collections.Generic;
using System.Text;

namespace BIAG.Common.Helpers
{
    public class ArraySlicer<T>
    {
        int _position;
        int _blocksize;
        int _itemcount;
        T[] _array;

        public ArraySlicer(T[] array, int blocksize) : this(array, blocksize, 0) { }

        public ArraySlicer(T[] array, int blocksize, int itemcount)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            _array = array;

            if (blocksize <= 0)
                _blocksize = int.MaxValue;
            else
                _blocksize = blocksize;

            if (itemcount <= 0 || itemcount > array.Length)
                _itemcount = array.Length;
            else
                _itemcount = itemcount;
        }

        public bool HasMoreItems
        {
            get { return _position < _itemcount; }
        }

        public T[] GetNextBlock()
        {
            //if (!HasMoreItems)
            //    return null;    

            T[] returnArray = new T[Math.Min(_itemcount - _position, _blocksize)];
            for (int i = 0; i < returnArray.Length; i++, _position++)
            {
                returnArray[i] = _array[_position];
            }
            return returnArray;
        }
    }
}
