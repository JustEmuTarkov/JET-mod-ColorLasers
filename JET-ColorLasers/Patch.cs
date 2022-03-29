using JET.Utility.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JET_ColorLasers
{
    /// <summary>
    /// Patch attaches itself to method_0 in LaserBeam class and adds lights created in it to the static list
    /// </summary>
    class Patch : GenericPatch<Patch>
    {
        public Patch() : base(postfix: nameof(PatchPostfix)) { }
        protected override MethodBase GetTargetMethod()
        {
            return typeof(LaserBeam).GetMethod("method_0", BindingFlags.NonPublic | BindingFlags.Instance);
        }
        public static void PatchPostfix(ref Light ___light_0, ref LaserBeam __instance)
        {
            Main.LaserLightList.Add(___light_0);
            Main.LaserBeamList.Add(__instance);
        }
    }
}
