using HtmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace HtmlParserTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlAttributeTest and is intended
    ///to contain all HtmlAttributeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlAttributeTest
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
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string name = "attribute";
            HtmlAttribute target = new HtmlAttribute(name);

            StringAssert.Equals(target.Name, name);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            HtmlAttribute target = new HtmlAttribute("attribute", "value");
            target.Value = string.Empty;

            Assert.IsNull(target.Value);
        }

        /// <summary>
        ///A test for Html                                                                                                            
        ///</summary>
        [TestMethod()]
        public void HtmlTest()
        {
            HtmlAttribute attribute = new HtmlAttribute("attribute");
            StringAssert.Equals(attribute.Name, attribute.Html);
            StringAssert.Equals(attribute.Html, attribute.ToString());

            attribute.Value = "'value'";
            StringAssert.Equals(attribute.Html, "attribute=value");

            attribute.Value = "value";
            StringAssert.Equals(attribute.Html, attribute.ToString());                
        }

        /// <summary>
        ///A test for HtmlAttribute Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void HtmlAttributeNameConstructorTest()
        {
            HtmlAttribute attribute = new HtmlAttribute(null);

            //positive test case covered by other tests
        }

        /// <summary>
        ///A test for HtmlAttribute Constructor
        ///</summary>
        [TestMethod()]
        public void HtmlAttributeNameValueConstructorTest()
        {
            string name = "attribute";
            string value = "value";

            HtmlAttribute attribute = new HtmlAttribute(name, value);
            StringAssert.Equals(value, attribute.Value);

            attribute = new HtmlAttribute(name, "\"" + value);
            StringAssert.Equals(value, attribute.Value);

            attribute = new HtmlAttribute(name, "\"" + value + "\'");
            StringAssert.Equals(value, attribute.Value);

            attribute = new HtmlAttribute(name, "\'" + value + "\'");
            StringAssert.Equals(value, attribute.Value);

        }
    }
}
