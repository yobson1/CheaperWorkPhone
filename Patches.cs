using HarmonyLib;
using UnityEngine;

namespace CheaperWorkPhone
{
	internal class Patches
	{
		private static readonly int OriginalSupplyVan = -Economy.orderSupplyVan;
		private static readonly int OriginalPrison = -Economy.orderPrisonVan;

		[HarmonyPatch(typeof(PostHouse), "OnUpgraded")]
		[HarmonyPostfix]
		private static void PostHouseUpgraded()
		{
			CheaperWorkPhone.Log.LogInfo("PostHouse upgraded");
			var postHouse = GameObject.FindObjectOfType<PostHouse>();
			var currentLevel = postHouse.GetLevel();

			int newSupplyCost = OriginalSupplyVan - ((currentLevel - 1) * 50);
			int newPrisonCost = OriginalPrison - ((currentLevel - 1) * 125);

			Economy.orderSupplyVan = -newSupplyCost;
			Economy.orderPrisonVan = -newPrisonCost;
			CheaperWorkPhone.Log.LogInfo($"Supply van now costs ${newSupplyCost}, prison van now costs ${newPrisonCost}");
		}
	}
}
