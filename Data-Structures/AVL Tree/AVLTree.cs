using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    public class AVLTree<T>
    {
        private class Node
        {
            //balance factor
            public int bf;

            public T value;

            //height of this node in the tree
            public int height;

            public Node left, right;

            public Node(T value)
            {
                this.value = value;
            }
        }
        private Node root;

        private int nodeCount = 0;

        public int Height()
        {
            return (root == null) ? 0 : root.height;
        }

        public int Size()
        {
            return nodeCount;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool Contains(T value)
        {
            return Contains(root, value);
        }

        private bool Contains(Node node, T value)
        {
            if (node == null) return false;
            int cmp = Comparer<T>.Default.Compare(value, node.value);
            if (cmp < 0)
                return Contains(node.left, value);

            if (cmp > 0)
                return Contains(node.right,value);

            return true;
        }

        public bool Insert(T value)
        {
            if (value == null) return false;
            if (!Contains(root, value))
            {
                root = Insert(root, value);
                nodeCount++;
                return true;
            }
            return false;
        }

        private Node Insert(Node node, T value)
        {
            //Basse case
            if (node == null) return new Node(value);

            int cmp = Comparer<T>.Default.Compare(value, node.value);
            if (cmp < 0)
                node.left = Insert(node.left, value);
            if (cmp > 0)
                node.right = Insert(node.right, value);

            Update(node);

            return Balance(node);
        }

        private void Update(Node node)
        {
            int leftNodeHeight = (node.left == null) ? -1 : node.left.height;
            int rightNodeHeight = (node.right == null) ? -1 : node.right.height;
            node.height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);
            node.bf = rightNodeHeight - leftNodeHeight;
        }

        private Node Balance(Node node)
        {
            //left Heavy Tree
            if (node.bf == -2)
            {
                //Left left Case
                if (node.left.bf <= 0)
                {
                    return LeftLeftCase(node);
                }
                else
                {
                    //Left Right Case
                    return LeftRightCase(node);
                }
            }//Right Heavy Tree
            else if(node.bf==2)
            {
                if (node.right.bf >= 0)
                {
                    return RightRightCase(node);
                }
                else
                {
                    return RightLeftCase(node);
                }
            }
            //else it is balanced
            return node;
        }
        private Node LeftLeftCase(Node node)
        {
            return RightRotation(node);
        }  

        private Node LeftRightCase(Node node)
        {
            node.left = LeftRotation(node.left);
            return LeftLeftCase(node);
        }

        private Node RightRightCase(Node node)
        {
            return LeftRotation(node);
        }
        private Node RightLeftCase(Node node)
        {
            node.right = RightRotation(node.right);
            return RightRightCase(node);
        }

        private Node RightRotation(Node node)
        {
            Node newParent = node.left;
            node.left=newParent.right;
            newParent.right = node;
            Update(node); //oder is importamt for updating height first child and then the parent
            Update(newParent);
            return newParent;
        }

        private Node LeftRotation(Node node)
        {
            Node newParent = node.right;
            node.right = newParent.left;
            newParent.left = node;
            Update(node);//oder is importamt for updating height first child and then the parent
            Update(newParent);
            return newParent;
        }

        public bool Remove(T value)
        {
            if (value == null) throw new ArgumentNullException("value to remove cannot be null");
            if (Contains(root, value))
            {
                root = Remove(root, value);
                nodeCount--;
                return true;
            }
            return false;
        }

        private Node Remove(Node node, T value)
        {
            if (node == null) return null;

            int cmp = Comparer<T>.Default.Compare(value, node.value);

            if (cmp < 0)
            {
                //LEft tree
                node.left = Remove(node.left, value);
            }
            else if (cmp > 0)
            {
                //right tree
                node.left = Remove(node.right, value);
            }
            else
            {
                //founf the value to remove
                if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right==null)
                {
                    return node.left;
                }
                else
                {
                    //has both left and right sub tree
                    //so the successor can be either the smallest value from the right subtree
                    //or the largest value from the left sub tree

                    if (node.left.height > node.right.height)
                    {
                        //Node travNode = node.right;
                        //while (travNode.left != null)
                        //{
                        //    travNode = travNode.left;
                        //}
                        T valueToSwap = FindMax(node.left);
                        node.value = valueToSwap;
                        node.left = Remove(node.left, valueToSwap);
                    }
                    else
                    {
                        T valueToSwap = FindMin(node.left);
                        node.value = valueToSwap;
                        node.right = Remove(node.right, valueToSwap);
                    }
                    


                }
                   
            }
            Update(node);

            return Balance(node);
        }

        private T FindMin(Node node)
        {
            while (node.left != null)
                node = node.left;
            return node.value;
        }

        private T FindMax(Node node)
        {
            while (node.right != null)
                node = node.right;
            return node.value;
        }
    }
}
