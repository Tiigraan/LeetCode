namespace LeetCode.Tasks;

public class T1123_LowestCommonAncestorOfDeepestLeaves
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        var firstLayer = new List<TreeNode>();
        var secondLayer = new List<TreeNode>();
        var trace = new Dictionary<TreeNode, TreeNode>();
        firstLayer.Add(root);

        while (firstLayer.Count > 0)
        {
            secondLayer.Clear();
            foreach (var node in firstLayer)
            {
                if (node.left is not null)
                {
                    trace.Add(node.left, node);
                    secondLayer.Add(node.left);
                }

                if (node.right is not null)
                {
                    trace.Add(node.right, node);
                    secondLayer.Add(node.right);
                }
            }

            (firstLayer, secondLayer) = (secondLayer, firstLayer);
        }

        while (secondLayer.Count > 1)
        {
            var set = new HashSet<int>();
            foreach (var node in secondLayer)
            {
                var parent = trace[node];
                if (set.Contains(parent.val))
                    continue;

                firstLayer.Add(parent);
                set.Add(parent.val);
            }

            (firstLayer, secondLayer) = (secondLayer, firstLayer);
            firstLayer.Clear();
        }

        return secondLayer.First();
    }
}