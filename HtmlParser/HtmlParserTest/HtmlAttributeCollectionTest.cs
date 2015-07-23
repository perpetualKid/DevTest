using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlAttributeCollectionTest and is intended
    ///to contain all HtmlAttributeCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlAttributeCollectionTest
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
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void ItemTest()
        {
            HtmlAttributeCollection target = CreateTestCollection();
            string name = "second";
            HtmlAttribute actual;
            actual = target[name];
            
            Assert.IsNotNull(actual);
            StringAssert.Equals(actual.Value, "value");

            actual = target["somethingelse"];

            Assert.IsNull(actual);

            actual = target[0];

            Assert.IsNotNull(actual);
            StringAssert.Equals(actual.Name, "first");

            actual = target[-1];
            Assert.IsNull(actual);
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest()
        {

            HtmlAttributeCollection target = CreateTestCollection();
            string name = "second";
            Assert.AreEqual(target.IndexOf(name), 1);
            Assert.AreEqual(target.IndexOf("somethingelse"), -1);
            Assert.AreEqual(target.IndexOf(null), -1);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            HtmlAttributeCollection target = CreateTestCollection();
            string name = "second";
            Assert.IsTrue(target.Contains(name));
            Assert.IsFalse(target.Contains("somethingelse"));

        }

        /// <summary>
        ///A test for HtmlAttributeCollection Constructor
        ///</summary>
        [TestMethod()]
        public void HtmlAttributeCollectionConstructorTest()
        {
            HtmlElement element = new HtmlElement("root");
            HtmlAttributeCollection target = new HtmlAttributeCollection(element);

            StringAssert.Equals(target.HtmlElement.Name, "root");
        }

        internal HtmlAttributeCollection CreateTestCollection()
        {
            HtmlElement root = new HtmlElement("root");
            HtmlAttributeCollection target = new HtmlAttributeCollection(root);

            HtmlAttribute attribute = new HtmlAttribute("first");
            target.Add(attribute);
            attribute = new HtmlAttribute("second", "value");
            target.Add(attribute);
            attribute = new HtmlAttribute("third", "\"another value\"");
            target.Add(attribute);

            return target;
        }
    }
}
