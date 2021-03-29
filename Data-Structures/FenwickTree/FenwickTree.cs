using System;
using System.Collections.Generic;
using System.Text;

namespace FenwickTree
{
    public class FenwickTree
    {
        private long[] tree;

        public FenwickTree(int sz)
        {
            tree = new long[sz+1];
        }

        //Input should be 1 based index
        //constrcution of Binary Indexed Tree
        public FenwickTree(long[] values)
        {
            
            if (values == null)
                throw new ArgumentNullException("Array cannot be empty");
            tree = new long[values.Length];
            values.CopyTo(tree,0);
            for (int i = 0; i < tree.Length; i++)
            {
                int j = i + LSB(i);
                if (j < tree.Length)
                    tree[j] += tree[i];
            }
        }

        private int LSB(int i)
        {
            return i & -i;
            
        }

        public long PrefixSum(int i)
        {
            long sum = 0;
            while (i != 0)
            {
                sum += tree[i];
                i = i - LSB(i);
            }
            return sum;
        }

        //Return sum [i,j]
        public long Sum(int i,int j)
        {
            if (j < i)
                throw new ArgumentException("j cannot be less than i");
            return PrefixSum(j) - PrefixSum(i-1);
        }

        //Add k to index i , 1 based
        public void Add(int i,long k)
        {
            while (i < tree.Length)
            {
                tree[i] += k;
                i += LSB(i);
            }
        }
    }
}
