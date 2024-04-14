using UnityEditor;
using UnityEngine;

namespace CodeBase.EditorTool
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    [CanEditMultipleObjects]
    public class ButtonAttributeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var monoBehaviour = target as MonoBehaviour;
            var methods = monoBehaviour.GetType().GetMethods();

            foreach (var method in methods)
            {
                var buttonAttribute = System.Attribute.GetCustomAttribute(method, typeof(ButtonAttribute)) as ButtonAttribute;
                if (buttonAttribute != null)
                {
                    if (GUILayout.Button(method.Name))
                    {
                        method.Invoke(monoBehaviour, null);
                    }
                }
            }
        }
    }
}
