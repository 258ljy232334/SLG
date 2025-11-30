using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventorySubInstaller : Installer<InventorySubInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IInventoryCatalog>().To<InventoryCatalog>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IInventoryRepository>().To<InventoryRepository>().FromComponentInHierarchy().AsSingle();
        // 2. 服务层
        Container.Bind<IInventoryServe>().To<InventoryServe>().FromComponentInHierarchy().AsSingle();

        // 3. 管理层（MonoBehaviour，需要场景里已有）
        Container.Bind<IInventoryManager>().To<InventoryManager>().FromComponentInHierarchy().AsSingle();
    }
}
