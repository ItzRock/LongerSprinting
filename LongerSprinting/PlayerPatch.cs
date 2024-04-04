using System;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
[HarmonyPatch(typeof(PlayerController))]
class PlayerPatch {
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    static bool Prefix(PlayerController __instance) {
        __instance.maxStamina = LongerSprint.MaxStamina.Value;
        __instance.staminaRegRate = LongerSprint.StaminaRegenRate.Value;
        return true;
    }
    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    static void UpdatePostFix(Player ___player, PlayerController __instance) {
        LongerSprint.logger.LogInfo($"Plugin Update! kys!");
        if (!___player.data.isSprinting) ___player.data.currentStamina = Math.Clamp((__instance.staminaRegRate * Time.deltaTime) + ___player.data.currentStamina, 0, __instance.maxStamina);
    }
}
