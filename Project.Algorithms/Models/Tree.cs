namespace Project.Algorithms.Models
{
    internal class Tree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.Value = v;
            }
            else if (v < root.Value)
            {
                root.Left = insert(root.Left, v);
            }
            else
            {
                root.Right = insert(root.Right, v);
            }

            return root;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.Left);
            traverse(root.Right);
        }
    }
}