using System.Collections.Generic;
using Limbo.MetaData.Models.Elements;

namespace Limbo.MetaData.Models.Twitter {

    /// <summary>
    /// Interface representing a Twitter card.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/optimize-with-cards/overview/abouts-cards</cref>
    /// </see>
    public interface ITwitterCard {

        /// <summary>
        /// Gets the type of the card - eg. <c>summary_large_image</c>.
        /// </summary>
        string Card { get; }

        /// <summary>
        /// Gets or sets the username of the Twitter user representing the site.
        /// </summary>
        string Site { get; }

        /// <summary>
        /// Gets or sets the username of the Twitter user the card should be attributed to.
        /// </summary>
        string Creator { get; }

        /// <summary>
        /// Returns a list of meta tags describing the Twitter card.
        /// </summary>
        /// <returns>An instance of <see cref="IReadOnlyList{Meta}"/>.</returns>
        IReadOnlyList<Meta> GetMetaTags();

    }

}