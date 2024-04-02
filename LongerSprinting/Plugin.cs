using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;

[BepInPlugin("LongerSprinting", "LongerSprinting", "1.0.0")]
public class LongerSprint : BaseUnityPlugin {
    internal static ConfigEntry<float>? MaxStamina { get; private set; }
    internal static ConfigEntry<float>? StaminaRegenRate { get; private set; }
    private void Awake() {
        // Plugin startup logic

        MaxStamina = Config.Bind("General", "MaxStamina", 50f,
            "How much stamina you have.");
        StaminaRegenRate = Config.Bind("General", "StaminaRegenRate", 10f,
                    "How quickly you regenerate stamina.");
    
        Logger.LogInfo($"Plugin LongerSprinting is loaded!");

        Harmony harmony = new Harmony("sprintLonger");
        harmony.PatchAll();
    }
}
