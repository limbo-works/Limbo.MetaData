using Newtonsoft.Json;

namespace Limbo.MetaData.Models.Elements {

    /// <summary>
    /// Represents a <c>&lt;noscript%gt;</c> HTML element.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/script</cref>
    /// </see>
    public class NoScript : Element {

        #region Properties

        /// <summary>
        /// Gets or sets the inner HTML of the <c>&lt;noscript%gt;</c> element.
        /// </summary>
        [JsonProperty("innerHTML", NullValueHandling = NullValueHandling.Ignore)]
        public string InnerHtml { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new <c>&lt;noscript%gt;</c> element with default options.
        /// </summary>
        public NoScript() { }

        /// <summary>
        /// Initializes a new <c>&lt;noscript%gt;</c> element based on the specified <paramref name="innerHtml"/>.
        /// </summary>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        public NoScript(string innerHtml) {
            InnerHtml = innerHtml;
        }

        /// <summary>
        /// Initializes a new <c>&lt;noscript%gt;</c> element based on the specified parameters.
        /// </summary>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value of the <c>id</c> attribute.</param>
        public NoScript(string innerHtml = null, string hid = null, string id = null) {
            InnerHtml = innerHtml;
            Hid = hid;
            Id = id;
        }

        #endregion

    }

}