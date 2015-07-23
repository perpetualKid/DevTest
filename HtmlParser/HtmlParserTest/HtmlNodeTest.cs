using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlNodeTest and is intended
    ///to contain all HtmlNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlNodeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetCommonAncestor
        ///</summary>
        [TestMethod()]
        public void GetCommonAncestorTest()
        {
            
            HtmlNode target = CreateTreeStructure();
            HtmlNode child1 = target.FirstChild.FirstChild;
            HtmlNode child2 = target.LastChild.LastChild;

            HtmlNode actual = child1.GetCommonAncestor(child2);

            Assert.AreEqual(target, actual);

            HtmlElement element = new HtmlElement("NoCommonAncestor");

            actual = child2.GetCommonAncestor(element);
            Assert.IsNull(actual);
        }

        /// <summary>
        ///A test for IsAncestorOf
        ///</summary>
        [TestMethod()]
        public void IsAncestorOfTest()
        {
            HtmlNode target = CreateTreeStructure(); 
            
            Assert.IsTrue(target.IsAncestorOf(target.FirstChild.FirstChild));

            Assert.IsFalse(target.FirstChild.IsAncestorOf(target.LastChild));

            Assert.IsFalse(target.IsAncestorOf(null));
        }

        /// <summary>
        ///A test for IsDescendantOf
        ///</summary>
        [TestMethod()]
        public void IsDescendentOfTest()
        {

            HtmlElement element = CreateTreeStructure() as HtmlElement;

            HtmlNode child = element.FirstChild.LastChild;

            Assert.IsTrue(child.IsDescendantOf(element));

            HtmlNode secondChild = element.LastChild;

            Assert.IsFalse(child.IsDescendantOf(secondChild));
        }

        /// <summary>
        ///A test for IsElement
        ///</summary>
        [TestMethod()]
        public void IsElementTest()
        {
            HtmlNode target = new HtmlText("Test");
            Assert.IsFalse(target.IsElement());

            target = new HtmlElement("Test");
            Assert.IsTrue(target.IsElement());
        }

        /// <summary>
        ///A test for IsText
        ///</summary>
        [TestMethod()]
        public void IsTextTest()
        {
            HtmlNode target = new HtmlText("Test");             
            Assert.IsTrue(target.IsText());

            target = new HtmlElement("Test");
            Assert.IsFalse(target.IsText());
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            HtmlElement node = CreateTreeStructure() as HtmlElement;

            node.FirstChild.Remove();

            Assert.IsTrue(node.Nodes.Count == 1);
        }

        /// <summary>
        ///A test for SetParent
        ///</summary>
        [TestMethod()]
        public void SetParentTest()
        {
            HtmlNode node = new HtmlText("Test");
            HtmlElement parent = new HtmlElement("Parent");
            node.SetParent(parent);
            Assert.AreEqual(parent, node.Parent);
        }

        /// <summary>
        ///A test for FirstChild
        ///</summary>
        [TestMethod()]
        public void FirstChildTest()
        {
            HtmlElement target = CreateTreeStructure() as HtmlElement;
            
            Assert.IsTrue(target.FirstChild == target.Nodes[0]);

            Assert.IsNull(target.FirstChild.FirstChild.FirstChild);
        }

        /// <summary>
        ///A test for Html
        ///</summary>
        [TestMethod()]
        public void HtmlTest()
        {
            HtmlNode target = new HtmlText("Test"); 
            string actual = "Test";
            Assert.AreEqual(target.Html, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            HtmlNode target = CreateTreeStructure();

            Assert.IsFalse(target.Index >= 0);
        }

        /// <summary>
        ///A test for LastChild
        ///</summary>
        [TestMethod()]
        public void LastChildTest()
        {
            HtmlElement target = CreateTreeStructure() as HtmlElement;

            Assert.IsTrue(target.LastChild == target.Nodes[1]);

            Assert.IsNull(target.LastChild.LastChild.LastChild);
        }

        /// <summary>
        ///A test for Next
        ///</summary>
        [TestMethod()]
        public void NextTest()
        {
            HtmlElement target = CreateTreeStructure() as HtmlElement;
            HtmlNode node = target.FirstChild;

            Assert.AreEqual(node.Next, target.LastChild);

            Assert.IsNull(target.LastChild.Next);
        }

        /// <summary>
        ///A test for Parent
        ///</summary>
        [TestMethod()]
        public void ParentTest()
        {
            HtmlNode target = CreateTreeStructure();
            HtmlNode child = target.FirstChild;

            Assert.IsTrue(child.Parent == target);
        }

        internal virtual HtmlNode CreateTreeStructure()
        {

            // |-Root
            //   |-FirstChild
            //   |  |-FirstFirstChild
            //   |  |-FirstSecondChild
            //   |-SecondChild
            //      |-SecondFirstChild
            //      |-SecondSecondChild
            // 
            HtmlElement target = new HtmlElement("Root");
            HtmlElement child = new HtmlElement("FirstChild");
            child.Nodes.Add(new HtmlElement("FirstFirstChild"));
            child.Nodes.Add(new HtmlElement("FirstSecondChild"));
            target.Nodes.Add(child);
            child = new HtmlElement("SecondChild");
            child.Nodes.Add(new HtmlElement("SecondFirstChild"));
            child.Nodes.Add(new HtmlElement("SecondSecondChild"));
            target.Nodes.Add(child);
            return target;
        }

        /// <summary>
        ///A test for Previous
        ///</summary>
        [TestMethod()]
        public void PreviousTest()
        {
            HtmlElement target = CreateTreeStructure() as HtmlElement;
            HtmlNode node = target.LastChild;

            Assert.AreEqual(node.Previous, target.FirstChild);

            Assert.IsNull(target.FirstChild.Previous);
        }
    }
}
