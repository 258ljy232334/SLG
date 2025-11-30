using UnityEngine;
using Zenject;

public class RootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITimeManager>().To<TimeManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IHotelManager>().To<HotelManager>().FromComponentInHierarchy().AsSingle();

        //子系统注入Inventory
        InventorySubInstaller.Install(Container);
        DataSubInstaller.Install(Container);
    }
}
