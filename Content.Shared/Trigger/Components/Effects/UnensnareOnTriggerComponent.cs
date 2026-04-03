using Robust.Shared.GameStates;

namespace Content.Shared.Trigger.Components.Effects;

/// <summary>
/// Removes ensnaring items (like energy bola) from the entity.
/// If TargetUser is true the user will be unensnared instead.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class UnensnareOnTriggerComponent : BaseXOnTriggerComponent;