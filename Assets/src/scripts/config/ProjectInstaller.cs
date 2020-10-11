using src.scripts.services.character.arisa.action;
using src.scripts.services.character.arisa.move;
using src.scripts.services.clinet;
using UnityEngine;
using Zenject;

namespace src.scripts.config
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SocketConfiguration>().AsSingle();
            Container.Bind<ClientSender>().To<SocketSender>().AsSingle();
            Container.Bind<CharacterMove>().To<CharacterMoveImpl>().AsSingle();
            Container.Bind<AnimatorAction>().To<AnimatorActionImpl>().AsSingle();
        }
    }
}