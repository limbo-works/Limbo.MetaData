using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Limbo.MetaData.Models.Attributes;
using Limbo.MetaData.Models.Elements;
using Newtonsoft.Json.Linq;

namespace Limbo.MetaData.Models {
    
    /// <summary>
    /// Class representing a meta data model matching the format of <strong>Vue Meta</strong>.
    /// </summary>
    /// <see>
    ///     <cref>https://vue-meta.nuxtjs.org/</cref>
    /// </see>
    public class VueMetaData : MetaData {

        #region Properties

        /// <summary>
        /// Gets or sets a list of attributes of the <c>html</c> element.
        /// </summary>
        public HtmlAttributeList HtmlAttributes { get; set; }

        /// <summary>
        /// Gets or sets a list of attributes of the <c>head</c> element.
        /// </summary>
        public AttributeList HeadAttributes { get; set; }

        /// <summary>
        /// Gets or sets a list of attributes of the <c>body</c> element.
        /// </summary>
        public AttributeList BodyAttributes { get; set; }

        /// <summary>
        /// Gets or sets an array of properties where sanitizing should be disabled. 
        /// </summary>
        /// <see>
        ///     <cref>https://github.com/nuxt/vue-meta/tree/1.x#__dangerouslydisablesanitizers-string</cref>
        /// </see>
        public List<string> DangerouslyDisableSanitizers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public VueMetaData() : this(null) { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="culture"/>.
        /// </summary>
        /// <param name="culture">The culture of the page the meta data represents.</param>
        public VueMetaData(CultureInfo culture) {

            HtmlAttributes = new HtmlAttributeList();
            HeadAttributes = new AttributeList();
            BodyAttributes = new AttributeList();

            // Set the "lang" attribute of the "html" element
            if (culture != null) HtmlAttributes.Language = culture.ToString();

            DangerouslyDisableSanitizers = new List<string>();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a <see cref="JObject"/> representing the meta data.
        /// </summary>
        public virtual JObject ToVueMetaJson() {

            JObject obj = new() { ["title"] = Title ?? string.Empty };

            // TODO: Add support for the "titleTemplate" property

            // Append the <html> attributes (if any)
            if (HtmlAttributes is { Count: > 0 }) {
                JObject htmlAttrs = new();
                foreach (var pair in HtmlAttributes) {
                    htmlAttrs.Add(pair.Key, pair.Value);
                }
                obj["htmlAttrs"] = htmlAttrs;
            }

            // Append the <head> attributes (if any)
            if (HeadAttributes is { Count: > 0 }) {
                JObject headAttrs = new();
                foreach (var pair in HeadAttributes) {
                    headAttrs.Add(pair.Key, pair.Value);
                }
                obj["headAttrs"] = headAttrs;
            }

            // Append the <body> attributes (if any)
            if (BodyAttributes is { Count: > 0 }) {
                JObject bodyAttrs = new();
                foreach (var pair in BodyAttributes) {
                    bodyAttrs.Add(pair.Key, pair.Value);
                }
                obj["bodyAttrs"] = bodyAttrs;
            }

            if (Base != null) obj["base"] = JObject.FromObject(Base);

            List<Meta> meta = new (Meta);
            List<Link> links = new(Links);
            List<Script> script = new (Scripts);
            List<NoScript> noscript = new (NoScripts);

            links.Add(rel: "canonical", hid: "canonical", href: CanonicalUrl);
            meta.Add(name: "description", hid: "description", content: MetaDescription ?? string.Empty);
            meta.Add(name: "robots", hid: "robots", content: Robots);

            if (OpenGraph != null) meta.AddRange(OpenGraph.GetMetaTags());
            if (TwitterCard != null) meta.AddRange(TwitterCard.GetMetaTags());

            if (links.Count > 0) obj.Add("link", JArray.FromObject(links));
            if (meta.Count > 0) obj.Add("meta", JArray.FromObject(meta));
            if (script.Count > 0) obj.Add("script", JArray.FromObject(script));
            if (noscript.Count > 0) obj.Add("noscript", JArray.FromObject(noscript));
            // TODO: Add support for the "style" property

            if (DangerouslyDisableSanitizers is { Count: > 0 }) obj.Add("__dangerouslyDisableSanitizers", new JArray(from str in DangerouslyDisableSanitizers select str));
            // TODO: Add support for the "__dangerouslyDisableSanitizersByTagID" property

            return obj;

        }

        #endregion

    }

}