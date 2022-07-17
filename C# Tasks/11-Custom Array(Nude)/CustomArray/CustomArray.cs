using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First 
        { 
            get=> throw new NotImplementedException();
            private set=>throw new NotImplementedException() ;
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last 
        { 
            get=> throw new NotImplementedException(); 
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length 
        {   
            get=>throw new NotImplementedException(); 
            private set=> throw new NotImplementedException();
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        { 
            get=>throw new NotImplementedException(); 
        }


        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>         
        public CustomArray(int first, int length)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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
