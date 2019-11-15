using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class TreeNode
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
  }

    public static class TreeQuestions
    {
        //https://leetcode.com/problems/binary-tree-inorder-traversal/
        public static IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            InorderTraversalImpl(root, result);
            return result;
        }

        public static void InorderTraversalImpl(TreeNode node, List<int> result)
        {
            if (node.left != null)
            {
                InorderTraversalImpl(node.left, result);
            }
            
            if (node.right != null)
            {
                InorderTraversalImpl(node.right, result);
            }

            result.Add(node.val);
        }
    }
}
