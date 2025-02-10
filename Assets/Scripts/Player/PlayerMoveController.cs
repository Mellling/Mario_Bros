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

    #region Unity Event
    private void FixedUpdate()
    {
        Move(moveDir);  // 현재 이동 방향으로 이동 처리
        rigid.drag = moveDrag;  // 이동 감속을 위해 Rigidbody에 drag 적용
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
}