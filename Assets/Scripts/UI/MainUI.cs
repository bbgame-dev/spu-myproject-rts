using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionMarker;
    public GameObject SelectionMarker { get { return selectionMarker; } }

    //UI for manage Textmeshpro

    [SerializeField] private TextMeshProUGUI unitCountText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI stoneText;


    public static MainUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateAllResource(Faction _faction)
    {
        unitCountText.text = _faction.AliveUnits.Count.ToString();
        foodText.text = _faction.Food.ToString();
        woodText.text = _faction.Wood.ToString();
        goldText.text = _faction.Gold.ToString();
        stoneText.text = _faction.Stone.ToString();

    }
}
