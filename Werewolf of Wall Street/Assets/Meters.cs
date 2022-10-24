using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Meters : MonoBehaviour
{
	public static int companyStanding = 100;
	public static int hunger = -1;
	public TMP_Text hungerText;

	void Update()
	{
		if (hunger != -1)
		{
			hungerText.text = $"You hunger for {hunger} more people.";
		}
		else
		{
			hungerText.text = "";
		}
	}
}
