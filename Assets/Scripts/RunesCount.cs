using UnityEngine;
using TMPro;

public class RunesCount : MonoBehaviour
{
	[Header("Runes Count")]
	[SerializeField] TMP_Text _waterRuneCountText;
	[SerializeField] TMP_Text _earthRuneCountText;
	[SerializeField] TMP_Text _fireRuneCountText;

	[Space(1)]
	[Header("Game Manager")]
	[SerializeField] private GameManager _gameManager;


	#region Properties
	[Space(1)]
	[Header("Runes Limits")]
	[SerializeField] private int _waterRuneLimit = 3;
	public int WaterRuneLimit { get { return this._waterRuneLimit; } }

	[SerializeField] private uint _earthRuneLimit = 1;
	public uint EarthRuneLimit { get { return this._earthRuneLimit; } }

	[SerializeField] private uint _fireRuneLimit = 3;
	public uint FireRuneLimit { get { return this._fireRuneLimit; } }
	#endregion


	// Update is called once per frame
	void Update()
	{
		Debug.Log(WaterRuneLimit);
		// numbers of water runes found / number of water runes to find
		_waterRuneCountText.text = $"{_gameManager.waterRuneTrigger.WaterRuneCount}/{WaterRuneLimit}";

		// numbers of earth runes found / number of earth runes to find
		_earthRuneCountText.text = $"{_gameManager.earthRuneTrigger.EarthRuneCount}/{EarthRuneLimit}";

		// numbers of fire runes found / number of fire runes to find
		_fireRuneCountText.text = $"{_gameManager.fireRuneTrigger.FireRuneCount}/{FireRuneLimit}";
	}

	/// <summary>
	/// If all water runes are found,
	/// makes the water chest appear
	/// </summary>
	/// <param name="waterPuzzleChest"></param>
	public void WaterRunesFound(GameObject waterPuzzleChest)
	{
		if (waterPuzzleChest.activeSelf)
			return;

		if (_gameManager.waterRuneTrigger.WaterRuneCount == WaterRuneLimit)
		{
			waterPuzzleChest.SetActive(true);
		}
	}

	/// <summary>
	/// If all earth runes are found,
	/// makes the earth chest appear
	/// </summary>
	/// <param name="earthPuzzleChest"></param>
	public void EarthRunesFound(GameObject earthPuzzleChest)
	{
		if (earthPuzzleChest.activeSelf)
			return;

		if (_gameManager.earthRuneTrigger.EarthRuneCount == EarthRuneLimit)
		{
			earthPuzzleChest.SetActive(true);
		}
	}

	/// <summary>
	/// If all fire runes are found,
	/// makes the fire chest appear
	/// </summary>
	/// <param name="firePuzzleChest"></param>
	public void FireRunesFound(GameObject firePuzzleChest)
	{
		if (firePuzzleChest.activeSelf)
			return;

		if (_gameManager.fireRuneTrigger.FireRuneCount == FireRuneLimit)
		{
			firePuzzleChest.SetActive(true);
		}
	}
}
