using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraversals
{
    public class BinaryTreeTraversal_Iterative<T>
    {
        private Node<T> root; //Tree Root Element
        public BinaryTreeTraversal_Iterative(Node<T> root)
        {
            this.root = root;
        }

        public IEnumerable<Node<T>> TraverseTree(TreeTravesralMode mode)
        {
            switch (mode)
            {
                case TreeTravesralMode.PreOrder:
                    return PreOrderTraversal(root);
                case TreeTravesralMode.PostOrder:
                    return PostOrderTraversal(root);
                case TreeTravesralMode.InOrder:
                    return InOrderTraversal(root);
                case TreeTravesralMode.LevelOrder:
                    //return LevelOrderTraversal(root);
                default:
                    throw new InvalidOperationException("Invalid Mode for Tree Traversal");
            }
        }

        private IEnumerable<Node<T>> PreOrderTraversal(Node<T> node)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            if (node == null)
                throw new ArgumentNullException("Node cannot be null");

            stack.Push(node); //Push the First Node in this case the root node

            while (stack.Count > 0)
            {
                Node<T> curNode = stack.Pop();
                yield return curNode;
                
                if(curNode.Right!=null)
                    stack.Push(curNode.Right);
                if (curNode.Left != null)
                    stack.Push(curNode.Left);
            }

        }
        private IEnumerable<Node<T>> PostOrderTraversal(Node<T> node)
        {
            List<T> processedList = new List<T>(); // Can do with List as Well
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Stack<Node<T>> stackOdered = new Stack<Node<T>>();
            if (node == null)
                throw new ArgumentNullException("Node cannot be null");

            stack.Push(node); //Push the First Node in this case the root node

            while (node!= null && stack.Count>0)
            {
                Node<T> curNode= stack.Pop();
                stackOdered.Push(curNode);

                if (curNode.Left != null)
                    stack.Push(curNode.Left);
                if (curNode.Right != null)
                    stack.Push(curNode.Right);

            }

            while (stackOdered.Count > 0)
            {
                yield return stackOdered.Pop();
            }
           
        }
        private IEnumerable<Node<T>> InOrderTraversal(Node<T> node)
        {
            Node<T> trav = node;
            if (trav == null)
                throw new ArgumentNullException("node value cannot be null");

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(trav);
            while (stack.Count > 0)
            {
                //go the left most
                while (trav.Left != null)
                {
                    stack.Push(trav.Left);
                    trav = trav.Left;
                }
                Node<T> curNode = stack.Pop();

                if (curNode.Right != null)
                {
                    stack.Push(curNode.Right);
                    trav = curNode.Right;
                } 

                yield return curNode;
                 

            }

        }

        //private IEnumerable<Node<T>> LevelOrderTraversal(Node<T> node)
        //{
        //    //Queue Based
        //    Queue<Node<T>> queue = new Queue<Node<T>>();
        //    queue.Enqueue(node);

        //    while (queue.Count > 0)
        //    {
        //        Node<T> currNode = queue.Dequeue();

        //        Console.Write(currNode.Data + " ");
        //        if (currNode.Left != null)
        //            queue.Enqueue(currNode.Left);
        //        if (currNode.Right != null)
        //            queue.Enqueue(currNode.Right);

        //    }
        //}
    }
}
