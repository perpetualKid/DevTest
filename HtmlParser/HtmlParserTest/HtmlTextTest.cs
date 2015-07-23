using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlTextTest and is intended
    ///to contain all HtmlTextTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlTextTest
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
        ///A test for Text
        ///</summary>
        [TestMethod()]
        public void TextTest()
        {
            string text = "text";
            HtmlText textNode = new HtmlText("root");
            textNode.Text = text;
            StringAssert.Equals(textNode.Text, text);
        }

        /// <summary>
        ///A test for Html
        ///</summary>
        [TestMethod()]
        public void HtmlTest()
        {
            string text = "text";
            HtmlText textNode = new HtmlText(text);
            StringAssert.Equals(textNode.Html, text);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string text = "text";
            HtmlText textNode = new HtmlText(text);
            StringAssert.Equals(textNode.ToString(), text);
        }

    }
}
