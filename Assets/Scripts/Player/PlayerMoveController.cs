using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Header("Player Move")]
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDrag = 2f;
    [SerializeField] float maxMoveVel;
    [SerializeField] Rigidbody2D rigid;
    Vector2 moveDir;

    [Header("Player Jump")]
    [SerializeField] float jumpSpeed;
    [SerializeField] float maxJumpVel;
    [SerializeField] LayerMask groundMask;
    bool isJumping = false;

    #region Unity Event
    private void Start()
    {
        rigid.drag = moveDrag;  // 이동 감속을 위해 Rigidbody에 drag 적용
    }

    private void FixedUpdate()
    {
        Move(moveDir);  // 현재 이동 방향으로 이동 처리
    }
    #endregion

    #region Move
    /// <summary>
    /// 플레이어의 좌우 움직임을 처리하는 메서드
    /// </summary>
    /// <param name="moveDir">
    /// 이동 방향을 나타내는 벡터 값 
    /// (X 값이 음수면 왼쪽, 양수면 오른쪽)
    /// </param>
    public void Move(Vector2 moveDir)
    {
        this.moveDir = moveDir; // 현재 이동 방향 저장

        // 현재 속도가 최대 속도(maxMoveVel) 이하인 경우에만 힘을 가한다.
        if (Mathf.Abs(rigid.velocity.x) <= maxMoveVel)
            // Time.deltaTime을 곱해 프레임 독립적인 움직임 구현
            rigid.AddForce(moveDir * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
    #endregion

    #region Jump
    /// <summary>
    /// 캐릭터가 점프할 수 있는 상태일 때 점프를 실행하는 메서드.
    /// 플레이어가 한 번만 점프하도록 구현함.
    /// </summary>
    public void Jump()
    {
        // 점프 중이 아니고, 현재 y축 속도가 maxJumpVel 이하일 때만 점프 가능
        if (!isJumping && Mathf.Abs(rigid.velocity.y) <= maxJumpVel)
        {
            isJumping = true;   // 점프 중으로 표시
            // 위쪽 방향(transform.up)으로 jumpSpeed만큼의 힘을 가해 점프 실행
            // ForceMode2D.Impulse: 순간적인 힘을 가하는 모드 (점프할 때 적절함)
            rigid.AddForce(transform.up * jumpSpeed , ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // isJumping이 true이고, 충돌한 오브젝트의 레이어가 groundMask에 포함되어 있을 경우
        if (isJumping && groundMask.Contain(collision.gameObject.layer))
            isJumping = false;  // isJumping을 flase로 바꿔주어 다시 점프할 수 있도록 함
    }
    #endregion
}