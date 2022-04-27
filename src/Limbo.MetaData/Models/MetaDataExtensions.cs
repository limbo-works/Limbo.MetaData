using System;
using System.Collections.Generic;
using Limbo.MetaData.Models.Elements;
using Limbo.MetaData.Models.OpenGraph;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Security;
using Skybrud.Essentials.Strings;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace Limbo.MetaData.Models {
    
    /// <summary>
    /// Static class with extension methods targeting various classes throughout this package.
    /// </summary>
    public static partial class MetaDataExtensions {

        #region Basics

        /// <summary>
        /// Sets the canonical URL of <paramref name="metaData"/> to the value of the specified <paramref name="canonicalUrl"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="canonicalUrl">The canonical URL.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetCanonicalUrl<TMeta>(this TMeta metaData, string canonicalUrl) where TMeta : MetaData {
            if (metaData != null) metaData.CanonicalUrl = canonicalUrl;
            return metaData;
        }

        /// <summary>
        /// Sets the value for the <c>robots</c> <c>&lt;meta&gt;</c> element of the page.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="value">The robots value.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetRobots<TMeta>(this TMeta metaData, string value) where TMeta : MetaData {
            if (metaData != null) metaData.Robots = value;
            return metaData;
        }

        /// <summary>
        /// Sets the meta title of the page.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="value">The value of the title.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetMetaTitle<TMeta>(this TMeta metaData, string value) where TMeta : MetaData {
            if (metaData != null) metaData.MetaTitle = value;
            return metaData;
        }

        /// <summary>
        /// Sets the meta description of the page.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="value">The value of the description.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetMetaDescription<TMeta>(this TMeta metaData, string value) where TMeta : MetaData {
            if (metaData != null) metaData.MetaDescription = value;
            return metaData;
        }

        /// <summary>
        /// Sets the browser title of the page (value of the <c>&lt;title&gt;</c> element).
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="value">The value of the <c>&lt;title&gt;</c> element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetTitle<TMeta>(this TMeta metaData, string value) where TMeta : MetaData {
            if (metaData != null) metaData.Title = value;
            return metaData;
        }

        #endregion

        #region AddLink(...)
        
        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element with the specified parameters.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="rel">The value of the <c>rel</c> attribute.</param>
        /// <param name="href">The value of the <c>href</c> attribute.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddLink<TMeta>(this TMeta metaData, string rel, string href) where TMeta : MetaData {
            return AddLink(metaData, new Link {
                Href = href,
                Rel = rel
            });
        }

        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element with the specified parameters.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="rel">The value of the <c>rel</c> attribute.</param>
        /// <param name="href">The value of the <c>href</c> attribute.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value of the <c>id</c> attribute.</param>
        /// <param name="type">The value of the <c>type</c> attribute.</param>
        /// <param name="media">The value of the <c>media</c> attribute.</param>
        /// <param name="sizes">The value of the <c>sizes</c> attribute.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddLink<TMeta>(this TMeta metaData, string rel = null, string href = null, string hid = null, string id = null, string type = null, string media = null, string sizes = null) where TMeta : MetaData {
            return AddLink(metaData, new Link {
                Hid = hid,
                Id = id,
                Href = href,
                Rel = rel,
                Type = type,
                Media = media,
                Sizes = sizes
            });
        }

        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element based on <paramref name="link"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="link">The <c>&lt;link&gt;</c> element to be added.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddLink<TMeta>(this TMeta metaData, Link link) where TMeta : MetaData {
            if (link == null) throw new ArgumentNullException(nameof(link));
            metaData?.Links.Add(link);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element which may be configured via the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="action">The action used to configure the element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta AddLink<TMeta>(this TMeta metaData, Action<Link> action) where TMeta : MetaData {
            if (metaData == null) return null;
            if (action == null) throw new ArgumentNullException(nameof(action));
            Link link = new();
            action(link);
            metaData.Links.Add(link);
            return metaData;
        }

        #endregion

        #region AddScript(...)

        /// <summary>
        /// Adds a new <c>&lt;script&gt;</c> element with the specified <paramref name="src"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="src">The source of the script.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddScript<TMeta>(this TMeta metaData, string src) where TMeta : MetaData {
            metaData?.Scripts.Add(new Script(src));
            return metaData;
        }

        /// <summary>
        /// Appends a new <c>&lt;script&gt;</c> element to <paramref name="metaData"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="source">The value of the <c>src</c> attribute.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value of the <c>id</c> attribute.</param>
        /// <param name="title">The value of the <c>title</c> attribute.</param>
        /// <param name="type">The value of the <c>type</c> attribute.</param>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        /// <param name="appendToBody">Whether the script element should be appended to the <c>&lt;body&gt;</c> element.</param>
        /// <param name="defer">Whether the script is meant to be executed after the document has been parsed, but before firing the <c>DOMContentLoaded</c> event.</param>
        /// <param name="async">Whether the browser should, if possible, load the script asynchronously and then execute it as soon as it’s downloaded.</param>
        /// <param name="json">Gets or sets the JSON of the <c>script</c> element. This property allows you to render JSON content within a script tag, while still sanitizing the keys and values. For example this can be used to render JSON-LD.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddScript<TMeta>(this TMeta metaData, string source = null, string hid = null, string id = null, string title = null,  string type = null, string innerHtml = null, bool appendToBody = false, bool defer = false, bool async = false, JToken json = null) where TMeta : MetaData {
            metaData?.Scripts.Add(new Script {
                Hid = hid,
                Id = id,
                Title = title,
                Source = source,
                Type = type ?? "text/javascript",
                InnerHtml = innerHtml,
                AppendToBody = appendToBody,
                Defer = defer,
                Async = async,
                Json = json
            });
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;script&gt;</c> element which may be configured via the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="action">The action used to configure the element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta AddScript<TMeta>(this TMeta metaData, Action<Script> action) where TMeta : MetaData {
            if (action == null) throw new ArgumentNullException(nameof(action));
            Script script = new();
            action(script);
            metaData?.Scripts.Add(script);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;script&gt;</c> element represented by the specified <paramref name="script"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="script">The <c>&lt;script&gt;</c> element to be added.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="script"/> is <c>null</c>.</exception>
        public static TMeta AddScript<TMeta>(this TMeta metaData, Script script) where TMeta : MetaData {
            if (script == null) throw new ArgumentNullException(nameof(script));
            metaData?.Scripts.Add(script);
            return metaData;
        }

        #endregion

        #region AddNoScript(...)

        /// <summary>
        /// Adds a new <c>&lt;noscript&gt;</c> element with the specified <paramref name="innerHtml"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddNoScript<TMeta>(this TMeta metaData, string innerHtml) where TMeta : MetaData {
            metaData?.NoScripts.Add(new NoScript {
                InnerHtml = innerHtml
            });
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;noscript&gt;</c> element with the specified parameters.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="innerHtml">The inner HTML of the element.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value of the <c>id</c> attribute.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddNoScript<TMeta>(this TMeta metaData, string innerHtml = null, string hid = null, string id = null) where TMeta : MetaData {
            metaData?.NoScripts.Add(new NoScript {
                Hid = hid,
                Id = id,
                InnerHtml = innerHtml
            });
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;noscript&gt;</c> element which may be configured via the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="action">The action used to configure the element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta AddNoScript<TMeta>(this TMeta metaData, Action<NoScript> action) where TMeta : MetaData {
            if (action == null) throw new ArgumentNullException(nameof(action));
            NoScript noscript = new();
            action(noscript);
            metaData?.NoScripts.Add(noscript);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;noscript&gt;</c> element represented by the specified <paramref name="noscript"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="noscript">The <c>&lt;noscript&gt;</c> element to be added.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta AddNoScript<TMeta>(this TMeta metaData, NoScript noscript) where TMeta : MetaData {
            if (noscript == null) throw new ArgumentNullException(nameof(noscript));
            metaData?.NoScripts.Add(noscript);
            return metaData;
        }

        #endregion

        #region AddMeta(...)

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element based on the specified <paramref name="name"/> and
        /// <paramref name="content"/> name-value pair.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="name">The name of the name-value pair.</param>
        /// <param name="content">The content of the name-value pair.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta AddMeta<TMeta>(this TMeta metaData, string name, string content) where TMeta : MetaData {
            metaData?.Meta.Add(new Meta(name, content));
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element based on the specified <paramref name="name"/> and
        /// <paramref name="content"/> name-value pair.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="name">The name of the name-value pair.</param>
        /// <param name="content">The content of the name-value pair.</param>
        /// <param name="action">The action used to configure the element.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta AddMeta<TMeta>(this TMeta metaData, string name, string content, Action<Meta> action) where TMeta : MetaData {
            if (metaData == null) return null;
            Meta meta = new(name, content);
            action?.Invoke(meta);
            metaData.Meta.Add(meta);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element with the specified parameters.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="name">The value for the <c>name</c> attribute.</param>
        /// <param name="content">The value for the <c>content</c> attribute.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value for the <c>id</c> attribute.</param>
        /// <param name="charset">The value for the <c>charset</c> attribute.</param>
        /// <param name="property">The value for the <c>property</c> attribute.</param>
        /// <param name="httpEquiv">The value for the <c>http-equiv</c> attribute.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta AddMeta<TMeta>(this TMeta metaData, string name = null, string content = null, string hid = null, string id = null, string charset = null, string property = null, string httpEquiv = null) where TMeta : MetaData {
            if (metaData == null) return null;
            Meta meta = new(name, content) { Hid = hid, Id = id, Charset = charset, Property = property, HttpEquiv = httpEquiv };
            metaData.Meta.Add(meta);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element which may be configured via the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="action">The action used to configure the element.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta AddMeta<TMeta>(this TMeta metaData, Action<Meta> action) where TMeta : MetaData {
            if (action == null) throw new ArgumentNullException(nameof(action));
            Meta meta = new();
            action(meta);
            metaData?.Meta.Add(meta);
            return metaData;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element represented by the specified <paramref name="meta"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="meta">The <c>&lt;meta&gt;</c> element to be added.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta AddMeta<TMeta>(this TMeta metaData, Meta meta) where TMeta : MetaData {
            if (meta == null) throw new ArgumentNullException(nameof(meta));
            metaData?.Meta.Add(meta);
            return metaData;
        }

        #endregion

        #region SetOpenGraph(...)

        /// <summary>
        /// Sets the Open Graph information of the page to the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="value">The new Open Graph properties for the page.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetOpenGraph<TMeta>(this TMeta metaData, OpenGraphProperties value) where TMeta : MetaData {
            if (metaData == null) return null;
            metaData.OpenGraph = value;
            return metaData;
        }

        /// <summary>
        /// Sets the Open Graph information of the page which may be configured through the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="action">The action used to configure the Open Graph properties.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta SetOpenGraph<TMeta>(this TMeta metaData, Action<OpenGraphProperties> action) where TMeta : MetaData {
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (metaData == null) return null;
            metaData.OpenGraph = new OpenGraphProperties();
            action(metaData.OpenGraph);
            return metaData;
        }

        /// <summary>
        /// Sets the Open Graph information of the page which may be configured through the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <typeparam name="TInput">The type of <paramref name="input"/>.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="input">The value to pass on to <paramref name="action"/>.</param>
        /// <param name="action">The action used to configure the Open Graph properties.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta SetOpenGraph<TMeta, TInput>(this TMeta metaData, TInput input, Action<TInput, OpenGraphProperties> action) where TMeta : MetaData {
            if (metaData == null || action == null) return metaData;
            metaData.OpenGraph = new OpenGraphProperties();
            action(input, metaData.OpenGraph);
            return metaData;
        }

        /// <summary>
        /// Sets the Open Graph information of the page which may be configured through the specified <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <typeparam name="TInput1">The type of <paramref name="input1"/>.</typeparam>
        /// <typeparam name="TInput2">The type of <paramref name="input2"/>.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="input1">The first value to pass on to <paramref name="action"/>.</param>
        /// <param name="input2">The second value to pass on to <paramref name="action"/>.</param>
        /// <param name="action">The action used to configure the Open Graph properties.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is <c>null</c>.</exception>
        public static TMeta SetOpenGraph<TMeta, TInput1, TInput2>(this TMeta metaData, TInput1 input1, TInput2 input2, Action<TInput1, TInput2, OpenGraphProperties> action) where TMeta : MetaData {
            if (metaData == null || action == null) return metaData;
            metaData.OpenGraph = new OpenGraphProperties();
            action(input1, input2, metaData.OpenGraph);
            return metaData;
        }

        #endregion

        #region AutoHid(...)

        /// <summary>
        /// Updates the <see cref="Element.Hid"/> property of <paramref name="link"/> with an auto-generated value.
        /// </summary>
        /// <param name="link">The link element.</param>
        /// <param name="hash">Whether the value should be hashed.</param>
        /// <returns><paramref name="link"/> - useful for method chaining.</returns>
        public static Link AutoHid(this Link link, bool hash = true) {
            if (link == null) return null;
            string hid = StringUtils.FirstWithValue(link.Rel);
            if (string.IsNullOrWhiteSpace(hid)) return link;
            link.Hid = hash ? SecurityUtils.GetMd5Hash(hid).Substring(0, 8) : hid;
            return link;
        }

        /// <summary>
        /// Updates the <see cref="Element.Hid"/> property of <paramref name="meta"/> with an auto-generated value.
        /// </summary>
        /// <param name="meta">The meta element.</param>
        /// <param name="hash">Whether the value should be hashed.</param>
        /// <returns><paramref name="meta"/> - useful for method chaining.</returns>
        public static Meta AutoHid(this Meta meta, bool hash = true) {
            if (meta == null) return null;
            string hid = StringUtils.FirstWithValue(meta.Name, meta.Property, meta.HttpEquiv);
            if (string.IsNullOrWhiteSpace(hid)) return meta;
            meta.Hid = hash ? SecurityUtils.GetMd5Hash(hid).Substring(0, 8) : hid;
            return meta;
        }

        /// <summary>
        /// Updates the <see cref="Element.Hid"/> property of each element in <paramref name="collection"/> with an auto-generated value.
        /// </summary>
        /// <typeparam name="T">The type of the items in <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="hash">Whether the <c>hid</c> values should be hashed.</param>
        /// <returns><paramref name="collection"/> - useful for method chaining.</returns>
        public static T AutoHid<T>(this T collection, bool hash = true) where T : IEnumerable<Meta> {
            if (collection == null) return default;
            foreach (var item in collection) item.AutoHid(hash);
            return collection;
        }

        #endregion

        #region Collections

        /// <summary>
        /// Appends <paramref name="element"/> to <paramref name="list"/>.
        /// </summary>
        /// <typeparam name="TElement">The type of <paramref name="element"/>.</typeparam>
        /// <param name="element">The element to be added.</param>
        /// <param name="list">The list to which <paramref name="element"/> should be added.</param>
        /// <returns><paramref name="element"/> - useful for method chaining.</returns>
        public static TElement AppendTo<TElement>(this TElement element, List<TElement> list) where TElement : Element {
            if (element == null) return null;
            list.Add(element);
            return element;
        }

        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element to <paramref name="list"/>.
        /// </summary>
        /// <param name="list">The list to which the element should be added.</param>
        /// <param name="rel">The value for the <c>rel</c> attribute.</param>
        /// <param name="href">The value for the <c>href</c> attribute.</param>
        /// <returns><paramref name="list"/> - useful for method chaining.</returns>
        public static List<Link> Add(this List<Link> list, string rel, string href) {
            if (list == null) return default;
            string hid = MetaUtils.Hid(rel);
            list.Add(new Link { Rel = rel, Href = href, Hid = hid });
            return list;
        }

        /// <summary>
        /// Adds a new <c>&lt;link&gt;</c> element to <paramref name="list"/>.
        /// </summary>
        /// <param name="list">The list to which the element should be added.</param>
        /// <param name="rel">The value for the <c>rel</c> attribute.</param>
        /// <param name="href">The value for the <c>href</c> attribute.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value for the <c>id</c> attribute.</param>
        /// <param name="type">The value for the <c>type</c> attribute.</param>
        /// <param name="autoHid">If <c>true</c> and <paramref name="hid"/> is omitted, a new value for <paramref name="hid"/> wil automatically be generated.</param>
        /// <returns><paramref name="list"/> - useful for method chaining.</returns>
        public static List<Link> Add(this List<Link> list, string rel = null, string href = null, string hid = null, string id = null, string type = null, bool autoHid = true) {
            if (list == null) return default;
            hid = hid == null && autoHid ? MetaUtils.Hid(rel) : hid;
            list.Add(new Link { Rel = rel, Href = href, Type = type, Hid = hid, Id = id });
            return list;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element to <paramref name="list"/>.
        /// </summary>
        /// <param name="list">The list to which the element should be added.</param>
        /// <param name="name">The value for the <c>href</c> attribute.</param>
        /// <param name="content">The value for the <c>content</c> attribute.</param>
        /// <returns><paramref name="list"/> - useful for method chaining.</returns>
        public static List<Meta> Add(this List<Meta> list, string name, string content) {
            if (list == null) return default;
            string hid = MetaUtils.Hid(name);
            list.Add(new Meta { Name = name, Content = content, Hid = hid });
            return list;
        }

        /// <summary>
        /// Adds a new <c>&lt;meta&gt;</c> element to <paramref name="list"/>.
        /// </summary>
        /// <param name="list">The list to which the element should be added.</param>
        /// <param name="name">The value for the <c>href</c> attribute.</param>
        /// <param name="content">The value for the <c>content</c> attribute.</param>
        /// <param name="hid">A unique Vue Meta identifier.</param>
        /// <param name="id">The value for the <c>id</c> attribute.</param>
        /// <param name="charset">The value for the <c>charset</c> attribute.</param>
        /// <param name="property">The value for the <c>property</c> attribute.</param>
        /// <param name="httpEquiv">The value for the <c>http-equiv</c> attribute.</param>
        /// <param name="autoHid">If <c>true</c> and <paramref name="hid"/> is omitted, a new value for <paramref name="hid"/> wil automatically be generated.</param>
        /// <returns><paramref name="list"/> - useful for method chaining.</returns>
        public static List<Meta> Add(this List<Meta> list, string name = null, string content = null, string hid = null, string id = null, string charset = null, string property = null, string httpEquiv = null, bool autoHid = true) {
            if (list == null) return default;
            hid = hid == null && autoHid ? MetaUtils.Hid(StringUtils.FirstWithValue(name, property, httpEquiv)) : hid;
            list.Add(new Meta { Name = name, Content = content, Hid = hid, Id = id, Charset = charset, Property = property, HttpEquiv = httpEquiv});
            return list;
        }

        #endregion

    }

}