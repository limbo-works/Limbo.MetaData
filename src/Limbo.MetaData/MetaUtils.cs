using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Security;

namespace Limbo.MetaData {

    /// <summary>
    /// Static class with various utility methods for working with meta data.
    /// </summary>
    public static class MetaUtils {
        
        /// <summary>
        /// Adds a new <c>&lt;meta /&gt;</c> element with the specified <paramref name="name"/> and <paramref name="content"/> attributes.
        /// </summary>
        /// <param name="meta">The collection to which the <c>&lt;meta /&gt;</c> element will be appended.</param>
        /// <param name="name">The value of the <c>name</c> attribute.</param>
        /// <param name="content">The value of the <c>content</c> attribute.</param>
        /// <param name="mandatory">If <c>true</c> the <c>&lt;meta /&gt;</c> element will be appended regardless of <paramref name="content"/> being empty.</param>
        /// <param name="hid">A unique value that identifies to the element.</param>
        /// <param name="addHid">If set to <c>true</c> and <c>hid</c> is not specified, a <c>hid</c> value based on <paramref name="name"/> will be added instead.</param>
        public static void AddMetaContent(JArray meta, string name, string content, bool mandatory = false, string hid = null, bool addHid = false) {

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(content) && mandatory == false) return;

            JObject json = new() {
                { "name", name },
                { "content", content ?? string.Empty }
            };

            if (!string.IsNullOrWhiteSpace(hid)) {
                json.AddFirst(new JProperty("hid", hid));
            } else if (addHid) {
                json.AddFirst(new JProperty("hid", Hid(name)));
            }

            meta.Add(json);

        }

        /// <summary>
        /// Adds a new <c>&lt;meta /&gt;</c> element with the specified <paramref name="property"/> and <paramref name="content"/> attributes.
        /// </summary>
        /// <param name="meta">The collection to which the <c>&lt;meta /&gt;</c> element will be appended.</param>
        /// <param name="property">The value of the <c>property</c> attribute.</param>
        /// <param name="content">The value of the <c>content</c> attribute.</param>
        /// <param name="mandatory">If <c>true</c> the <c>&lt;meta /&gt;</c> element will be appended regardless of <paramref name="content"/> being empty.</param>
        /// <param name="hid">A unique value that identifies to the element.</param>
        /// <param name="addHid">If set to <c>true</c> and <c>hid</c> is not specified, a <c>hid</c> value based on <paramref name="property"/> will be added instead.</param>
        public static void AddMetaProperty(JArray meta, string property, string content, bool mandatory = false, string hid = null, bool addHid = false) {

            if (string.IsNullOrWhiteSpace(property)) return;
            if (string.IsNullOrWhiteSpace(content) && mandatory == false) return;

            JObject json = new() {
                { "property", property },
                { "content", content ?? string.Empty }
            };
            
            if (!string.IsNullOrWhiteSpace(hid)) {
                json.AddFirst(new JProperty("hid", hid));
            } else if (addHid) {
                json.AddFirst(new JProperty("hid", Hid(property)));
            }

            meta.Add(json);

        }

        /// <summary>
        /// Adds a new <c>&lt;meta /&gt;</c> element with the specified <paramref name="property"/> and <paramref name="content"/> attributes.
        /// </summary>
        /// <param name="meta">The collection to which the <c>&lt;meta /&gt;</c> element will be appended.</param>
        /// <param name="property">The value of the <c>property</c> attribute.</param>
        /// <param name="content">The value of the <c>content</c> attribute.</param>
        /// <param name="mandatory">If <c>true</c> the <c>&lt;meta /&gt;</c> element will be appended regardless of <paramref name="content"/> being empty.</param>
        /// <param name="hid">A unique value that identifies to the element.</param>
        public static void AddMetaProperty(JArray meta, string property, object content, bool mandatory = false, string hid = null) {
            string value = content == null ? null : string.Format(CultureInfo.InvariantCulture, "{0}", content);
            AddMetaProperty(meta, property, value, mandatory, hid);
        }

        /// <summary>
        /// Adds a new <c>&lt;link /&gt;</c> element with the specified <paramref name="rel"/> and <paramref name="href"/>.
        /// </summary>
        /// <param name="links">The collection to which the <c>&lt;link /&gt;</c> element will be appended.</param>
        /// <param name="rel">The value for the <c>rel</c> attribute of the <c>&lt;link /&gt;</c> element.</param>
        /// <param name="href">The value for the <c>href</c> attribute of the <c>&lt;link /&gt;</c> element.</param>
        /// <param name="mandatory">If <c>true</c> the <c>&lt;link /&gt;</c> element will be appended regardless of <paramref name="href"/> being empty.</param>
        public static void AddLink(JArray links, string rel = null, string href = null, bool mandatory = false) {
            if (string.IsNullOrWhiteSpace(href) && mandatory == false) return;
            links.Add(new JObject { { "rel", rel }, { "href", href ?? string.Empty } });
        }

        /// <summary>
        /// Generatea a new, hashed <c>hid</c> value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The hashed value.</returns>
        public static string Hid(string value) {
            return value == null ? null : SecurityUtils.GetMd5Hash(value).Substring(0, 8);
        }

    }

}