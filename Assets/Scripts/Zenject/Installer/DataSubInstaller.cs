using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataSubInstaller : Installer<DataSubInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IDataRepo>().To<DataRepo>().AsSingle();
        Container.Bind<IDataServe>().To<DataServe>().AsSingle();
        Container.Bind<IDataStore>().To<DataStore>().AsSingle();
        Container.Bind<IDataManager>().To<DataManager>().FromComponentInHierarchy().AsSingle();
    }
}
