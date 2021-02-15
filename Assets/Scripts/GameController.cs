using System;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    private Systems systems;

    void Awake()
    {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGlobals(Camera.main.transform);

        systems = new Systems();
        systems.Add(new PrefabInstantiateSystem(contexts));
        systems.Add(new TransformApplySystem(contexts));
        systems.Add(new CharacterInitSystem(contexts));
        systems.Add(new LookAtSystem(contexts));
        systems.Add(new HealthBarSystem(contexts));
        systems.Add(new CharacterSelectSystem(contexts));
        systems.Add(new PlayerInputSystem(contexts));
        systems.Add(new MoveToSystem(contexts));
        systems.Add(new DeathSystem(contexts));
        systems.Add(new CharacterStateSystem(contexts));
        systems.Add(new EndGameCheckSystem(contexts));
        systems.Initialize();
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
