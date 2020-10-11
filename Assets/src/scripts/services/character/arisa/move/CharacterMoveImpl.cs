using UnityEngine;

namespace src.scripts.services.character.arisa.move
{
    public class CharacterMoveImpl : CharacterMove
    {
        public void moveForward(Transform transform, float speedMove)
        {
            var x = Input.GetAxis("Vertical");

            var rotation = transform.rotation;
            rotation = Quaternion.Lerp(
                rotation,
                Quaternion.Euler(0, rotation.y, 0),
                0.2f
            );
            transform.rotation = rotation;
            transform.Translate(Vector3.forward * (speedMove * x * Time.deltaTime));
        }

        public void moveRight(Transform transform, float speedMove)
        {
            var y = Input.GetAxis("Horizontal");

            var rotation = transform.rotation;
            rotation = Quaternion.Lerp(
                rotation,
                Quaternion.Euler(0, rotation.y + 90, 0),
                0.2f
            );
            transform.rotation = rotation;
            transform.Translate(Vector3.forward * (speedMove * y * Time.deltaTime));
        }

        public void moveLeft(Transform transform, float speedMove)
        {
            var y = Input.GetAxis("Horizontal");

            var rotation = transform.rotation;
            rotation = Quaternion.Lerp(
                rotation,
                Quaternion.Euler(0, rotation.y - 90, 0),
                0.2f
            );
            transform.rotation = rotation;
            transform.Translate(-Vector3.forward * (speedMove * y * Time.deltaTime));
        }

        public void moveBack(Transform transform, float speedMove)
        {
            var x = Input.GetAxis("Vertical");

            var rotation = transform.rotation;
            rotation = Quaternion.Lerp(
                rotation,
                Quaternion.Euler(0, rotation.y + 180, 0),
                0.2f
            );
            transform.rotation = rotation;
            transform.Translate(-Vector3.forward * (speedMove * x * Time.deltaTime));
        }

        public void move(CharacterController characterController, float speedMove)
        {
            var vector3 = Vector3.zero;
            vector3.x = Input.GetAxis("Horizontal") * speedMove;
            vector3.z = Input.GetAxis("Vertical") * speedMove;
            vector3.y = (float) -9.81;
            characterController.Move(vector3 * Time.deltaTime);
        }
    }
}