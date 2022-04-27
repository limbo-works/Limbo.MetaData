using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Limbo.MetaData.Models.Elements {

    /// <summary>
    /// Represents a <c>&lt;script%gt;</c> HTML element.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/script</cref>
    /// </see>
    public class Script : Element {

        #region Properties

        /// <summary>
        /// Gets or sets the <c>title</c> attribtue of the script element.
        /// 
        /// A title attribute is typically not used for <c>script</c> elements, but some integrations use it to pass
        /// on the title to a UI component.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the source (<c>src</c> attribute) of the script element.
        /// </summary>
        [JsonProperty("src", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the <c>type</c> attribute of the script element.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the inner HTML of the script element.
        /// </summary>
        [JsonProperty("innerHTML", NullValueHandling = NullValueHandling.Ignore)]
        public string InnerHtml { get; set; }

        /// <summary>
        /// Gets or sets whether the script element should be appended to the <c>&lt;body&gt;</c> element.
        /// </summary>
        [JsonProperty("body", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool AppendToBody { get; set; }

        /// <summary>
        /// Gets or sets whether the script is meant to be executed after the document has been parsed, but before
        /// firing the <c>DOMContentLoaded</c> event.
        ///
        /// Scripts with the <c>defer</c> attribute will prevent the <c>DOMContentLoaded</c> event from firing until
        /// the script has loaded and finished evaluating.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/script#attr-defer</cref>
        /// </see>
        [JsonProperty("defer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Defer { get; set; }

        /// <summary>
        /// Gets or sets whether the browser should, if possible, load the script asynchronously and then execute it as
        /// soon as it’s downloaded.
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Element/script#attr-async</cref>
        /// </see>
        [JsonProperty("async", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Async { get; set; }

        /// <summary>
        /// Gets or sets the JSON of the <c>script</c> element. This property allows you to render JSON content within
        /// a script tag, while still sanitizing the keys and values. For example this can be used to render JSON-LD.
        /// </summary>
        [JsonProperty("json", NullValueHandling = NullValueHandling.Ignore)]
        public JToken Json { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new <c>&lt;script%gt;</c> element.
        /// </summary>
        public Script() {
            Type = "text/javascript";
        }

        /// <summary>
        /// Initializes a new <c>&lt;script%gt;</c> element.
        /// </summary>
        /// <param name="source">The source of the <c>&lt;script%gt;</c> element.</param>
        public Script(string source) {
            Source = source;
            Type = "text/javascript";
        }

        /// <summary>
        /// Initializes a new <c>&lt;script%gt;</c> element based on the specified parameters.
        /// </summary>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value of the <c>id</c> attribute.</param>
        /// <param name="title">The value of the <c>title</c> attribute.</param>
        /// <param name="source">The value of the <c>src</c> attribute.</param>
        /// <param name="type">The value of the <c>type</c> attribute.</param>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        /// <param name="appendToBody">Whether the script element should be appended to the <c>&lt;body&gt;</c> element.</param>
        /// <param name="defer">Whether the script is meant to be executed after the document has been parsed, but before firing the <c>DOMContentLoaded</c> event.</param>
        /// <param name="async">Whether the browser should, if possible, load the script asynchronously and then execute it as soon as it’s downloaded.</param>
        /// <param name="json">Gets or sets the JSON of the <c>script</c> element. This property allows you to render JSON content within a script tag, while still sanitizing the keys and values. For example this can be used to render JSON-LD.</param>
        public Script(string source = null, string hid = null, string id = null, string title = null,
            string type = null, string innerHtml = null, bool appendToBody = false, bool defer = false,
            bool async = false, JToken json = null) {
            Source = source;
            Hid = hid;
            Id = id;
            Title = title;
            Type = type ?? "text/javascript";
            InnerHtml = innerHtml;
            AppendToBody = appendToBody;
            Defer = defer;
            Async = async;
            Json = json;
        }

        #endregion

    }

}