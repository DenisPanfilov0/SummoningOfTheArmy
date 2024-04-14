using UnityEditor;
using UnityEngine;

namespace CodeBase.EditorTool
{
    public class ConditionalHideAttribute : PropertyAttribute {
        public string conditionalSourceField;
        public bool hideInInspector;
        public bool invertCondition;

        public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector = false, bool invertCondition = false) {
            this.conditionalSourceField = conditionalSourceField;
            this.hideInInspector = hideInInspector;
            this.invertCondition = invertCondition;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!condHAtt.hideInInspector || enabled) {
                EditorGUI.PropertyField(position, property, label, true);
            }

            GUI.enabled = wasEnabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

            if (!condHAtt.hideInInspector || enabled) {
                return EditorGUI.GetPropertyHeight(property, label);
            } else {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }

        private bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property) {
            bool enabled = true;
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(condHAtt.conditionalSourceField);

            if (sourcePropertyValue != null) {
                enabled = sourcePropertyValue.boolValue;
                if (condHAtt.invertCondition) enabled = !enabled;
            } else {
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.conditionalSourceField);
            }

            return enabled;
        }
    }
#endif
}