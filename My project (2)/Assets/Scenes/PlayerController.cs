using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public string playerName = "Player";
    public int hp = 100;
    public float moveSpeed = 5f;
    public float jumpPower = 8f;
    public Vector3 startPosition;
    public Transform visual;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPosition;
        Debug.Log(playerName + " 시작. 체력 " + hp);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //if는 조건문 (조건이 맞을 때만 중괄호 안을 실행?
        //moveInput 선언
        if (moveInput.x > 0) 
        //조건
        { visual.localScale = new Vector3(1, 1, 1); }
            //조건이 맞을 떄 실행 되는 코드
        else if (moveInput.x < 0)
        //다른조건
        { visual.localScale = new Vector3(-1, 1, 1); }
    }
          //앞 조건은 틀리고 이 조건이 맞을 때 실행되는 코드
          //해당 코드를 활용하여 키의 입력에 따른 좌우반전 효과적용
    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("점프!");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }
    //점프로그 
    void Update()
    {
        transform.Translate(Vector3.right * moveInput.x
        * moveSpeed * Time.deltaTime);
    }
}
