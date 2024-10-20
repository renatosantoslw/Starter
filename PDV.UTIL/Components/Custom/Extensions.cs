using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.UTIL.Components.Custom
{
    public static class Extensions
    {
        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

    }
}
