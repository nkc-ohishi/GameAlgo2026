using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector003 : MonoBehaviour
{
	[SerializeField] Text hpLabel;
	[SerializeField] Text titleLabel;
	public static int hp = 100;     // 他のスクリプトでも利用したいのでstaticで宣言
	public static int gameFlg = 0;  // 他のスクリプトでも利用したいのでstaticで宣言

	void Start()
	{
		Application.targetFrameRate = 60;
		gameFlg = 99;
		hp = 100;
		titleLabel.text = "EVASION\nEnterキーでスタート";
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit(); //ゲームプレイ終了
		}

		if (gameFlg == 99)
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				gameFlg = 0;
				titleLabel.text = "";
			}
			return;
		}

		if (gameFlg == 1)
		{
			titleLabel.text = "GAME OVER";
			if (Input.GetKeyDown(KeyCode.Return))
			{
				gameFlg = 0;
				SceneManager.LoadScene(0);
			}
			return;
		}

		if (hp < 0)
		{
			gameFlg = 1;
			hp = 0;
		}
		hpLabel.text = "HP = " + hp.ToString("D5");
	}
}
