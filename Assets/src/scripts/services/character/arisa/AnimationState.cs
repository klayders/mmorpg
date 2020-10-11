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
    public Image Enrgy;
    public Text HPBottleText;
    public float HPBottle;

    public GameObject skill1;

    public float collDown;

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
        HP.fillAmount = 0.7f;
        Enrgy.fillAmount = 0.7f;

        animator = gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        speedMove = 3;
    }

    // Update is called once per frame
    void Update()
    {
        collDown -= Time.deltaTime;
        Enrgy.fillAmount += Time.deltaTime / 50f;

        if (HP.fillAmount > 1f)
        {
            HP.fillAmount = 1f;
        }

        if (Enrgy.fillAmount > 1f)
        {
            Enrgy.fillAmount = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && collDown < 0 && Enrgy.fillAmount > 0.3f)
        {
            var currentTransform = transform;
            Instantiate(skill1, currentTransform.position, currentTransform.rotation);
            collDown = 2f;
            Enrgy.fillAmount -= 0.3f;
        }

        HPBottleText.text = "" + HPBottle;

        if (Input.GetKeyDown(KeyCode.E) && HPBottle > 0 && HP.fillAmount < 1f)
        {
            HP.fillAmount += 0.45f;
            HPBottle -= 1;
            animatorAction.doDrink(animator);
        }


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
            HP.fillAmount -= Time.deltaTime / 10f;

            if (HP.fillAmount <= 0)
            {
                Debug.Log("ARISA IS DEAD");
                gameObject.SetActive(false);
                var currentTransform = transform;
                Instantiate(ragdoll, currentTransform.position, currentTransform.rotation);
            }
        }

        if (other.CompareTag("HPBottle") && Input.GetKeyDown(KeyCode.F))
        {
            HPBottle = HPBottle + 1f;
            animatorAction.doPick(animator);
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