using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
public class MainPlayer : MonoBehaviour
{
    enum PlayerState
    {
        AWAKE,
        IDLE = 0,
        MOVE,
        JUMP,
        CROUCH,

        STUN,
        DEAD,
    }

    //inputValues
    Vector2 inputDir;
    bool isJump,
        isCrouch,
        isAttack,
        isReload;

    [SerializeField]
    Camera playerCam;

    Rigidbody rigidBody;


    [SerializeField]
    float gravity,
        jumpPower,
        moveSpeed,
        accelPower;

    Vector3 moveDir,
        exForce,
        inForce;

    PlayerState state;

    bool isGround;




    void Start()
    {
        gravity = 9.8f;
        jumpPower = 6f;
        moveSpeed = 0;
        accelPower = 10f;

        state = PlayerState.AWAKE;
        inputDir = Vector2.zero;
        moveDir = Vector2.zero;
        rigidBody = GetComponent<Rigidbody>();


    }

    void Update()
    {
        MoveProcess();

    }

    private void MoveProcess()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down,0.2f);
        if (isGround && isJump)
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            state = PlayerState.JUMP;
            isJump = false;
        }
        else if(!isGround)
        {
            //rigidBody.AddForce(Vector3.down * gravity * Time.deltaTime);
        }

        //제동, 방향전환 시간 1초


        //결과
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    #region InputSystemMessageGetter
    void OnJump(InputValue value)
    {
        isJump = true;
        Debug.Log("jump");
    }

    void OnCrouch(InputValue value)
    {
        isCrouch = true;
        Debug.Log("crouch");
    }

    void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        Debug.Log($"move vector<{inputDir}>");
    }
    void OnLook(InputValue value)
    {
        Vector2 lookDir = value.Get<Vector2>();
        

    }
    void OnAttack(InputValue value)
    {
        isAttack = true;
        Debug.Log("attack");
    }
    
    void OnReload(InputValue value)
    {
        isReload = true;
        Debug.Log("reload");
    }
    #endregion
}
