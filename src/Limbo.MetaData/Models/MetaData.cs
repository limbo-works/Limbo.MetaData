using System.Collections.Generic;
using Limbo.MetaData.Models.Elements;
using Limbo.MetaData.Models.OpenGraph;
using Limbo.MetaData.Models.Twitter;

namespace Limbo.MetaData.Models {
    
    /// <summary>
    /// Class with basic meta data about a given page.
    /// </summary>
    public class MetaData {

        #region Properties

        /// <summary>
        /// Gets or sets the value of <code>&lt;title&gt;</code> element. Generally this value should include both the page name and site name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the canonical URL of the page.
        /// </summary>
        public string CanonicalUrl { get; set; }

        /// <summary>
        /// Gets or sets the meta title of the page. Not the same as <see cref="Title"/>.
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the meta description of the page.
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the <c>robots</c> value of the page - eg. <c>index,follow</c>.
        /// </summary>
        public string Robots { get; set; }

        /// <summary>
        /// Gets or sets an object that defines the <c>&lt;base&gt;</c> HTML element.
        /// </summary>
        public Base Base { get; set; }

        /// <summary>
        /// Gets or sets a collection of <c>&lt;link&gt;</c> elements.
        /// </summary>
        public List<Link> Links { get; set; }

        /// <summary>
        /// Gets or sets a collection of <c>&lt;meta&gt;</c> elements.
        /// </summary>
        public List<Meta> Meta { get; set; }

        /// <summary>
        /// Gets or sets a collection of <c>&lt;script&gt;</c> elements.
        /// </summary>
        public List<Script> Scripts { get; set; }

        /// <summary>
        /// Gets or sets a collection of <c>&lt;noscript&gt;</c> elements.
        /// </summary>
        public List<NoScript> NoScripts { get; set; }

        /// <summary>
        /// Gets or sets a collection of Open Graph properties of the page.
        /// </summary>
        public OpenGraphProperties OpenGraph { get; set; }

        /// <summary>
        /// Gets or sets the Twitter card of the page.
        /// </summary>
        public ITwitterCard TwitterCard { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public MetaData() {
            Links = new List<Link>();
            Meta = new List<Meta>();
            Scripts = new List<Script>();
            NoScripts = new List<NoScript>();
        }

        #endregion
        
    }

}