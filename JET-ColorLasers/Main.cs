using JET.Utility.Modding;
using JET.Utility.Patching;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JET_ColorLasers
{
    public class Main : JetMod
    {
        public static List<Light> LaserLightList = new List<Light>();
        public static List<LaserBeam> LaserBeamList = new List<LaserBeam>();
        protected override void Initialize(IReadOnlyDictionary<Type, JetMod> dependencies, string gameVersion)
        {
            // we start from here
            Debug.Log("JET_ColorLasers Init!");
            InitPatch();
            InitMono();
        }

        void InitPatch()
        {
            HarmonyPatch.Patch<Patch>(); // patching the LaserBeam class
        }
        void InitMono()
        {
            //adding or attaching to mainapplication gameobject
            var maingameobject = GameObject.Find("Application (Main Client)");
            if (maingameobject == null)
            {
                maingameobject = new GameObject("JET_ColorLasersMod");
            }

            //adding our monobehaviour script to the game object
            maingameobject.AddComponent<MonoScript>();
        }
        string Author = "TheMaoci";
    }
}
