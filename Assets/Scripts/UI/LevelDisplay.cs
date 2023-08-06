using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
        GameManager.Instance.LevelChanged += OnLevelChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
        GameManager.Instance.LevelChanged -= OnLevelChanged;
	}

	private void OnLevelChanged(int newLevel)
	{
		UpdateUI(newLevel);
	}

	private void UpdateUI()
	{
		UpdateUI(GameManager.Instance.Level);
	}
	private void UpdateUI(int value)
	{
		_text.text = "Level: " + (value + 1);
	}
}
