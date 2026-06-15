using UnityEngine;

public class PlayerController003 : MonoBehaviour
{
	float speed = 5;				// 移動速度(m/s)
	float horizontalArea = 8.5f;	// 左右の移動範囲

    void Start()
    {
        
    }

    void Update()
    {
		// 左右キーの入力情報を取得
		Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxisRaw("Horizontal");

		// 1秒間に約【speed】m/s の速度で移動させる計算式
		transform.position += dir * speed * Time.deltaTime;
		Vector3 pos = transform.position;

		// 行動制限
		pos.x = Mathf.Clamp(pos.x, -horizontalArea, horizontalArea);
		transform.position = pos;
	}
}
