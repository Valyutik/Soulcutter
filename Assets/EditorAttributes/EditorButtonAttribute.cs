using System;

namespace EditorAttributes
{
    /// <summary>
    /// Attribute from method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class EditorButtonAttribute : Attribute
    {
        /// <summary>
        /// Button text
        /// </summary>
        public readonly string Text;

        /// <summary>
        /// Add Button to Inspector
        /// </summary>
        /// <param name="text">Button text</param>
        public EditorButtonAttribute(string text)
        {
            Text = text;
        }
    }
}
