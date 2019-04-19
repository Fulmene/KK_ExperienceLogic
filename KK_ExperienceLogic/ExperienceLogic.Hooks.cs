using Harmony;

namespace KK_ExperienceLogic
{
    public partial class ExperienceLogic
    {
        private class Hooks
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(SaveData.Heroine))]
            [HarmonyPatch("HExperience", PropertyMethod.Getter)]
            public static void GetHExperiencePost(SaveData.Heroine __instance, ref SaveData.Heroine.HExperienceKind __result)
            {
                if (__result == SaveData.Heroine.HExperienceKind.不慣れ)
                {
                    float caressBreasts = __instance.hAreaExps[1];
                    float caressVagina = __instance.hAreaExps[2];
                    float caressAnus = __instance.hAreaExps[3];
                    float caressButt = __instance.hAreaExps[4];
                    float caressNipple = __instance.hAreaExps[5];
                    float service = __instance.houshiExp;
                    float pistonVagina = __instance.countKokanH;
                    float pistonAnus = __instance.countAnalH;

                    if (caressBreasts >= 100f && caressButt >= 100f && caressNipple >= 100f && service >= 100f)
                    {
                        if ((caressVagina >= 100f && pistonVagina >= 100f) || (caressAnus >= 100f && pistonAnus >= 100f))
                        {
                            if (__instance.lewdness >= 100)
                                __result = SaveData.Heroine.HExperienceKind.淫乱;
                            else
                                __result = SaveData.Heroine.HExperienceKind.慣れ;
                        }
                    }
                }
            }
        }
    }
}
