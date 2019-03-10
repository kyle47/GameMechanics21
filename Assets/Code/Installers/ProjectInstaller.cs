using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

using Game.Factory;

[CreateAssetMenu(menuName="Installers/ProjectInstaller")]
public class ProjectInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TileFactory>()
            .To<TileFactory>()
            .AsSingle()
            .NonLazy();
    }
}
