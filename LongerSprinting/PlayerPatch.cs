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
        __instance.sprintMultiplier = LongerSprint.SprintMultiplyer.Value;
        __instance.movementForce = LongerSprint.BaseMovementSpeed.Value;
        return true;
    }
    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    static void UpdatePostFix(Player ___player, PlayerController __instance) {;
        if (!___player.data.isSprinting && __instance.staminaRegRate !=0f) ___player.data.currentStamina = Math.Clamp((__instance.staminaRegRate * Time.deltaTime) + ___player.data.currentStamina, 0, __instance.maxStamina);
        if (LongerSprint.IsInfinite.Value) ___player.data.currentStamina = __instance.maxStamina;
    }
}
