using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;       // 変数の型 Textを利用する為に必要

public class PlayerController002 : MonoBehaviour
{
    public Text distanceLabel;  // 変数の宣言はUpdateメソッドのコードブロックの外で行う
	public GameObject goal;     // 変数の宣言はUpdateメソッドのコードブロックの外で行う

	Vector2 mouseDownPos, mouseUpPos;
	float speed; // 変数の宣言はUpdateメソッドのコードブロックの外で行う

	int gameflg;

	void Start()
    {
		Application.targetFrameRate = 60;
		gameflg = 0;
	}

    void Update()
    {
		// 右クリックで再スタート
		if(Input.GetMouseButtonDown(1))
		{
			SceneManager.LoadScene(0);
		}

		transform.Translate(speed, 0, 0);
		speed *= 0.98f;

		// 距離計算
		float distance = goal.transform.position.x - transform.position.x;
		string result = "スワイプチキン 0.5m\nDistance:" + distance.ToString("F2") + "m";
		distanceLabel.text = result;

		if (distance < 0)
		{
			distanceLabel.text = result + "失敗\n右クリックで再スタート";
		}
		else if (speed < 0.001f && gameflg == 1)
		{
			if (distance > 0.5f)
			{
				distanceLabel.text = result + "失敗\n右クリックで再スタート";
			}
			else
			{
				distanceLabel.text = result + "成功\n右クリックで再スタート";
			}
		}

		if (gameflg == 1)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			mouseDownPos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0))
		{
			mouseUpPos = Input.mousePosition;
			float length = mouseUpPos.x - mouseDownPos.x;
			speed = length / 1000.0f;
			gameflg = 1;
		}

	}
}
