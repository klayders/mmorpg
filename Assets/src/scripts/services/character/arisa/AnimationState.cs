using System;
using src.scripts.services.character.arisa.action;
using src.scripts.services.character.arisa.move;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AnimationState : MonoBehaviour
{
    public float speedMove;
    public GameObject ragdoll;
    public Image HP;


    private CharacterController characterController;
    private Animator animator;

    private CharacterMove characterMove;
    private AnimatorAction animatorAction;

    [Inject]
    public void Setup(CharacterMove characterMove, AnimatorAction animatorAction)
    {
        this.characterMove = characterMove;
        this.animatorAction = animatorAction;
    }

    // Use this for initialization
    void Start()
    {
        HP.fillAmount = 0.1f;

        animator = gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        speedMove = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animatorAction.doCrouch(animator);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animatorAction.doIdle(animator);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animatorAction.doAttack(animator);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorAction.doJump(animator);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animatorAction.doDive(animator);
        }

        if (Input.GetKey(KeyCode.W))
        {
            characterMove.moveForward(transform, speedMove);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterMove.moveBack(transform, speedMove);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterMove.moveLeft(transform, speedMove);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterMove.moveRight(transform, speedMove);
        }

        characterMove.move(characterController, speedMove);
        animatorAction.doMove(animator);

    }

    void OnTriggerStay(Collider other)
    {
        // animatorAction.onTriggerState(other, HP, gameObject, ragdoll);
        if (other.CompareTag("Dead"))
        {
            HP.fillAmount -= Time.deltaTime/10f;

            if (HP.fillAmount <= 0)
            {
                Debug.Log("ARISA IS DEAD");
                gameObject.SetActive(false);
                var currentTransform = transform;
                Instantiate(ragdoll, currentTransform.position, currentTransform.rotation);
            }
        }
    }

    void FixedUpdate()
    {

        // if (socketConfiguration is null)
        // {
        //     Debug.LogError("SOCKET NOT STARTED");
        // }
        // else
        // {
        //     PlayerCoordinats playerCoordinats = new PlayerCoordinats();
        //     playerCoordinats.x = x;
        //     playerCoordinats.y = y;
        //     m_ClientSender.sendMessage(playerCoordinats);
        // }
    }


    [Serializable]
    public class PlayerCoordinats
    {
        public float x;
        public float y;
    }
}