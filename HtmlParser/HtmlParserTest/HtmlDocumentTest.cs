using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlDocumentTest and is intended
    ///to contain all HtmlDocumentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlDocumentTest
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
        ///A test for Nodes
        ///</summary>
        [TestMethod()]
        public void NodesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            HtmlDocument_Accessor target = new HtmlDocument_Accessor(param0); // TODO: Initialize to an appropriate value
            HtmlNodeCollection actual;
            actual = target.Nodes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Html
        ///</summary>
        [TestMethod()]
        public void HtmlTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            HtmlDocument_Accessor target = new HtmlDocument_Accessor(param0); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Html;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest1()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            HtmlDocument expected = null; // TODO: Initialize to an appropriate value
            HtmlDocument actual;
            actual = HtmlDocument.Create(stream);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            StreamReader reader = null; // TODO: Initialize to an appropriate value
            HtmlDocument expected = null; // TODO: Initialize to an appropriate value
            HtmlDocument actual;
            actual = HtmlDocument.Create(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlDocument Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HtmlParser.dll")]
        public void HtmlDocumentConstructorTest1()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            HtmlDocument_Accessor target = new HtmlDocument_Accessor(stream);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for HtmlDocument Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HtmlParser.dll")]
        public void HtmlDocumentConstructorTest()
        {
            StreamReader reader = new StreamReader(string.Empty);
            HtmlDocument_Accessor target = new HtmlDocument_Accessor(reader);
        }
    }
}
