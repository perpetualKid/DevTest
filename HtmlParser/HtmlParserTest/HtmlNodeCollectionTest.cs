using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlNodeCollectionTest and is intended
    ///to contain all HtmlNodeCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlNodeCollectionTest
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
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemByNameTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            target.Add(new HtmlElement("first"));
            target.Add(new HtmlElement("second"));
            target.Add(new HtmlElement("second"));

            Assert.IsNotNull(target["second"]);

            Assert.IsNull(target["anyname"]);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void ItemByIndexTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            target.Add(new HtmlElement("first"));
            target.Add(new HtmlElement("second"));
            target.Add(new HtmlElement("third"));

            Assert.AreEqual(target[1], target["second"]);

            target[2] = new HtmlElement("another");
            target[0] = null;

            StringAssert.Contains(target[2].ToString(), "another");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void InsertTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            HtmlElement child = new HtmlElement("child");
            target.Add(child);

            child = new HtmlElement("second");
            target.Insert(0, child);
            Assert.AreEqual(root, child.Parent);
            Assert.AreEqual(target.IndexOf(child), 0);

            target.Insert(0, null);
        }

        /// <summary>
        ///A test for GetByName
        ///</summary>
        [TestMethod()]
        public void GetByNameTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            target.Add(new HtmlElement("first"));
            target.Add(new HtmlElement("second"));
            target.Add(new HtmlElement("second"));

            Assert.AreEqual(target.GetByName("second").Count, 2);

            ((HtmlElement)target[0]).Nodes.Add(new HtmlElement("second"));

            Assert.AreEqual(target.GetByName("second", false).Count, 2);

            Assert.AreEqual(target.GetByName("second").Count, 3);
        }

        /// <summary>
        ///A test for FindByAttributeNameValue
        ///</summary>
        [TestMethod()]
        public void FindByAttributeNameValueTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            target.Add(new HtmlElement("first"));
            target.Add(new HtmlElement("second"));
            target.Add(new HtmlElement("third"));
            ((HtmlElement)target[1]).Nodes.Add(new HtmlElement("secondchild"));

            ((HtmlElement)target[1]).Attributes.Add(new HtmlAttribute("firstattribute", "firstvalue"));
            ((HtmlElement)target[1]).Attributes.Add(new HtmlAttribute("secondattribute", "firstvalue"));
            ((HtmlElement)target[2]).Attributes.Add(new HtmlAttribute("firstattribute", "secondvalue"));
            
            ((HtmlElement)((HtmlElement)target[1]).Nodes[0]).Attributes.Add(new HtmlAttribute("secondattribute", "secondvalue"));
            ((HtmlElement)((HtmlElement)target[1]).Nodes[0]).Attributes.Add(new HtmlAttribute("firstattribute", "anothervalue"));

            Assert.AreEqual(target.FindByAttributeNameValue("firstattribute", "secondvalue", false).Count, 1);

            Assert.AreEqual(target.FindByAttributeNameValue("firstattribute", "anothervalue").Count, 1);
        }

        /// <summary>
        ///A test for FindByAttributeName
        ///</summary>
        [TestMethod()]
        public void FindByAttributeNameTest()
        {

            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            target.Add(new HtmlElement("first"));
            target.Add(new HtmlElement("second"));
            target.Add(new HtmlElement("third"));
            ((HtmlElement)target[0]).Nodes.Add(new HtmlElement("secondchild"));

            ((HtmlElement)target[1]).Attributes.Add(new HtmlAttribute("firstattribute"));
            ((HtmlElement)target[1]).Attributes.Add(new HtmlAttribute("secondattribute"));
            ((HtmlElement)target[2]).Attributes.Add(new HtmlAttribute("firstattribute"));

            Assert.AreEqual(target.FindByAttributeName("firstattribute").Count, 2);

            ((HtmlElement)((HtmlElement)target[0]).Nodes[0]).Attributes.Add(new HtmlAttribute("firstattribute"));
            Assert.AreEqual(target.FindByAttributeName("firstattribute", false).Count, 2);
            Assert.AreEqual(target.FindByAttributeName("firstattribute", true).Count, 3);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void AddTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            HtmlElement child = new HtmlElement("child");
            int index = target.Add(child);
            Assert.AreEqual(root, child.Parent);
            Assert.AreEqual(index, 0);

            target.Add(null);
        }

        /// <summary>
        ///A test for HtmlNodeCollection Constructor
        ///</summary>
        [TestMethod()]
        public void HtmlNodeCollectionConstructorTest()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlNodeCollection target = new HtmlNodeCollection(root);
            HtmlElement child = new HtmlElement("child");
            target.Add(child);
            Assert.AreEqual(root, child.Parent);
        }
    }
}
