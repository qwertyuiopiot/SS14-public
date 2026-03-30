using Content.Shared.Ensnaring;
using Content.Shared.Ensnaring.Components;
using Content.Shared.Trigger.Components.Effects;

namespace Content.Shared.Trigger.Systems;

public sealed class UnensnareOnTriggerSystem : XOnTriggerSystem<UnensnareOnTriggerComponent>
{
    [Dependency] private readonly SharedEnsnareableSystem _ensnareable = default!;

    protected override void OnTrigger(Entity<UnensnareOnTriggerComponent> ent, EntityUid target, ref TriggerEvent args)
    {
        if (!TryComp<EnsnareableComponent>(target, out var ensnareable))
            return;

        // Get all ensnaring items on the target
        var ensnaringItems = new List<EntityUid>();
        foreach (var entity in ensnareable.Container.ContainedEntities)
        {
            if (HasComp<EnsnaringComponent>(entity))
                ensnaringItems.Add(entity);
        }

        // Remove all ensnaring items
        foreach (var ensnare in ensnaringItems)
        {
            if (!TryComp<EnsnaringComponent>(ensnare, out var ensnaring))
                continue;

            _ensnareable.ForceFree(ensnare, ensnaring);
        }

        if (ensnaringItems.Count > 0)
            args.Handled = true;
    }
}