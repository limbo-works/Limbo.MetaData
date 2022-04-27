namespace Limbo.MetaData.Models.Attributes {

    /// <summary>
    /// Class representing a list of attributes of the <c>html</c> element.
    /// </summary>
    public class HtmlAttributeList : AttributeList {

        #region Properties

        /// <summary>
        /// Gets or sets the the value of the <c>lang</c> attribute.
        /// </summary>
        public string Language {
            get => TryGetValue("lang", out string value) ? value : null;
            set => Add("lang", value);
        }

        #endregion

    }

}