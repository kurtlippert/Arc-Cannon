using UnityEditor;

[CustomEditor(typeof(CannonBehavior))]
public class CannonBehaviorInspector : Editor
{

    public SerializedProperty
        arrowPrefab_Prop,
        enableMovement_Prop,
        lowestPoint_Prop,
        highestPoint_Prop;

    void OnEnable()
    {
        arrowPrefab_Prop = serializedObject.FindProperty("arrowPrefab");
        enableMovement_Prop = serializedObject.FindProperty("enableMovement");
        lowestPoint_Prop = serializedObject.FindProperty("lowestPoint");
        highestPoint_Prop = serializedObject.FindProperty("highestPoint");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Show the Arrow Prefab and Enable Movement properties
        EditorGUILayout.PropertyField(arrowPrefab_Prop);
        EditorGUILayout.PropertyField(enableMovement_Prop);

        // Grab the boolean value
        bool enableMovement = (bool)enableMovement_Prop.boolValue;

        if (enableMovement)
        {
            EditorGUILayout.FloatField("Lowest Point", 0);
            EditorGUILayout.FloatField("Highest Point", 0);
        }

        serializedObject.ApplyModifiedProperties();
        //base.OnInspectorGUI();
        /*serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("angleLabel"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("angleField"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityLabel"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("velocityField"), true);
        serializedObject.ApplyModifiedProperties();*/

        /*CannonBehavior cannonBehavior = (CannonBehavior)target;
        if (cannonBehavior.enableMovement)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("lowestPoint"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("highestPoint"), true);
            serializedObject.ApplyModifiedProperties();
        }*/
    }
}
