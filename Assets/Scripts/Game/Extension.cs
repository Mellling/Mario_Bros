using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    /// <summary>
    /// 주어진 레이어(Layer)가 해당 LayerMask에 포함되어 있는지 확인하는 확장 메서드.
    /// </summary>
    /// <param name="layerMask">비교할 LayerMask</param>
    /// <param name="layer">확인할 레이어 (int 값, 0~31)</param>
    /// <returns>해당 레이어가 LayerMask에 포함되어 있으면 true, 아니면 false</returns>
    public static bool Contain(this LayerMask layerMask, int layer)
    {
        // 1을 layer만큼 왼쪽으로 이동(Shift)하여 해당 레이어의 비트값을 생성
        // 그 값을 layerMask와 AND 연산하여 포함 여부를 확인
        return ((1 << layer) & layerMask) != 0;
    }
}