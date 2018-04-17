using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void BinarySearchTreeIntegerTest()
        {
            var treeInt = new BinarySearchTree<int>();
            for (int i = 0; i < 7; i++)
            {
                treeInt.Add(i);
            }

            Assert.AreEqual(7, treeInt.Count);
            Assert.IsTrue(treeInt.Contains(3));
            Assert.IsTrue(treeInt.Remove(6));
            Assert.AreEqual(6, treeInt.Count);
        }

        [Test]
        public void BinarySearchTreeStringTest()
        {
            var treeString = new BinarySearchTree<string>();
            treeString.Add("Cat");
            treeString.Add("Dog");
            treeString.Add("Fish");
            treeString.Add("Bird");

            Assert.AreEqual(4, treeString.Count);
            Assert.IsTrue(treeString.Contains("Bird"));            
        }
    }
}
