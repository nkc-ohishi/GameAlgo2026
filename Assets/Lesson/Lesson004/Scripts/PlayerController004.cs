using UnityEngine;

public class PlayerController004 : MonoBehaviour
{
	float speed = 5;                    // 左右移動スピード
	float jumpPower = 1000;             // ジャンプ力
	Rigidbody rb;                       // Rigidbodyコンポーネント保存変数
	Vector2 inputDir = Vector2.zero;    // キー入力方向
	bool isGround = false;              // プレーヤーの下にコライダー付きのオブジェクトがあるかどうか

	void Start()
	{
		rb = GetComponent<Rigidbody>();  // Rigidbodyコンポーネントを保存
	}
	void Update()
	{
		// 左右入力情報を取得（右1，左-1，押されていない時0がinputDir.xに代入される）
		inputDir.x = Input.GetAxisRaw("Horizontal");

		// 左右移動(速度（リニアヴェロシティ）の値を直接変更して左右移動)
		Vector3 vel = rb.linearVelocity;
		vel.x = inputDir.x * speed;
		rb.linearVelocity = vel;

		// 現在位置から下方向に向けてレイ(Ray)を発射し、他のコライダーオブジェクトに当たったかを判定
		isGround = Physics.Raycast(transform.position, Vector3.down, 0.6f);

		// SceneビューでRayを可視化
		Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);

		// Zキーでジャンプ（上下移動）
		if (Input.GetKeyDown(KeyCode.Z) && isGround)
		{
			rb.AddForce(transform.up * jumpPower);
		}
	}
}
