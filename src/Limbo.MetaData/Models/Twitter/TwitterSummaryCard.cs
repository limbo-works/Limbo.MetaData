using System.Collections.Generic;
using Limbo.MetaData.Models.Elements;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable InconsistentNaming

namespace Limbo.MetaData.Models.Twitter {

    /// <summary>
    /// Class representing a <strong>Summary</strong> Twitter card.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/optimize-with-cards/overview/summary</cref>
    /// </see>
    public class TwitterSummaryCard : ITwitterCard {

        /// <summary>
        /// Gets the type of the card.
        /// </summary>
        public virtual string Card => "summary";

        /// <summary>
        /// Gets or sets the username of the Twitter user representing the site.
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Gets or sets the username of the Twitter user the card should be attributed to.
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Gets or sets a title related to the content of the page.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description that concisely summarizes the content as appropriate for presentation within a
        /// tweet. You should not re-use the title as the description or use this field to describe the general
        /// services provided by the website. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A URL to a unique image representing the content of the page. You should not use a generic image such as
        /// your website logo, author photo, or other image that spans multiple pages. Images for this Card support an
        /// aspect ratio of 2:1 with minimum dimensions of 300x157 or maximum of 4096x4096 pixels. Images must be less
        /// than 5MB in size. JPG, PNG, WEBP and GIF formats are supported. Only the first frame of an animated GIF
        /// will be used. SVG is not supported.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a text description of the image conveying the essential nature of an image to users who are visually impaired. Maximum 420 characters.
        /// </summary>
        public string ImageText { get; set; }

        /// <summary>
        /// Returns a list of meta tags describing the Twitter card.
        /// </summary>
        /// <returns>An instance of <see cref="IReadOnlyList{Meta}"/>.</returns>
        public IReadOnlyList<Meta> GetMetaTags() {

            List<Meta> temp = new();

            temp.Add(name: "twitter:card", content: Card, autoHid: true);
            temp.Add(name: "twitter:site", content: Site, autoHid: true);

            if (Creator.HasValue()) temp.Add(name: "twitter:creator", content: Creator, autoHid: true);
            if (Title.HasValue()) temp.Add(name: "twitter:title", content: Title, autoHid: true);
            if (Description.HasValue()) temp.Add(name: "twitter:description", content: Description, autoHid: true);
            if (Image.HasValue()) temp.Add(name: "twitter:image", content: Image, autoHid: true);
            if (ImageText.HasValue()) temp.Add(name: "twitter:image:alt", content: ImageText, autoHid: true);

            return temp;

        }

    }

}