using System;
using HarmonyLib;

[HarmonyPatch(typeof(PlayerController), "Start")]
class PlayerPatch {
    static bool Prefix(PlayerController __instance) {
        __instance.maxStamina = LongerSprint.MaxStamina.Value;
        __instance.staminaRegRate = LongerSprint.StaminaRegenRate.Value;
        return true;
    }
}
