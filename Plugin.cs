using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SharedHealthPacks.Patches;

namespace SharedHealthPacks
{
    [BepInPlugin(mod_guid, mod_name, mod_version)]
    public class TeamBoostersBase : BaseUnityPlugin
    {
        private const string mod_guid = "Cuajitox.REPO.SharedHealthPacks";
        private const string mod_name = "R.E.P.O SharedHealthPacks";
        private const string mod_version = "1.0.0";
        private readonly Harmony harmony = new Harmony(mod_guid);
        private static TeamBoostersBase instance;
        internal ManualLogSource mls;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(mod_guid);
            mls.LogInfo("SharedHealthPacks mod has been activated");
            harmony.PatchAll(typeof(TeamBoostersBase));
            harmony.PatchAll(typeof(ItemHealthPackUpdatePatch));
        }
    }
}
