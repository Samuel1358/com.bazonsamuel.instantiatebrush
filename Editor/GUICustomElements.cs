using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace InstantiateBrush.Editor
{
#if UNITY_EDITOR
    public static class GUICustomElements
    {
        private static Color lightBlue = new Color(0.5490196078431373f, 0.7450980392156863f, 0.9803921568627451f);

        #region // Dialog



        #endregion

        #region // FlexibleSelectionGrid

        #region // Regular

        public static void FlexibleSelectionGrid(ref int selectedIndex, string[] namesList)
        {
            bool changed;
            m_FlexibleSelectionGrid(ref selectedIndex, namesList, out changed);
        }
        public static void FlexibleSelectionGrid(ref int selectedIndex, string[] namesList, out bool changed)
        {
            m_FlexibleSelectionGrid(ref selectedIndex, namesList, out changed);
        }

        public static void FlexibleSelectionGrid<T>(ref int selectedIndex, List<T> list)
        {
            bool changed;
            m_FlexibleSelectionGrid(ref selectedIndex, m_GetSelectionNames(list), out changed);
        }
        public static void FlexibleSelectionGrid<T>(ref int selectedIndex, List<T> list, out bool changed)
        {
            m_FlexibleSelectionGrid(ref selectedIndex, m_GetSelectionNames(list), out changed);
        }

        #endregion

        #region // Format

        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, int alignFactor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, namesList, alignFactor, lightBlue);
        }
        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, int alignFactor, Color selectionColor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, namesList, alignFactor, selectionColor);
        }
        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, Color selectionColor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, namesList, 8, selectionColor);
        }

        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, out bool changed, int alignFactor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, namesList, out changed, alignFactor, lightBlue);
        }
        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, out bool changed, int alignFactor, Color selectionColor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, namesList, out changed, alignFactor, selectionColor);
        }
        public static void FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, out bool changed, Color selectionColor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, namesList, out changed, 8, selectionColor);
        }

        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, int alignFactor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, m_GetSelectionNames(list), alignFactor, lightBlue);
        }
        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, int alignFactor, Color selectionColor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, m_GetSelectionNames(list), alignFactor, selectionColor);
        }
        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, Color selectionColor)
        {
            m_FlexibleSelectionGridJustFormat(ref selectedIndex, m_GetSelectionNames(list), 8, selectionColor);
        }

        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, out bool changed, int alignFactor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, m_GetSelectionNames(list), out changed, alignFactor, lightBlue);
        }
        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, out bool changed, int alignFactor, Color selectionColor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, m_GetSelectionNames(list), out changed, alignFactor, selectionColor);
        }
        public static void FlexibleSelectionGridFormat<T>(ref int selectedIndex, List<T> list, out bool changed, Color selectionColor)
        {
            m_FlexibleSelectionGridFormat(ref selectedIndex, m_GetSelectionNames(list), out changed, 8, selectionColor);
        }

        #endregion


        private static void m_FlexibleSelectionGrid(ref int selectedIndex, string[] namesList, out bool changed)
        {
            GUILayout.BeginHorizontal();

            changed = false;

            int wdith = 0;
            for (int i = 0; i < namesList.Length; i++)
            {
                wdith += namesList[i].Length * 8;
                if (wdith < EditorGUIUtility.currentViewWidth)
                {
                    Color oldColor = GUI.backgroundColor;

                    if (selectedIndex == i)
                    {
                        GUI.backgroundColor = lightBlue;
                    }

                    // return index
                    if (GUILayout.Button(namesList[i]))
                    {
                        selectedIndex = i;
                        changed = true;
                    }

                    GUI.backgroundColor = oldColor;
                }
                else
                {
                    wdith = 0;
                    i--;

                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
            }

            GUILayout.EndHorizontal();
        }

        private static void m_FlexibleSelectionGridFormat(ref int selectedIndex, string[] namesList, out bool changed, int alignFactor, Color selectionColor)
        {
            GUILayout.BeginHorizontal();

            changed = false;

            int wdith = 0;
            for (int i = 0; i < namesList.Length; i++)
            {
                wdith += namesList[i].Length * alignFactor;
                if (wdith < EditorGUIUtility.currentViewWidth)
                {
                    Color oldColor = GUI.backgroundColor;

                    if (selectedIndex == i)
                    {
                        GUI.backgroundColor = selectionColor;
                    }

                    // return index
                    if (GUILayout.Button(namesList[i]))
                    {
                        selectedIndex = i;
                        changed = true;
                    }

                    GUI.backgroundColor = oldColor;
                }
                else
                {
                    wdith = 0;
                    i--;

                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
            }

            GUILayout.EndHorizontal();
        }

        private static void m_FlexibleSelectionGridJustFormat(ref int selectedIndex, string[] namesList, int alignFactor, Color selectionColor)
        {
            GUILayout.BeginHorizontal();

            int wdith = 0;
            for (int i = 0; i < namesList.Length; i++)
            {
                wdith += namesList[i].Length * alignFactor;
                if (wdith < EditorGUIUtility.currentViewWidth)
                {
                    Color oldColor = GUI.backgroundColor;

                    if (selectedIndex == i)
                    {
                        GUI.backgroundColor = selectionColor;
                    }

                    // return index
                    if (GUILayout.Button(namesList[i]))
                    {
                        selectedIndex = i;
                    }

                    GUI.backgroundColor = oldColor;
                }
                else
                {
                    wdith = 0;
                    i--;

                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
            }

            GUILayout.EndHorizontal();
        }

        private static string[] m_GetSelectionNames<T>(List<T> list)
        {
            List<string> names = new List<string>();
            foreach (T item in list)
            {
                if (item is Object o)
                {
                    if (o != null)
                    {
                        names.Add(o.name);
                    }
                }
                else
                {
                    if (item != null)
                    {
                        names.Add(item.ToString());
                    }
                }
            }

            return names.ToArray();
        }

        #endregion
    }
#endif
}

// Made by: Samuel Gatinho Bazon
//          bazonsamuel@gmail.com