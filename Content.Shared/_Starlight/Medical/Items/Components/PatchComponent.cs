using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared._Starlight.Medical.Items.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
public sealed partial class PatchComponent : Component
{
    /// <summary>
    /// The patch sprite ID, selected in the ChemMaster.
    /// </summary>
    [AutoNetworkedField]
    [DataField("patchType")]
    [ViewVariables(VVAccess.ReadWrite)]
    public uint PatchType;

    [DataField]
    public string SolutionContainer = "patch";

        /// <summary>
        /// How long it takes to apply patch.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("delay")]
        public float Delay = 3f;

        /// <summary>
        ///     Sound played on apply begin
        /// </summary>
        [DataField("healingBeginSound")]
        public SoundSpecifier? ApplyBeginSound = null;

        /// <summary>
        ///     Sound played on apply end
        /// </summary>
        [DataField("healingEndSound")]
        public SoundSpecifier? ApplyEndSound = null;
}
