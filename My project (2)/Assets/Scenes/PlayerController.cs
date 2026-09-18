using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public string playerName = "Player";
    public int hp = 100;
    //적용가능한 수치를 정의 하는 
    //체력 변수이름:hp 담는 값: 100
    public float moveSpeed = 5f;
    //캐릭터 움직임에 대한 이동속도 값
    public float jumpPower = 8f;
    //점프를 하겠다는 것을 공개? (유니티 인스펙터(Inspector)창에 노출되며 다른 스크립트에서 전급가능한)
    public Vector3 startPosition;
    public Transform visual;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    void Start()
        //Start() 스크립트 인스턴스가 생성될 때 가장 먼저 딱 한 번 호출 되는 명령어 다른 오브젝트의 참조를 준비할때 사용
        //게임이 시작될 때 최초 1회 실행되는 (초기화 값/게임 초기세팅 값?)
        //이벤트 함수
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
        //Update() 매 프레임마다 반복해서 호출하는/키보드/마우스 입력 감지 실시간 이동처리
        //실시간 처리를 위한 함수
        //이벤트 함수

    {
        transform.Translate(Vector3.right * moveInput.x
        * moveSpeed * Time.deltaTime);
    }
}

