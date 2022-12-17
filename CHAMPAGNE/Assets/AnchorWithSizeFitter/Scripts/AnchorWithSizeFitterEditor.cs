using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnchorWithSizeFitter))]
public class AnchorWithRectSizeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AnchorWithSizeFitter anchorWithRectSize = (AnchorWithSizeFitter)target;
        if (GUILayout.Button("Set Acnhores"))
        {
            anchorWithRectSize.OnSetAnchores();
        }
    }
}
