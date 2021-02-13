//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HealthBarComponent healthBar { get { return (HealthBarComponent)GetComponent(GameComponentsLookup.HealthBar); } }
    public bool hasHealthBar { get { return HasComponent(GameComponentsLookup.HealthBar); } }

    public void AddHealthBar(HealthBar newView, float newValue) {
        var index = GameComponentsLookup.HealthBar;
        var component = (HealthBarComponent)CreateComponent(index, typeof(HealthBarComponent));
        component.view = newView;
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHealthBar(HealthBar newView, float newValue) {
        var index = GameComponentsLookup.HealthBar;
        var component = (HealthBarComponent)CreateComponent(index, typeof(HealthBarComponent));
        component.view = newView;
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHealthBar() {
        RemoveComponent(GameComponentsLookup.HealthBar);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHealthBar;

    public static Entitas.IMatcher<GameEntity> HealthBar {
        get {
            if (_matcherHealthBar == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HealthBar);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealthBar = matcher;
            }

            return _matcherHealthBar;
        }
    }
}