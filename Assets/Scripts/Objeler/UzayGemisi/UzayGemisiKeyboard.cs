using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKeyboard
{
    public UzayGemisi uzayGemisi;

	public UzayGemisiKeyboard(UzayGemisi uzayGemisi)
	{
		this.uzayGemisi = uzayGemisi;
	}

	public void HandleControls()
	{
		uzayGemisi.thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

		uzayGemisi.turning = 0;
		if (Input.GetKey(KeyCode.A)) 
		{
			uzayGemisi.turning = 1;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			uzayGemisi.turning = -1;
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			uzayGemisi.KursunAtesEt();
		}
		
	}


}
