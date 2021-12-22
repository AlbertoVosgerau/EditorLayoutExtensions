using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorLayoutExtensions.GUIElements.Models
{
    public class GUIElementStyle
    {
        public float startSpace;
        public float endSpace;

        public GUIElementStyle(float startSpace = 0, float endSpace = 0)
        {
            this.startSpace = startSpace;
            this.endSpace = endSpace;
        }
    }
}