using UnityEngine;
using UnityEngine.UI;

public class GimmickController006 : MonoBehaviour
{
	public Text result;     // クリアー表示用テキスト
	Rigidbody rb;           // Rigidbodyコンポーネント保存変数
	public Transform player;// プレーヤーのTransformコンポーネント保存変数
	public float length;    // プレーヤーとギミックブロックの距離の閾値

	void Start()
	{
		rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントを保存
		rb.isKinematic = true;          // ギミックブロックの物理挙動を無効化
	}

	void Update()
	{
		// プレーヤーとギミックの距離を計算
		float d = Vector3.Distance(transform.position, player.position);
		if (length > d)
		{
			rb.isKinematic = false;// ギミックブロックの物理挙動を有効化
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DeadObject")
		{
			result.text = "クリアー";           // クリアー表示
		}
	}
}
