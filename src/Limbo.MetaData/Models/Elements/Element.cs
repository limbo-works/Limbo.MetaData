using Newtonsoft.Json;

namespace Limbo.MetaData.Models.Elements {
    
    /// <summary>
    /// Abstract class describing an HTML element.
    /// </summary>
    public abstract class Element {

        /// <summary>
        /// Gets or sets a unique ID for this element. The ID is used by Vue Meta to distinguish elements across
        /// pageloads. Not to be confused with the <see cref="Id"/> property.
        /// </summary>
        [JsonProperty("hid", Order = -101, NullValueHandling = NullValueHandling.Ignore)]
        public string Hid { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier (ID) which must be unique in the whole document. Its purpose is to
        /// identify the element when linking (using a fragment identifier), scripting, or styling (with CSS).
        /// </summary>
        /// <see>
        ///     <cref>https://developer.mozilla.org/en-US/docs/Web/HTML/Global_attributes</cref>
        /// </see>
        [JsonProperty("id", Order = -100, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

    }

}