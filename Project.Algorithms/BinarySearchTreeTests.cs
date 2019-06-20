using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Project.Algorithms
{
    public class BinarySearchTreeTests
    {

        [Test]
        public void Node5ShouldBeLeftSubtreeofNode10()
        {

            Node root = new Node();
            Node node5 = new Node();

            root.Value = 10;
            node5.Value = 5;

            root.Left = node5;

            Assert.That(root.Left.Value, Is.EqualTo(5));
        }

        [Test]
        public void SearchFor5ShouldReturnNode5()
        {
            Node root = new Node();
            Node node5 = new Node();
            root.Value = 10;
            node5.Value = 5;
            root.Left = node5;

            var actualNode = TreeSearch(5, root);
            Assert.That(actualNode.Value, Is.EqualTo(5));
        }

        [Test]
        public void SearchFor7ShouldReturnNull()
        {
            Node root = new Node();
            Node node5 = new Node();
            root.Value = 10;
            node5.Value = 5;
            root.Left = node5;

            var actualNode = TreeSearch(7, root);
            Assert.That(actualNode, Is.Null);
        }

        private Node TreeSearch(int value, Node tree)
        {
            if (tree == null)
            {
                return null;
            }
            else if (value == tree.Value)
            {
                return tree;
            }
            else if (value < tree.Value)
            {
                return TreeSearch(value, tree.Left);
            }

            else if (value > tree.Value)
            {
                return TreeSearch(value, tree.Right);
            }

            return null;
        }

        private void FindNodeInTree()
        {
            Node root = null;
            Tree bst = new Tree();
            int SIZE = 1;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

            Random random = new Random();

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                a[i] = random.Next(10000);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, a[i]);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.traverse(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();

            Console.ReadKey();


        }
    }
}