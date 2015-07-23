using System;
using System.Globalization;
using System.Web;

namespace HtmlParser
{
	/// <summary>
	/// The HtmlAttribute object represents a named attributeValue associated with an HtmlElement.
	/// </summary>
	public class HtmlAttribute
	{
		private string attributeName;
		private string attributeValue;
        private bool singleQuotes;

        #region .ctor
        internal HtmlAttribute(string name)
        {
            if (null == name || name.Length == 0)
                throw new ArgumentException("Attribute attributeName can not be null or empty");
            this.attributeName = name;
        }

        internal HtmlAttribute(string name, string value)
            : this(name)
        {
            this.Value = value;
        }

        #endregion

        #region public properties
        /// <summary>
		/// The attributeName of the attribute. e.g. WIDTH
		/// </summary>
		public string Name
		{
			get	{ return this.attributeName; }
		}

		/// <summary>
		/// The attributeValue of the attribute. e.g. 100%
		/// </summary>
		public string Value
		{
			get { return this.attributeValue; }
			set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.attributeValue = null;
                }
                else
                {
                    if (value.StartsWith("'", StringComparison.OrdinalIgnoreCase) 
                        && value.EndsWith("'", StringComparison.OrdinalIgnoreCase))
                    {
                        this.singleQuotes = true;
                        this.attributeValue = value.Trim('\'');
                    }
                    else
                    {
                        this.singleQuotes = false;
                        this.attributeValue = value.Trim('"');
                    }
                }
            }
        }
        #endregion

		public override string ToString()
		{
			return (null == this.attributeValue) ? this.attributeName : 
                string.Format(CultureInfo.InvariantCulture, "{0}=\"{1}\"", this.attributeName, this.attributeValue);
		}

		public string Html
		{
			get
			{
                return (null == this.attributeValue) ? this.attributeName :
                    string.Format(CultureInfo.InvariantCulture, "{0}={2}{1}{2}", this.attributeName, HttpUtility.HtmlEncode(this.attributeValue), this.singleQuotes ? "'" : "\"");
            }
		}
	}

}
