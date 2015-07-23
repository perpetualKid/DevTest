using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlElementTest and is intended
    ///to contain all HtmlElementTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlElementTest
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
        ///A test for IsTerminated
        ///</summary>
        [TestMethod()]
        public void IsTerminatedTest()
        {
            string name = "root";

            HtmlElement target = new HtmlElement(name);
            target.IsExplicitlyTerminated = true;
            Assert.IsTrue(target.IsTerminated);

            target.IsExplicitlyTerminated = false;
            target.IsTerminated = true;

            Assert.IsTrue(target.IsTerminated);
        }

        /// <summary>
        ///A test for IsExplicitlyTerminated
        ///</summary>
        [TestMethod()]
        public void IsExplicitlyTerminatedTest()
        {
            string name = "root";
            HtmlElement target = new HtmlElement(name); 
            target.IsExplicitlyTerminated = true;
            Assert.IsTrue(target.IsExplicitlyTerminated);
        }

        /// <summary>
        ///A test for Html
        ///</summary>
        [TestMethod()]
        public void HtmlTest()
        {
            HtmlElement target = CreateElementStructure();
                 
            string actual;
            actual = target.Html;
            string expected = "<root name=\"value\"><child name=\"value\" secondname=\"secondvalue\"><anotherchild name=\"value\">text</anotherchild></root>";

            StringAssert.Equals(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            HtmlElement target = CreateElementStructure();

            StringAssert.Equals("<root name=\"value\" />", target.ToString());               ;

            target.IsExplicitlyTerminated = true;

            StringAssert.Equals("<root name=\"value\"><root />", target.ToString()); ;
        }

        /// <summary>
        ///A test for HtmlElement Constructor
        ///</summary>
        [TestMethod()]
        public void HtmlElementConstructorTest()
        {
            string name = "root";
            HtmlElement target = new HtmlElement(name);
            StringAssert.Equals(target.Name, name);
            Assert.IsNotNull(target.Nodes);
            Assert.IsNotNull(target.Attributes);
        }

        private HtmlElement CreateElementStructure()
        {
            HtmlElement root = new HtmlElement("root");
            root.Attributes.Add(new HtmlAttribute("name", "value"));
            HtmlElement child = new HtmlElement("child");
            child.Attributes.Add(new HtmlAttribute("name", "value"));
            child.Attributes.Add(new HtmlAttribute("secondname", "secondvalue"));
            child.IsTerminated = true;
            root.Nodes.Add(child);
            child = new HtmlElement("anotherchild");
            child.Attributes.Add(new HtmlAttribute("name", "value"));
            child.IsExplicitlyTerminated = true;
            root.Nodes.Add(child);

            HtmlText textNode = new HtmlText("text");
            child.Nodes.Add(textNode);
            return root;
        }
    }
}
