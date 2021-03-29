using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySerachTree
{
    public class BinarySearchTree<T>
    {
        //IComparer _comparer = null;
        // Tracks the number of nodes in this BST
        private int nodeCount = 0;

        // This is the root Node
        private Node root = null;

        public Node TreeRoot
        {
            get
            {
                return this.root;
            }
        }

        public void PrintTree()
        {
            PostOrderTraversal(root);
            Console.WriteLine("");
        }

        private void PostOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data + " ");

        }

        public int Size
        {
            get
            {
                return this.nodeCount;
            }
            set
            {
                this.nodeCount = value;
            }
        }

        public class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(Node Left, Node Right, T elem)
            {
                this.Data = elem;
                this.Left = Left;
                this.Right = Right;
            }
        }

        public BinarySearchTree()
        {
            //_comparer = comparer;
        }
        // Check if this BST is empty
        public bool IsEmpty()
        {
            return Size == 0;
        }

        //Method to add Element in the BST and return suucess or failure
        //Assuming Duplicates not allowed for simplicity
        public bool Add(T element)
        {
            if (Contains(element))
            {
                return false;
            }
            root = Add(root, element);
            return true;
        }
        private Node Add(Node node,T element)
        {
            if (node == null)
            {
                node = new Node(null, null, element);
            }
            else
            {
                //Tree is already existing, Add Either To Elft or Right recursively
                //if Element is less insert in Left subtree else in the Right subtree
                int res=Comparer<T>.Default.Compare(element, node.Data);

                if (res<0)
                {
                    //Put in Left Sub Tree
                    node.Left = Add(node.Left, element);
                }else 
                {
                    //Put in Right Sub Tree
                    node.Right = Add(node.Right, element);
                }
               
            }

            return node;
        }
        private bool Contains( T element)
        {
            
            return Contains(root, element);
        }
        private bool Contains(Node node, T element)
        {
            if (node == null)
                return false;
            //int cmp = _comparer.Compare(element, node.Data);
            int cmp = Comparer<T>.Default.Compare(element, node.Data);
            if (cmp<0)
            {
                return Contains(node.Left, element);
            }
            else if (cmp>0)
            {
                return Contains(node.Right, element);
            }
            else
            {
                return true;
            }
        }

        public int Height()
        {
            return Height(root);
        }

        // Recursive helper method to compute the height of the tree
        private int Height(Node node)
        {
            if (node == null) return 0;
            return Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        // Helper method to find the rightmost node (which has the largest value)
        private Node FindMax(Node node)
        {
            while (node.Right != null) node = node.Right;
            return node;
        }

        public bool Remove(T element)
        {
            if (Contains(element))
            {
                root = Remove(root, element);
                nodeCount--;
                return true;
            }
            return false;
        }

        private Node Remove(Node node,T element)
        {

            if (node == null) return null;

            int cmp = Comparer<T>.Default.Compare(element, node.Data);

            // Dig into Left subtree, the value we're looking
            // for is smaller than the current value
            if (cmp < 0)
            {
                node.Left = Remove(node.Left, element);

                // Dig into Right subtree, the value we're looking
                // for is greater than the current value
            }
            else if (cmp > 0)
            {
                node.Right = Remove(node.Right, element);

                // Found the node we wish to remove
            }
            else
            {

                // This is the case with only a Right subtree or
                // no subtree at all. In this situation just
                // swap the node we wish to remove with its Right child.
                if (node.Left == null)
                {

                    Node rightChild = node.Right;

                    node.Data = default;
                    node = null;

                    return rightChild;

                    // This is the case with only a Left subtree or
                    // no subtree at all. In this situation just
                    // swap the node we wish to remove with its Left child.
                }
                else if (node.Right == null)
                {

                    Node leftChild = node.Left;

                    node.Data = default;
                    node = null;

                    return leftChild;

                    // When removing a node from a binary tree with two links the
                    // successor of the node being removed can either be the largest
                    // value in the Left subtree or the smallest value in the Right
                    // subtree. In this implementation I have decided to find the
                    // smallest value in the Right subtree which can be found by
                    // traversing as far Left as possible in the Right subtree.
                }
                else
                {

                    // Find the leftmost node in the Right subtree
                    Node tmp = FindMin(node.Right);

                    // Swap the data
                    node.Data = tmp.Data;

                    // Go into the Right subtree and remove the leftmost node we
                    // found and swapped data with. This prevents us from having
                    // two nodes in our tree with the same value.
                    node.Right = Remove(node.Right, tmp.Data);

                    // If instead we wanted to find the largest node in the Left
                    // subtree as opposed to smallest node in the Right subtree
                    // here is what we would do:
                    // Node tmp = findMax(node.Left);
                    // node.data = tmp.data;
                    // node.Left = remove(node.Left, tmp.data);

                }
            }

            return node;

        }
        
    }
}
