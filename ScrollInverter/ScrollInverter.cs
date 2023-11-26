using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ScrollInverter;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class ScrollInverter : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    public static ScrollInverter Instance { get; private set; }
    private Harmony _harmony;
    private bool _isPatched;
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
}