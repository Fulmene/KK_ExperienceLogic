using System.ComponentModel;
using BepInEx;
using Harmony;

namespace KK_ExperienceLogic
{
    [BepInPlugin(GUID, Name, Version)]
    public partial class ExperienceLogic : BaseUnityPlugin
    {
        public const string GUID = "fulmene.experiencelogic";
        public const string Name = "Koikatsu Experience Logic";
        internal const string Version = "1.0";

        [DisplayName("Need to touch only one hole")]
        [Description("Make it so you only need to max the girls' either vaginal caress/piston or anal caress/piston,\n" +
                     "instead of both, to achieve experienced state.")]
        public static ConfigWrapper<bool> SingleHole { get; set; }

        public ExperienceLogic()
        {
            if (Application.productName == "CharaStudio") return;
            
            SingleHole = new ConfigWrapper<bool>("SingleHole", this, true);

            var harmony = HarmonyInstance.Create(GUID);

            if (SingleHole.Value)
                harmony.PatchAll(typeof(ExperienceLogic.Hooks));
        }

    }
}
