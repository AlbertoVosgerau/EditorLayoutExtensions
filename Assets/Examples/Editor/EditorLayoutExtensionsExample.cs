using System;
using System.Collections;
using System.Collections.Generic;
using EditorLayoutExtensions.GUIElements;
using EditorLayoutExtensions.GUIElements.Models;
using UnityEditor;
using UnityEngine;

public class EditorLayoutExtensionsExample : EditorWindow
{
    private static bool _isOpen;
    [MenuItem("Editor Layout Extensions/Open Creation Window", priority = 0)]
    private static void Init()
    {
        EditorLayoutExtensionsExample window = (EditorLayoutExtensionsExample)GetWindow(typeof(EditorLayoutExtensionsExample));
        window.titleContent = new GUIContent("Window");
        window.Show();
    }

    private void OnGUI()
    {
        GUIElementStyle style = new GUIElementStyle(
            startSpace:0,
            endSpace: 0
        );
        
        GUIElements.Row(() =>
        {
            GUIElements.Button("MyButton02", ButtonClicked);
            GUIElements.Column(() =>
                {
                    GUIElements.Button("MyButton03", ButtonClicked);
                    
                    GUIElements.Foldout(() =>
                        {
                            GUIElements.Column(() =>
                                {
                                    GUIElements.Button("FoldoutButton", ButtonClicked);
                                    GUIElements.Button("FoldoutButton", ButtonClicked);
                                    GUIElements.Button("FoldoutButton", ButtonClicked);
                                    GUIElements.Button("FoldoutButton", ButtonClicked);
                                }
                            );
                        },
                        ref _isOpen,
                        "Test Foldout"
                    );
                }
            );
            
            GUIElements.Column(() =>
            {
                GUIElements.Button("MyButton01", ButtonClicked);
                GUIElements.Button("MyButton01", ButtonClicked);
                GUIElements.Button("MyButton01", ButtonClicked);
                GUIElements.Button("MyButton01", ButtonClicked);
            });
        },
        elementStyle: style
        );
    }
    
    private void ButtonClicked()
    {
        Debug.Log("I was clicked!");
    }
}