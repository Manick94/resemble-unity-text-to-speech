using UnityEngine;
using UnityEditor;

namespace Resemble.GUIEditor
{
    /// <summary> Paths tab of preference window. </summary>
    public partial class RessembleSettingsProvider
    {
        private GUIContent pathMethode = new GUIContent("Path Method", "Indicates the method chosen by the plugin to " +
            "provide the save path for clips generated by a CharacterSet");

        private GUIContent useSubFolder = new GUIContent("Use subdirectory", "Specifies if you want a folder with the " +
            "name of the CharacterSet before saving the AudioClips.");

        private void DrawPathsSettingsGUI()
        {
            //Description
            GUILayout.Label("Describe where AudioClips from CharacterSets should be generated.", EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);

            //Path methode
            Settings.pathMethode = (Settings.PathMethode) EditorGUILayout.EnumPopup(
                pathMethode, Settings.pathMethode);

            //Target folders fields
            switch (Settings.pathMethode)
            {
                case Settings.PathMethode.Absolute:
                    Settings.folderPathA = FolderField("Target folder", Settings.folderPathA);
                    break;
                case Settings.PathMethode.SamePlace:
                    break;
                case Settings.PathMethode.MirrorHierarchy:
                    Settings.folderPathB = FolderField("Resemble Speechs root", Settings.folderPathB);
                    Settings.folderPathA = FolderField("AudioClips root", Settings.folderPathA);
                    break;
            }

            //Use subFolders
            Settings.useSubFolder = EditorGUILayout.Toggle(useSubFolder, Settings.useSubFolder);

            //Example label
            GUILayout.Space(10);
            GUILayout.Label("Example :");

            //Draw example image
            Rect rect = GUILayoutUtility.GetRect(1, 1);
            Texture image = Resources.instance.pathImages[(int)Settings.pathMethode * 2 + (Settings.useSubFolder ? 1 : 0)];
            rect.Set(rect.x, rect.y, image.width+1, image.height+1);
            GUI.Label(rect, image);
        }

        private string FolderField(string label, string path)
        {
            if (string.IsNullOrEmpty(path))
                path = Application.dataPath;

            Rect rect = GUILayoutUtility.GetRect(16, 16);
            rect.x += 4;
            rect.width = EditorGUIUtility.labelWidth;
            GUI.Label(rect, label);

            rect.Set(rect.x + rect.width, rect.y, Mathf.Max(140, winRect.width - rect.xMax - 64), rect.height);
            string p = path.Remove(0, Application.dataPath.Length);
            bool right = GUI.skin.textField.CalcSize(new GUIContent(p)).x > rect.width;
            GUI.Label(rect, p.Length == 0 ? "[Root]" : p, right ? Styles.folderPathFieldRight : Styles.folderPathField);

            rect.Set(rect.x + rect.width + 5, rect.y, 56, rect.height);
            if (GUI.Button(rect, "Modify"))
            {
                string temp = EditorUtility.SaveFolderPanel(label, path, "");
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!temp.StartsWith(Application.dataPath))
                        EditorUtility.DisplayDialog("Path error", "Target folder need to be inside the project", "Ok");
                    else
                        path = temp;
                }
            }

            return path;
        }

        private void DrawPathsFooterGUI(){}
    }
}
