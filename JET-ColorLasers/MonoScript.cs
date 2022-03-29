using System.Collections.Generic;
using UnityEngine;

namespace JET_ColorLasers
{
    class MonoScript : MonoBehaviour
    {
        Color SelectedLaserColor = new Color(1f, 0, 0);

        List<int> removeQueue = new List<int>();

        bool SwitchMenuDisplay = false;
        bool Enable = false;

        private void Update() 
        {
            // handle menu open close
            if (Input.GetKeyUp(KeyCode.F8)) 
            {
                SwitchMenuDisplay = !SwitchMenuDisplay;
            }
            // handle updating color and removing null from list
            if (!Enable) return;
            if (Main.LaserLightList.Count == 0) return;

            for (int i = 0; i < Main.LaserLightList.Count; i++)
            {
                if (Main.LaserLightList[i] == null)
                {
                    // queue to delete - to not move list downwards...
                    //removeQueue.Add(i);
                    continue;
                }
                Main.LaserLightList[i].color = SelectedLaserColor;
            }
            for (int i = 0; i < Main.LaserBeamList.Count; i++)
            {
                if (Main.LaserBeamList[i] == null)
                {
                    // queue to delete - to not move list downwards...
                    //removeQueue.Add(i);
                    continue;
                }
                Main.LaserBeamList[i].LightColor = SelectedLaserColor;
                Main.LaserBeamList[i].PointMaterial.color = SelectedLaserColor;
                Main.LaserBeamList[i].BeamMaterial.color = SelectedLaserColor;
            }
            //if(removeQueue.Count > 0) 
            //{
            //    foreach (var i in removeQueue)
            //    {
            //        Main.LaserLightList.RemoveAt(i);
            //    }
            //}

        }
        Rect windowPosition = new Rect(50, 50, 200, 200);
        Rect DrawWindow = new Rect(0, 0, 200, 20);
        private void OnGUI() 
        {
            if (SwitchMenuDisplay)
            {
                windowPosition = GUI.Window(1, windowPosition, WindowFunction, "");
            }
        }

        void WindowFunction(int index)
        {
            if(index == 1)
            {
                GUI.DragWindow(DrawWindow);
                Enable = GUILayout.Toggle(Enable, "Set all laser colors", GUILayout.Width(200));
                GUILayout.Label("Red", GUILayout.Width(200));
                SelectedLaserColor.r = GUILayout.HorizontalSlider(SelectedLaserColor.r, 0f, 1f);
                GUILayout.Label("Green", GUILayout.Width(200));
                SelectedLaserColor.g = GUILayout.HorizontalSlider(SelectedLaserColor.g, 0f, 1f);
                GUILayout.Label("Blue", GUILayout.Width(200));
                SelectedLaserColor.b = GUILayout.HorizontalSlider(SelectedLaserColor.b, 0f, 1f);
            }
        }
    }
}
