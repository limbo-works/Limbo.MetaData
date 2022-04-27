using Newtonsoft.Json;

namespace Limbo.MetaData.Models.Elements {

    /// <summary>
    /// Represents a <c>meta</c> HTML element.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/meta</cref>
    /// </see>
    public class Meta : Element {

        #region Properties

        /// <summary>
        /// Gets or sets the document's character encoding. If the attribute is present, its value must be an ASCII
        /// case-insensitive match for the string <code>utf-8</code>, because UTF-8 is the only valid encoding for
        /// HTML5 documents.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/meta#attr-charset</cref>
        /// </see>
        [JsonProperty("charset", NullValueHandling = NullValueHandling.Ignore)]
        public string Charset { get; set; }

        /// <summary>
        /// Gets or sets a pragma directive.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/meta#attr-http-equiv</cref>
        /// </see>
        [JsonProperty("http-equiv", NullValueHandling = NullValueHandling.Ignore)]
        public string HttpEquiv { get; set; }

        /// <summary>
        /// The <c>name</c> and <c>content</c> attributes can be used together to provide document metadata in terms of
        /// name-value pairs, with the name attribute giving the metadata name, and the content attribute giving the value.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/meta#attr-name</cref>
        /// </see>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the <c>property</c> attribute.
        /// </summary>
        [JsonProperty("property", NullValueHandling = NullValueHandling.Ignore)]
        public string Property { get; set; }

        /// <summary>
        /// Get or sets the value for the <c>http-equiv</c> or <c>name</c> attribute, depending on which is used.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/meta#attr-content</cref>
        /// </see>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new <c>&lt;meta%gt;</c> element.
        /// </summary>
        public Meta() { }

        /// <summary>
        /// Initializes a new <c>&lt;meta%gt;</c> element.
        /// </summary>
        /// <param name="name">The name of the name-value pair.</param>
        /// <param name="content">The content of the name-value pair.</param>
        public Meta(string name, string content) {
            Name = name;
            Content = content;
        }

        /// <summary>
        /// Initializes a new <c>&lt;meta%gt;</c> element.
        /// </summary>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">A unique identifier (ID) which must be unique in the whole document. Its purpose is to
        /// identify the element when linking (using a fragment identifier), scripting, or styling (with CSS).</param>
        /// <param name="chartset">The document's character encoding. If the attribute is present, its value must be an
        /// ASCII case-insensitive match for the string <code>utf-8</code>, because UTF-8 is the only valid encoding
        /// for HTML5 documents.</param>
        /// <param name="name">The name of the name-value pair.</param>
        /// <param name="httpEquiv">A pragma directive</param>
        /// <param name="property">The name of the name-value pair.</param>
        /// <param name="content">The content of the name-value pair.</param>
        public Meta(string hid = null, string id = null, string chartset = null, string name = null, string httpEquiv = null, string property = null, string content = null) {
            Hid = hid;
            Id = id;
            Charset = chartset;
            Name = name;
            HttpEquiv = httpEquiv;
            Property = property;
            Content = content;
        }

        #endregion

    }

}