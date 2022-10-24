using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Meters : MonoBehaviour
{
	public static int peopleEaten = 0;
	public static int companyStanding = 100;
	public static int hunger = -1;
	public TMP_Text hungerText;
	public TMP_Text standingText;
	public TMP_Text certificateText;
	public Image standingMeter;
	public Image standingMeterBkgd;
	public GameObject certificate;

	void Update()
	{
		if (companyStanding <= 0)
		{
			standingText.text = "";
			standingMeter.enabled = false;
			standingMeterBkgd.enabled = false;
			certificateText.text = $"Unprofessional behavior, damage to corporate property (+ responsible for the death of {peopleEaten} employees)";
			certificate.SetActive(true);
		}
		else
		{
			int standingCategory = companyStanding / 20;
			switch (standingCategory)
			{
				case 5: 
				case 4:
					standingText.text = "Employee of the Month";
					break;
				case 3:
					standingText.text = "Solid Employee";
					break;
				case 2:
					standingText.text = "Questionable Employee";
					break;
				case 1:
					standingText.text = "Delinquent Employee";
					break;
				case 0: 
					standingText.text = "Final Written Warning";
					break;
			}
		}
		if (hunger != -1)
		{
			hungerText.text = $"You hunger for {hunger} more people.";
		}
		else
		{
			hungerText.text = "";
		}
		standingMeter.transform.localScale = new Vector3((companyStanding/100f), (companyStanding/100f), (companyStanding/100f));
	}
}
