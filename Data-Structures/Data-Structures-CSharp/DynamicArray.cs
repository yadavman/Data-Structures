using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_CSharp
    {//Similarly we can implement AddRange Method
     //We can have options for complex objects etc
    public class DynamicArray<T> 
    {
        /// <summary>
        /// Internal Static Array
        /// </summary>
        private T[] _arr;
        /// <summary>
        /// Length of the Array Defined by the user
        /// </summary>
        private int _len = 0;
        /// <summary>
        ///  Actual Array Size/or the Capacity
        /// </summary>
        private int _capacity = 0;

        /// <summary>
        /// Intialize Dynamic Array of Size 16
        /// </summary>
        public DynamicArray()
        {
            _arr= new T[16];
        }

        /// <summary>
        /// Intialize Dynamic Array with the capcity defined by the user
        /// </summary>
        public DynamicArray(int capacity)
        {
            if (capacity < 0) throw new ArgumentException("Illegal Capacity: " + capacity);
            this._capacity = capacity;
            _arr = new T[capacity];
        }

        /// <summary>
        /// Returns the size of the dynamic array
        /// </summary>
        public int Size()
        {
            return _len;
        }

        /// <summary>
        /// Checks whether dynakic array is empty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        /// <summary>
        /// Get the value at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>value of specified type</returns>
        public T Get(int index)
        {
            if (index >= _len) throw new IndexOutOfRangeException();
            return _arr[index];
        }

        /// <summary>
        /// set the value at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="elem"></param>
        public void Set(int index, T elem)
        {
            if (index >= _len) throw new IndexOutOfRangeException();
            _arr[index] = elem;
        }
        /// <summary>
        /// Clear the dynamic array
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _len; i++)
                _arr[i] = default(T);
            _len = 0;
        }

        /// <summary>
        /// Add item at the end of the array
        /// </summary>
        /// <param name="elem"></param>
        public void Add(T elem)
        {

            // Time to resize!
            if (_len + 1 >= _capacity)
            {
                if (_capacity == 0) _capacity = 1;
                else _capacity *= 2; // double the size
                T[] new_arr = new T[_capacity];
                for (int i = 0; i < _len; i++) 
                    new_arr[i] = _arr[i];
                _arr = new_arr; // arr has extra nulls padded
            }

            _arr[_len++] = elem;
        }

        /// <summary>
        /// AddRange method to add multiple values at a time
        /// </summary>
        /// <param name="values"></param>
        public void AddRange(params T[] values)
        { //take the size of the parms array and decide upfront the capcity needed and then add the values
            //Left for the users to implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes an element at the specified index in this array
        /// </summary>
        /// <param name="rm_index"></param>
        /// <returns></returns>
        public T RemoveAt(int rm_index)
        {
            if (rm_index >= _len || rm_index < 0) throw new IndexOutOfRangeException();
            T data = _arr[rm_index];
            T[] new_arr = new T[_len - 1];
            for (int i = 0, j = 0; i < _len; i++, j++)
                if (i == rm_index) j--; // Skip over rm_index by fixing j temporarily
                else new_arr[j] = _arr[i];
            _arr = new_arr;
            _capacity = --_len;
            return data;
        }

        /// <summary>
        /// Remove the value from the array
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Finds the index of the specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the index of the value esle -1 </returns>
        public int IndexOf(T value)
        {
            for (int i = 0; i < _len; i++)
            {
                if (value == null)
                {
                    if (_arr[i] == null) return i;
                }
                else
                {
                    if (value.Equals(_arr[i])) return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checks whether the specified value exists in the array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }


        public override string ToString()
        {
            if (_len == 0) return "[]";
            else
            {
                StringBuilder sb = new StringBuilder(_len).Append("[");
                for (int i = 0; i < _len - 1; i++) 
                    sb.Append(_arr[i] + ", ");
                return sb.Append(_arr[_len - 1] + "]").ToString();
            }
        }
    }
}
