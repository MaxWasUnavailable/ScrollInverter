using System.Collections.Generic;
using System.Reflection.Emit;
using GameNetcodeStuff;
using HarmonyLib;

namespace ScrollInverter.Patches;

/// <summary>
///     Harmony patches for the <c>PlayerControllerB</c> class.
/// </summary>
[HarmonyPatch(typeof(PlayerControllerB))]
public class PlayerControllerBPatches
{
    /// <summary>
    ///     Patch the <see cref="PlayerControllerB.SwitchItem_performed" /> method to invert the scroll direction.
    /// </summary>
    /// <param name="instructions">An <c>IEnumerable</c> of <c>CodeInstruction</c> instances.</param>
    [HarmonyPatch("SwitchItem_performed")]
    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> InvertControlsSwitchItemPerformed(
        IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .SearchForward(instruction => instruction.opcode.Name == OpCodes.Ble_Un.Name)
            .ThrowIfInvalid("Could not find branch instruction")
            .SetOpcodeAndAdvance(OpCodes.Bge_Un_S)
            .InstructionEnumeration();
    }
}