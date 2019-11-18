using Algorithms;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class TreeTest
    {
        [Fact]
        public static void IsSameTreeTest()
        {
            /*
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            */

            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            var root2 = new TreeNode(1);
            root2.right = new TreeNode(2);

            Assert.False(TreeQuestions.IsSameTree(root, root2));
        }
    }
}
