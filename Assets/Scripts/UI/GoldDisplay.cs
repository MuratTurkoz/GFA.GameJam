using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
        GameManager.Instance.GoldChanged += OnGoldChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
        GameManager.Instance.GoldChanged -= OnGoldChanged;
	}

	private void OnGoldChanged(int newGold)
	{
		UpdateUI(newGold);
	}

	private void UpdateUI()
	{
		UpdateUI(GameManager.Instance.Gold);
	}
	private void UpdateUI(int value)
	{
        _text.text = $"Gold : {value}";
    }
}