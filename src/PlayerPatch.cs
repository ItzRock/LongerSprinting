using System;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;

namespace LongerSprinting;
[HarmonyPatch(typeof(PlayerController))]
class PlayerPatch {
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    static bool Prefix(PlayerController __instance) {
        if (__instance.GetComponent<Player>() == Player.localPlayer) {
            __instance.maxStamina = LongerSprint.MaxStamina.Value;
            __instance.staminaRegRate = LongerSprint.StaminaRegenRate.Value;
            __instance.sprintMultiplier = LongerSprint.SprintMultiplyer.Value;
            __instance.movementForce = LongerSprint.BaseMovementSpeed.Value;
        }
        return true;
    }
    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    static void UpdatePostFix(PlayerController __instance) {;
        if (__instance.GetComponent<Player>() == Player.localPlayer) {
            if (!Player.localPlayer.data.isSprinting) Player.localPlayer.data.currentStamina = Math.Clamp((__instance.staminaRegRate * Time.deltaTime) + Player.localPlayer.data.currentStamina, 0, __instance.maxStamina);
            if (LongerSprint.IsInfinite.Value) Player.localPlayer.data.currentStamina = __instance.maxStamina;
        }
    }
}
