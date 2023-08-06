using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SteelDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
        GameManager.Instance.SteelChanged += OnSteelChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
        GameManager.Instance.SteelChanged -= OnSteelChanged;
	}

	private void OnSteelChanged(int newGold)
	{
		UpdateUI(newGold);
	}

	private void UpdateUI()
	{
		UpdateUI(GameManager.Instance.Steel);
	}
	private void UpdateUI(int value)
	{
        _text.text = $"Steel : {value}";
    }
}