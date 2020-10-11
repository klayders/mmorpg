using UnityEngine;

namespace src.scripts.services.character.arisa.move
{
    public interface CharacterMove
    {
        void moveForward(Transform transform, float speedMove);
        void moveRight(Transform transform, float speedMove);
        void moveLeft(Transform transform, float speedMove);
        void moveBack(Transform transform, float speedMove);
        void move(CharacterController characterController, float speedMove);
    }
}