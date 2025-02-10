using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Player Controller
    // 플레이어 이동과 관련된 기능이 구현된 컨트롤러
    [SerializeField] PlayerMoveController moveController;
    #endregion

    #region Unity Event
    #endregion

    #region Move
    private void OnMove(InputValue value)
    {
        Vector2 moveDir = value.Get<Vector2>(); // 현재 이동 방향 구함
        moveController.Move(moveDir);   // 플레이어 좌우 이동 메서드 호출
    }
    #endregion
}