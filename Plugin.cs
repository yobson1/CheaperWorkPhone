using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CheaperWorkPhone
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	[BepInProcess("ContrabandPolice.exe")]
	public class CheaperWorkPhone : BaseUnityPlugin
	{
		internal static ManualLogSource Log;

		private void Awake()
		{
			Log = Logger;
			Harmony.CreateAndPatchAll(typeof(Patches));
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
		}
	}
}
