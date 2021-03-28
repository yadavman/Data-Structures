using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraversals
{
    public class BinaryTreeTraversal<T>
    {
        private Node<T> root; //Tree Root Element
        public BinaryTreeTraversal(Node<T> root)
        {
            this.root = root;
        }

        public void TraverseTree(TreeTravesralMode mode)
        {
            switch (mode)
            {
                case TreeTravesralMode.PreOrder:
                    PreOrderTraversal(root);
                    break;
                case TreeTravesralMode.PostOrder:
                    PostOrderTraversal(root);
                    break;
                case TreeTravesralMode.InOrder:
                    InOrderTraversal(root);
                    break;
                case TreeTravesralMode.LevelOrder:
                    LevelOrderTraversal(root);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Mode for Tree Traversal");
            }
        }

        private void PreOrderTraversal(Node<T> node)
        {
            if (node==null)
            {
                return;
            }
            Console.Write(node.Data);
            Console.Write(" ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);

        }
        private void PostOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data);
            Console.Write(" ");

        }
        private void InOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left);
            Console.Write(node.Data);
            Console.Write(" ");
            InOrderTraversal(node.Right);

        }

        private void LevelOrderTraversal(Node<T> node)
        {
            //Queue Based
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);

            while (queue.Count>0)
            {
                Node<T> currNode = queue.Dequeue();

                Console.Write(currNode.Data + " ");
                if (currNode.Left!=null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);

            }
        }
    }

    public enum TreeTravesralMode
    {
        PreOrder,
        PostOrder,
        InOrder,
        LevelOrder
    }
}
