using System.Linq;
using System.Reflection;
using EditorAttributes;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    /// <summary>
    /// Draw button in Inspector
    /// </summary>
    [CustomEditor(typeof(Object), true, isFallback = false)]
    [CanEditMultipleObjects]
    public class EditorButton : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var o in targets)
            {
                var mis = o.GetType()
                    .GetMethods().Where(m => m.GetCustomAttributes()
                        .Any(a => a.GetType() == typeof(EditorButtonAttribute)));
                foreach (var mi in mis)
                {
                    var attribute = (EditorButtonAttribute)mi.GetCustomAttribute(typeof(EditorButtonAttribute));
                    if (GUILayout.Button(attribute.Text))
                    {
                        mi.Invoke(o, null);
                    }
                }
            }
        }
    }
}