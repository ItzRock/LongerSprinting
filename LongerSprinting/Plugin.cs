using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;

[BepInPlugin("LongerSprinting", "LongerSprinting", "1.0.3")]
public class LongerSprint : BaseUnityPlugin {
    internal static ConfigEntry<float>? MaxStamina { get; private set; }
    internal static ConfigEntry<float>? StaminaRegenRate { get; private set; }
    internal static ConfigEntry<bool>? IsInfinite { get; private set; }
    internal static ConfigEntry<float>? SprintMultiplyer { get; private set; }
    internal static ConfigEntry<float>? BaseMovementSpeed { get; private set; }


    public static BepInEx.Logging.ManualLogSource logger { get; private set; }
    private void Awake() {
        // Plugin startup logic
        logger = Logger;
        MaxStamina = Config.Bind("General", "MaxStamina", 20f,
            "The maximum amount of stamina you have in game, The default without the mod is 10.");
        StaminaRegenRate = Config.Bind("General", "StaminaRegenRate", 2f,
                    "How quickly you regenerate stamina. This is added on the base stamina regen so if you wanted to not regenerate any extra stamina you may set this to 0");

        SprintMultiplyer = Config.Bind("General", "SprintMultiplyer", 2.3f,
            "How fast you sprint.");
        BaseMovementSpeed = Config.Bind("General", "BaseMovementSpeed", 17f,
                    "How Fast you walk.");

        IsInfinite = Config.Bind("General", "IsInfinite", false,
                    "Are you able to sprint forever?");
        Logger.LogInfo($"Plugin LongerSprinting is loaded! v1.0.3");

        Harmony harmony = new Harmony("sprintLonger");
        harmony.PatchAll();
    }
}
