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
        // Set instance
        Instance = this;
        
        // Init logger
        Logger = base.Logger;
        
        // Patch using Harmony
        PatchAll();
        
        // Report plugin is loaded
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
    
    public void PatchAll()
    {
        if (_isPatched)
        {
            Logger.LogWarning("Already patched!");
            return;
        }
        
        Logger.LogDebug("Patching...");

        _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        _harmony.PatchAll();
        _isPatched = true;
        
        Logger.LogDebug("Patched!");
    }
    
    public void UnpatchAll()
    {
        if (!_isPatched)
        {
            Logger.LogWarning("Already unpatched!");
            return;
        }
        
        Logger.LogDebug("Unpatching...");

        _harmony.UnpatchSelf();
        _isPatched = false;
        
        Logger.LogDebug("Unpatched!");
    }
}