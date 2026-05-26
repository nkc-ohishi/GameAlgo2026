using UnityEngine;

public class BallController003 : MonoBehaviour
{
	float dropSpeed = -0.1f;
	float deadLine = -5f;

	void Start()
    {
        
    }

    void Update()
    {
		// フレームごとに等速で落下する
		transform.Translate(0, dropSpeed, 0);

		// 画面外に出たらボールを削除する
		if (transform.position.y <= deadLine)
		{
			Destroy(this.gameObject);
		}
	}

	// オブジェクトに追加されているトリガーコライダーに
	// 他のコライダーが重なった瞬間に呼ばれる特殊なメソッド
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			GameDirector003.hp -= Random.Range(10, 31);
			Destroy(this.gameObject);
		}
	}

}
