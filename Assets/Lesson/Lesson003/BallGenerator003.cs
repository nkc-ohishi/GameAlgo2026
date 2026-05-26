using UnityEngine;

public class BallGenerator003 : MonoBehaviour
{
	[SerializeField] GameObject ballPre;// Unityエディタでプレハブをセットする
	float span = 1f;                    // ボールを生成する間隔
	float delta = 0;                    // 時間計算用変数

	void Start()
    {
		span = 1f;
		delta = 0;
	}

	void Update()
    {
		if (GameDirector003.gameFlg != 0) return;

		delta += Time.deltaTime;
		if (delta > span)
		{
			delta = 0;
			GameObject obj = Instantiate(ballPre);
			float px = Random.Range(-8, 9);
			obj.transform.position = new Vector3(px, 7, 0);
		}

		// 150フレーム毎にボールを生成する感覚を0.05秒ずつ減らす
		if (Time.frameCount % 150 == 0)
		{
			span -= 0.05f;
			span = Mathf.Max(span, 0.1f);
		}
	}
}
