using UnityEditor;

namespace KeypadSystem
{
    [CustomEditor(typeof(KeypadController))]
    public class KeypadControllerEditor : Editor
    {
        SerializedProperty _keypadType;
        SerializedProperty inputLimit;
        SerializedProperty keypadCodesList;
        SerializedProperty keypadBeep;
        SerializedProperty keypadDenied;
        SerializedProperty isTriggerEvent;
        SerializedProperty triggerObject;

        bool triggerEvent, keypadSounds = false;

        private void OnEnable()
        {
            _keypadType = serializedObject.FindProperty(nameof(_keypadType));
            inputLimit = serializedObject.FindProperty(nameof(inputLimit));
            keypadCodesList = serializedObject.FindProperty(nameof(keypadCodesList));

            keypadBeep = serializedObject.FindProperty(nameof(keypadBeep));
            keypadDenied = serializedObject.FindProperty(nameof(keypadDenied));

            isTriggerEvent = serializedObject.FindProperty(nameof(isTriggerEvent));
            triggerObject = serializedObject.FindProperty(nameof(triggerObject));
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            KeypadController _keypadController = (KeypadController)target;

            EditorGUILayout.LabelField("Type of Keypad", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_keypadType);

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("Character Limit", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(inputLimit);

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("Code List", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(keypadCodesList);

            EditorGUILayout.Space(5);

            keypadSounds = EditorGUILayout.BeginFoldoutHeaderGroup(keypadSounds, "Keypad Sounds");
            if (keypadSounds)
            {
                EditorGUILayout.PropertyField(keypadBeep);
                EditorGUILayout.PropertyField(keypadDenied);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space(5);

            triggerEvent = EditorGUILayout.BeginFoldoutHeaderGroup(triggerEvent, "Trigger Event");
            if (triggerEvent)
            {
                EditorGUILayout.PropertyField(isTriggerEvent);

                if (_keypadController.isTriggerEvent)
                {
                    EditorGUILayout.PropertyField(triggerObject);
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}

