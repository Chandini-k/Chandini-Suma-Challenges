using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNodesAlgo
{
    class Solution
    {

        /*
         * Complete the swapNodes function below.
         */
        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            int N = Convert.ToInt32(Console.ReadLine());

            var root = new TreeNode(1, 1);

            for (var i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();

                var treeNode = root.GetNodeWithIndex(i + 1);

                int left = Convert.ToInt32(line[0]);
                if (left != -1)
                {
                    var leftTree = new TreeNode(left, treeNode.Depth + 1);
                    treeNode.LeftTree = leftTree;
                }
                int right = Convert.ToInt32(line[1]);
                if (right != -1)
                {
                    var rightTree = new TreeNode(right, treeNode.Depth + 1);
                    treeNode.RightTree = rightTree;
                }
            }

            int T = Convert.ToInt32(Console.ReadLine());
            var swapNumbers = new int[T];
            for (var i = 0; i < T; i++)
            {
                swapNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (var n in swapNumbers)
            {
                root.SwapTreesAtHeight(n);
                root.PrintInorderTraversal();
                Console.Write("\n");
            }
            Console.ReadLine();
        }
        public class TreeNode
        {
            public int Number { get; set; }
            public int Depth { get; set; }
            public TreeNode LeftTree { get; set; }
            public TreeNode RightTree { get; set; }

            public TreeNode(int n, int d)
            {
                Number = n;
                Depth = d;
            }

            public void SwapTreesAtHeight(int h)
            {
                if (Depth % h == 0)
                {
                    var temp = LeftTree;
                    LeftTree = RightTree;
                    RightTree = temp;
                }
                if (LeftTree != null)
                    LeftTree.SwapTreesAtHeight(h);
                if (RightTree != null)
                    RightTree.SwapTreesAtHeight(h);
            }

            public void PrintInorderTraversal()
            {
                if (LeftTree != null)
                    LeftTree.PrintInorderTraversal();
                Console.Write(Number + " ");
                if (RightTree != null)
                    RightTree.PrintInorderTraversal();
            }

            public TreeNode GetNodeWithIndex(int index)
            {
                if (Number.Equals(index))
                    return this;

                if (LeftTree != null)
                {
                    TreeNode leftIndex = LeftTree.GetNodeWithIndex(index);
                    if (leftIndex != null)
                        return leftIndex;
                }

                if (RightTree != null)
                {
                    TreeNode rightIndex = RightTree.GetNodeWithIndex(index);
                    if (rightIndex != null)
                        return rightIndex;
                }

                return null;
            }
        }
    }
}
