using UnityEngine;

public class MapCreate004 : MonoBehaviour
{
	public GameObject[] mapObject;          // マップ用オブジェクトをUnityエディタでセット
	Vector2 mapCnt = new Vector2(20, 5);    // オブジェクトを並べる数

	// マップ番号（９は何も配置しない場所）
	int[,] mapNo ={
		{ 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
		{ 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
		{ 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
		{ 1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1 },
		{ 1,2,3,9,9,1,2,3,0,0,1,2,3,0,0,1,2,3,9,1 },
	};

	void Start()
	{
		Vector3 offset = new Vector3(-8.5f, 2.5f, 0);  // マップの左上のオブジェクト座標

		// マップの作成
		for (int y = 0; y < mapCnt.y; y++)
		{
			for (int x = 0; x < mapCnt.x; x++)
			{
				if (mapNo[y, x] > 8) continue; // 配置オブジェクトを種類を８種類まで増やせる想定

				// 表示する位置を計算し、mapNoの数値に合わせて設定したオブジェクトを生成＆配置する
				Vector3 pos = offset + new Vector3(x, -y, 0);
				GameObject obj = Instantiate(mapObject[mapNo[y, x]], pos, Quaternion.identity);

				// 生成されたブロックオブジェクトの親オブジェクトを
				// このスクリプトがアタッチされているオブジェクトに設定し、
				// ヒエラルキーにできるオブジェクトをまとめる
				obj.transform.parent = transform;
			}
		}
	}
}
