using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
        GameManager.Instance.PaperChanged += OnPaperChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
        GameManager.Instance.PaperChanged -= OnPaperChanged;
	}

	private void OnPaperChanged(int newGold)
	{
		UpdateUI(newGold);
	}

	private void UpdateUI()
	{
		UpdateUI(GameManager.Instance.Paper);
	}
	private void UpdateUI(int value)
	{
        _text.text = $"Plastic : {value}";
    }
}