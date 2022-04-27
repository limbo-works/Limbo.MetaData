using System.Collections.Generic;
using System.Linq;
using Limbo.MetaData.Models.Elements;
using Skybrud.Essentials.Strings.Extensions;
using static Limbo.MetaData.MetaUtils;

namespace Limbo.MetaData.Models.OpenGraph {

    /// <summary>
    /// Class representing the Open Graph properties of a page.
    /// </summary>
    public class OpenGraphProperties {

        #region Properties

        /// <summary>
        /// Gets the Open Graph title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the Open Graph description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the Open Graph site name.
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Gets the Open Graph URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets a collection of Open Graph images.
        /// </summary>
        public List<OpenGraphImage> Images { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public OpenGraphProperties() {
            Images = new List<OpenGraphImage>();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Appends an image with the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the image.</param>
        public void AppendImage(string url) {
            if (string.IsNullOrWhiteSpace(url)) return;
            Images.Add(new OpenGraphImage(url));
        }

        /// <summary>
        /// Appends an image with the specified <paramref name="url"/>, <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="url">The URL of the image.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        public void AppendImage(string url, int width, int height) {
            if (string.IsNullOrWhiteSpace(url)) return;
            Images.Add(new OpenGraphImage(url, width, height));
        }

        /// <summary>
        /// Appends the images from the specified array of <paramref name="urls"/>.
        /// </summary>
        /// <param name="urls">The URLs of the images to append.</param>
        public void AppendImages(params string[] urls) {
            if (urls == null || urls.Length == 0) return;
            Images.AddRange(urls.Select(imageUrl => new OpenGraphImage(imageUrl)));
        }

        /// <summary>
        /// Returns a list of meta tags representing this instance.
        /// </summary>
        /// <returns>An instance of <see cref="IReadOnlyList{Meta}"/>.</returns>
        public IReadOnlyList<Meta> GetMetaTags() {

            List<Meta> temp = new ();
            
            if (Title.HasValue()) temp.Add(property: "og:title", content: Title, autoHid: true);
            if (Description.HasValue()) temp.Add(property: "og:description", content: Description, autoHid: true);
            if (SiteName.HasValue()) temp.Add(property: "og:site_name", content: SiteName, autoHid: true);
            if (Url.HasValue()) temp.Add(property: "og:url", content: Url, autoHid: true);

            int i = 1;

            foreach (OpenGraphImage image in Images) {

                if (string.IsNullOrWhiteSpace(image.Url)) continue;

                temp.Add(property: "og:image", content: image.Url, hid: Hid($"og:image:{i:000}"));

                if (image.Width > 0) temp.Add(property: "og:image:width", content: image.Width.ToString(), hid: Hid($"og:image:width:{i:000}"));
                if (image.Height > 0) temp.Add(property: "og:image:height", content: image.Height.ToString(), hid: Hid($"og:image:width:{i:000}"));

                i++;

            }

            return temp;

        }

        #endregion

    }

}