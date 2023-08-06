using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlasticDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
        GameManager.Instance.PlasticChanged += OnPlasticChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
        GameManager.Instance.PlasticChanged -= OnPlasticChanged;
	}

	private void OnPlasticChanged(int newGold)
	{
		UpdateUI(newGold);
	}

	private void UpdateUI()
	{
		UpdateUI(GameManager.Instance.Plastic);
	}
	private void UpdateUI(int value)
	{
		_text.text = $"Paper : {value}";
	}
}