using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellButton : MonoBehaviour {
    public int cellIndex;

    private Button button;
    
    private TMP_Text label;
    
    private bool used = false;

    public Image markImage;

    void Start() {
        button = GetComponent<Button>();
        label = GetComponentInChildren<TMP_Text>();

        button.onClick.AddListener(OnClicked);
    }

    void OnClicked() {
        if (used) return;
        if (GameManager.Instance.IsGameOver()) return;

        AudioManager.Instance.PlayCell();
        used = true;

        Sprite spriteToUse = GameManager.Instance.GetCurrentSprite();

        markImage.sprite = spriteToUse;
        markImage.gameObject.SetActive(true);

        UIManager.Instance.RegisterMove(GameManager.Instance.playerOneTurn);
        GameManager.Instance.MakeMove(cellIndex);
    }
}