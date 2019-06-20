using System;
using System.Diagnostics;
using NUnit.Framework;
using Project.Algorithms.Models;

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

    }
}