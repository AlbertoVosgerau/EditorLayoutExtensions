using System;
using System.Collections.Generic;
using EditorLayoutExtensions.GUIElements.Models;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace EditorLayoutExtensions.GUIElements
{
    public static class GUIElements
    {
        /// <summary>
        /// Creates a Row
        /// </summary>
        /// <param name="content">Method that will run with content</param>
        /// <param name="padding">Padding at begin and end of a row</param>
        public static void Row(Action content, GUIElementStyle elementStyle = null)
        {
            elementStyle = elementStyle == null ? new GUIElementStyle() : elementStyle;
            
            GUILayout.BeginHorizontal();
            GUILayout.Space(elementStyle.startSpace);
            content();
            GUILayout.Space(elementStyle.endSpace);
            GUILayout.EndHorizontal();
        }
    
        /// <summary>
        /// Creates a Row
        /// </summary>
        /// <param name="content">Method that will run with content</param>
        /// <param name="padding">Padding at begin and end of a column</param>
        public static void Column(Action content, GUIElementStyle elementStyle = null)
        {
            elementStyle = elementStyle == null ? new GUIElementStyle() : elementStyle;
            
            GUILayout.BeginVertical();
            GUILayout.Space(elementStyle.startSpace);
            content();
            GUILayout.Space(elementStyle.endSpace);
            GUILayout.EndVertical();
        }
    
        /// <summary>
        /// Creates a Button
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="callback">Method that will run when a button is clicked</param>
        public static void Button(GUIContent content, Action callback)
        {
            if (GUILayout.Button(content))
            {
                callback();
            }
        }
    
        /// <summary>
        /// Creates a Button
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="callback">Method that will run when a button is clicked</param>
        public static void Button(string content, Action callback)
        {
            if (GUILayout.Button(content))
            {
                callback();
            }
        }
        
        /// <summary>
        /// Creates a Button
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="callback">Method that will run when a button is clicked</param>
        public static void Button(Texture texture, Action callback)
        {
            if (GUILayout.Button(texture))
            {
                callback();
            }
        }

        /// <summary>
        /// Creates a field that will be checked for changes
        /// </summary>
        /// <param name="property">Property that will be drawn</param>
        /// <param name="callback">Method that will run when a button is clicked</param>
        public static void CheckForChanges(SerializedProperty property, Action callback)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(property);
            if (EditorGUI.EndChangeCheck())
            {
                callback();
            }
        }
        
        /// <summary>
        /// Creates a list of fields that will be checked for changes
        /// </summary>
        /// <param name="properties">Properties that will be drawn</param>
        /// <param name="callback">Method that will run when a button is clicked</param>
        public static void CheckForChanges(List<SerializedProperty> properties, Action callback)
        {
            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < properties.Count; i++)
            {
                EditorGUILayout.PropertyField(properties[i]);
            }
            if (EditorGUI.EndChangeCheck())
            {
                callback();
            }
        }

        /// <summary>
        /// Creates a foldout
        /// </summary>
        /// <param name="content">Content that will be drawn when Foldout is open</param>
        /// <param name="isOpen">outputs a bool for the status if it is open or not</param>
        /// <param name="label">Label of the Foldout</param>
        public static void Foldout(Action content, ref bool isOpen, string label)
        {
            isOpen = EditorGUILayout.Foldout(isOpen, label);

            if (isOpen)
            {
                content();
            }
        }
    }
}