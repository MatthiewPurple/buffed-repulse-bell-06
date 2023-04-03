using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using buffed_repulse_bell_06;
using Il2Cppfacility_H;

[assembly: MelonInfo(typeof(BuffedRepulseBell06), "Buffed Repulse Bell/Estoma (0.6 ver.)", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace buffed_repulse_bell_06;
public class BuffedRepulseBell06 : MelonMod
{
    // After checking if the enemies are low enough level for Repulse Bell/Estoma
    [HarmonyPatch(typeof(nbEncount), nameof(nbEncount.nbCheckEncountLevel))]
    private class Patch
    {
        public static void Postfix(ref int __result)
        {
            __result = 0; // Always decide NOT to trigger the random encounter
        }
    }

    // After getting the skill description
    [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
    private class Patch2
    {
        public static void Postfix(ref int id, ref string __result)
        {
            if (id == 73) __result = "Prevents random \ndemon encounters \nuntil a new Kagutsuchi."; // Estoma's new description
        }
    }

    // After getting the item description
    [HarmonyPatch(typeof(datItemHelp_msg), nameof(datItemHelp_msg.Get))]
    private class Patch3
    {
        public static void Postfix(ref int id, ref string __result)
        {
            if (id == 52) __result = "Prevents random \ndemon encounters \nuntil a new Kagutsuchi."; // Repulse Bell's new description
        }
    }
}
