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

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            string PrintInOrder(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                {
                    return "";
                }

                if (node.left == null && node.right != null)
                {
                    sb.Append("null");
                }

                PrintInOrder(node.left, sb);
                sb.Append(node.val);

                if (node.right == null && node.left != null)
                {
                    sb.Append("null");
                }

                PrintInOrder(node.right, sb);

                return sb.ToString();
            }

            return PrintInOrder(p, new StringBuilder()) == PrintInOrder(q, new StringBuilder());
        }
    }
}
