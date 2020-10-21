using System;

namespace TNHTweaker_UI.Models.Attributes
{
    /// <summary>
    /// Attribute that defines the property name for a property in the custom character file if it differs from it's C# equivalent or breaks coding standards.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyNameAttribute : Attribute
    {
        /// <summary>
        /// The name of the property to be used in the character file.
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Create a new instance of <see cref="PropertyNameAttribute"/> with a given <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to be used in the character file.</param>
        public PropertyNameAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}