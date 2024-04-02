using BepInEx;
using UnityEngine;

[BepInPlugin("LongerSprinting", "LongerSprinting", "1.0.0")]
public class LongerSprint : BaseUnityPlugin {
    private void Awake() {
        // Plugin startup logic
        Logger.LogInfo($"Plugin LongerSprinting is loaded!");
    }
    private void FixedUpdate() {
        PlayerController[] components = GameObject.FindObjectsOfType<PlayerController>();
        for (int i = 0; i < components.Length; i++) {
            PlayerController controller = components[i];
            controller.maxStamina = 100;
            controller.staminaRegRate = 25;
        }
    }
}