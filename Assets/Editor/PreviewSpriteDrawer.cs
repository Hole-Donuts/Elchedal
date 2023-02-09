using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PreviewSpriteAttribute))]
public class PreviewSpriteDrawer : PropertyDrawer
{
    //kalo texture2D bakal Burem makanya make Sprite biar gak burem
    public override float GetPropertyHeight(SerializedProperty property,
        GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true) + 150;
        if (property.propertyType == SerializedPropertyType.ObjectReference &&
            (property.objectReferenceValue as Sprite/*Texture2D*/) != null)
        {
            return EditorGUI.GetPropertyHeight(property, label, true) + 300;
        }

        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Texture2D a = (Texture2D)property.objectReferenceValue;

        //Sprite b = (Sprite)a;
        //EditorGUI.PropertyField(position, property, label, true);

        // property.objectReferenceValue = (Texture2D)EditorGUI.ObjectField(position, label, property.objectReferenceValue,
        //     typeof(Texture2D), false);
        property.objectReferenceValue = (Sprite)EditorGUI.ObjectField(position, label, property.objectReferenceValue,
            typeof(Sprite), false);
    }
}