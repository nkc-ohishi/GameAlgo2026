using UnityEngine;
using UnityEngine.UI;

public class PlayerController006 : MonoBehaviour
{
	float speed = 5;                    // 左右移動スピード
	float jumpPower = 1000;             // ジャンプ力
	Rigidbody rb;                       // Rigidbodyコンポーネント保存変数
	Vector2 inputDir = Vector2.zero;    // キー入力方向
	bool isGround = false;              // プレーヤーの下にコライダー付きのオブジェクトがあるかどうか

	// HPゲージ
	public Text hpText;
	public Image img;
	const float MAX_HP = 1000;
	float now_hp = 1000;
	bool damageflg = false;


	void Start()
	{
		rb = GetComponent<Rigidbody>();  // Rigidbodyコンポーネントを保存
		damageflg = false;
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

		if (!damageflg)
		{
			// HP自然回復
			now_hp += 1;
			now_hp = Mathf.Min(now_hp, MAX_HP);
		}

		img.fillAmount = now_hp / MAX_HP;
		hpText.text = "HP = " + now_hp.ToString("0000");
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "DeadObject" && damageflg)
		{
			now_hp -= Random.Range(10, 20);
			now_hp = Mathf.Max(now_hp, 0);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DeadObject")
		{
			damageflg = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "DeadObject")
		{
			damageflg = false;
		}
	}

}
