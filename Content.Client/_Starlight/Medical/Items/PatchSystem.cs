using Content.Shared._Starlight.Medical.Items.Components;
using Robust.Client.GameObjects;
using Robust.Shared.Utility;

namespace Content.Client._Starlight.Medical.Items;

public sealed partial class PatchSystem : EntitySystem
{
    [Dependency] private SpriteSystem _sprite = default!;

    private static readonly ResPath PatchesRsiPath = new("/Textures/_Starlight/Objects/Specific/Chemistry/patch.rsi");

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<PatchComponent, AfterAutoHandleStateEvent>(OnHandleState);
    }

    private void OnHandleState(EntityUid uid, PatchComponent component, ref AfterAutoHandleStateEvent args)
    {
        if (!TryComp(uid, out SpriteComponent? sprite))
            return;

        if (!_sprite.TryGetLayer((uid, sprite), 0, out var layer, false))
            return;

        _sprite.LayerSetRsi(layer, PatchesRsiPath, $"bandaid{component.PatchType + 1}");
    }
}
