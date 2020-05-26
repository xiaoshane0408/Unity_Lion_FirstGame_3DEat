using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    #region 欄位與屬性
    /// <summary>
    /// 玩家變形元件
    /// </summary>
    private Transform player;

    [Header("追蹤速度"), Range(0.1f, 50.5f)]
    public float speed = 1.5f;
    #endregion

    #region 方法
    /// <summary>
    /// 追蹤玩家
    /// </summary>
    private void Track()
    {
        // 攝影機與小明 Y 軸的距離 5.5 - 3 = 2.5
        // 攝影機與小明 Z 軸的距離 -2.5 - 0 = -2.5
        Vector3 posTrack = player.position;
        posTrack.y += 2.5f;
        posTrack.z += -2.5f;

        // 攝影機座標 = 變形.座標
        Vector3 posCam = transform.position;
        // 攝影機座標 = 三維向量.插植(A點,B點,百分比)
        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * Time.deltaTime * speed);
        transform.position = posCam;
    }
    #endregion

    #region 事件
    /* Lerp 插值測試
      public float a = 0;
    public float b = 10000;

    public Vector2 aa = Vector2.zero;
    public Vector2 bb = Vector2.one * 1000;
    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.5f);
        aa = Vector2.Lerp(aa, bb, 0.5f);
    }
    */

    private void Start()
    {
        // 小明物件 = 遊戲物件.找尋("物件名稱").變形
        player = GameObject.Find("小明").transform;
    }

    // 延遲更新：會在 Update 執行後再執行
    // 建議：需要追蹤座標要寫在此事件內
    private void LateUpdate()
    {
        Track();
    }
    #endregion
}
