using BepInEx;
using BepInEx.Configuration;
using UnityEngine;


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
    }
    // This a really bad way of doing this for like 2 reasons. However to make this a quick fix / mod I've done it like this.
    private void FixedUpdate() {
        PlayerController[] components = GameObject.FindObjectsOfType<PlayerController>();
        for (int i = 0; i < components.Length; i++) {
            PlayerController controller = components[i];
            controller.maxStamina = MaxStamina.Value;
            controller.staminaRegRate = StaminaRegenRate.Value;
        }
    }
}