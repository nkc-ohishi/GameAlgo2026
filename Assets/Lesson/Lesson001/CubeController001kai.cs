using UnityEngine;
using UnityEngine.UI;

public class CubeController001kai : MonoBehaviour
{
	public Text info;	// 文字表示UIテキストオブジェクト
    float rotSpeed;		// void Start()の１行上に追加
	bool sw;            // 変数の宣言はUpdateメソッドのコードブロックの外で行う
	int no;
	string[] infotxt =
	{
		"左クリックで回転、右クリックで停止",
		"左クリックで回転、徐々に回転を遅くする",
		"左クリックで回転、停止を繰り返す",
	};

	void Start()
    {
        Debug.Log("CubeController001が実行されました。");
		no = 0;
		info.text = "Lesson001";
	}

	void Update()
	{
		// 実行結果切り替え操作
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			no--;
			no = (no < 0) ? 2 : no--;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			no = (no + 1) % 3;
		}
		// 表示文字を変更
		info.text = infotxt[no];

		if (no == 0)
		{
			// 考えてみよう（左クリックは０，右クリックは１）
			// 左クリックで回転、右クリックで停止    
			if (Input.GetMouseButtonDown(0))
			{
				rotSpeed = 10;
			}
			if (Input.GetMouseButtonDown(1))
			{
				rotSpeed = 0;
			}
			transform.Rotate(0, 0, rotSpeed);
		}
		else if (no == 1)
		{
			// チャレンジ問題（変数を徐々に小さくするには・・・）
			// 左クリックで回転、徐々に回転を遅くする
			if (Input.GetMouseButtonDown(0))
			{
				rotSpeed = 10;
			}
			transform.Rotate(0, 0, rotSpeed);
			rotSpeed *= 0.98f;
		}
		else
		{
			// スーパーチャレンジ問題（自力でスクリプト思いついたらセンスあるね！！）
			// 左クリックで回転、停止を繰り返す
			if (Input.GetMouseButtonDown(0))
			{
				sw = !sw;                   // 「！」NOT 否定 
				rotSpeed = (sw) ? 10 : 0;   // ？：条件演算子
			}
			transform.Rotate(0, 0, rotSpeed);
		}
	}
}
