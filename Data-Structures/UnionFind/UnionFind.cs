using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    public class UnionFind
    {
        
        //no of elements
        private int _size;

        public int Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }

        //size of each component
        private int[] sz;

        //id[i] points to the parent of the node aand if id[i] = i then its root node
        private int[] id;

        private int numComponents;

        public int ComponentsCount
        {
            get
            {
                return this.numComponents;
            }
            set
            {
                this.numComponents = value;
            }
        }

        public UnionFind(int size)
        {
            if (size<=0)
            {
                throw new ArgumentException("size cannot be zero or negative");
            }
            _size = numComponents = size;
            sz = new int[size];
            id = new int[size];

            for (int i = 0; i < size; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        public int Find(int p)
        {
            int root = p;
            while (root != id[root])
            {
                root = id[root];
            }
            //path compression for constant time find
            while (p!=root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }

            return root;
        }

        public bool IsConnected(int p,int q)
        {
            return Find(p) == Find(q);
        }

        public int ComponentSize(int p)
        {
            return sz[Find(p)];
        }

        public void Merge(int p, int q)
        {
            int root1 = Find(p);
            int root2 = Find(q);

            if (root1 == root2)
                return;
            //merge 2 compoenents 
            if (sz[root1]<sz[root2])
            {
                sz[root2] += sz[root1];
                id[root1] = root2;
            }
            else
            {
                sz[root1] += sz[root2];
                id[root2] = root1;
            }
            //compoenet size wil decrease by 1
            numComponents--;
        }
        
        
    }
}
