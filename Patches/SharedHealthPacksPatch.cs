using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace SharedHealthPacks.Patches
{
    [HarmonyPatch(typeof(ItemHealthPack), nameof(ItemHealthPack.OnDestroy))]
    public static class ItemHealthPackUpdatePatch
    {
        [HarmonyPostfix]
        public static void Postfix(ItemHealthPack __instance)
        {
            List<PlayerAvatar> players = SemiFunc.PlayerGetAll();
            foreach (PlayerAvatar player in players)
            {
                player.playerHealth.HealOther(__instance.healAmount, effect: true);
            }
        }
    }
}
