﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Resemble
{
    public static class Styles
    {

        public static bool loaded { get; private set; }
        private static string path;
        public static GUIStyle bodyStyle;
        public static GUIStyle settingsBody;
        public static GUIStyle settingsIndex;
        public static GUIStyle settingsLink;
        public static GUIStyle linkStyle;
        public static GUIStyle linkStyleSmall;
        public static GUIStyle centredLabel;
        public static GUIStyle bigTitle;
        public static GUIStyle header;
        public static GUIStyle footer;
        public static GUIStyle headerField;
        public static GUIStyle arrayBox;
        public static GUIStyle arrayScrollBar;
        public static GUIStyle projectHeaderLabel;
        public static GUIStyle textStyle;
        public static GUIContent characterSetHelpBtn;
        public static GUIContent popupBtn;
        public static Color podColor = new Color(0.1921f, 0.8196f, 0.6352f);
        public static Color clipColor = new Color(1.0f, 0.6509f, 0.0f);
        public static Color selectColor = new Color(0.0f, 0.611f, 1.0f, 0.5f);


        public static void Load()
        {
            if (loaded)
                return;

            if (Event.current == null)
                return;

            //Styles
            bodyStyle = new GUIStyle(EditorStyles.label);
            bodyStyle.wordWrap = false;

            settingsBody = new GUIStyle(EditorStyles.label);
            settingsBody.richText = true;
            settingsBody.wordWrap = true;
            settingsBody.margin = new RectOffset(30, 0, 0, 0);
            settingsBody.fontSize = 12;

            settingsLink = new GUIStyle(settingsBody);
            settingsLink.normal.textColor = new Color(0x00 / 255f, 0x78 / 255f, 0xDA / 255f, 1f);

            settingsIndex = new GUIStyle(settingsLink);
            settingsIndex.fontSize = 11;
            settingsIndex.margin = new RectOffset(0, 0, 0, 0);

            linkStyle = new GUIStyle(bodyStyle);
            linkStyle.padding = new RectOffset(-5, 0, 2, 0);
            linkStyle.normal.textColor = new Color(0x00 / 255f, 0x78 / 255f, 0xDA / 255f, 1f);

            linkStyleSmall = new GUIStyle(linkStyle);
            linkStyleSmall.fontSize = 9;

            centredLabel = new GUIStyle(EditorStyles.label);
            centredLabel.alignment = TextAnchor.MiddleCenter;
            centredLabel.padding = new RectOffset(12, 12, 0, 2);
            centredLabel.fontSize = 14;

            bigTitle = new GUIStyle("In BigTitle");

            header = new GUIStyle(EditorStyles.largeLabel);
            header.fontSize = 16;

            footer = new GUIStyle(EditorStyles.largeLabel);
            footer.fontSize = 10;
            footer.richText = true;
            footer.alignment = TextAnchor.LowerRight;

            headerField = new GUIStyle(GUI.skin.textField);
            headerField.fontSize = 16;
            headerField.fixedHeight = 22;

            arrayBox = new GUIStyle(GUI.skin.box);
            arrayBox.margin = new RectOffset(0, 0, 0, 0);

            projectHeaderLabel = new GUIStyle(EditorStyles.whiteLargeLabel);
            projectHeaderLabel.alignment = TextAnchor.MiddleLeft;
            projectHeaderLabel.normal.textColor = Color.white;
            projectHeaderLabel.font = Resources.instance.font;
            projectHeaderLabel.fontStyle = FontStyle.Bold;
            projectHeaderLabel.fontSize = 20;

            textStyle = new GUIStyle(EditorStyles.largeLabel);
            textStyle.wordWrap = true;

            //GUIContent
            characterSetHelpBtn = EditorGUIUtility.IconContent("_Help");
            characterSetHelpBtn.tooltip = "Open the documentation for Resemble CharacterSet";
            popupBtn = EditorGUIUtility.IconContent("_Popup");

            loaded = true;
            return;
        }

    }
}