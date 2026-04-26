
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AutoButtonSound : MonoBehaviour {
    private List<Button> hookedButtons = new List<Button>();

    void Start() {
        StartCoroutine(CheckButtonsRoutine());
    }

    IEnumerator CheckButtonsRoutine() {
        while (true) {
            HookAllButtons();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void HookAllButtons() {
        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button btn in buttons) {

            if (!hookedButtons.Contains(btn)) {
                hookedButtons.Add(btn);

                btn.onClick.AddListener(() =>
                {
                    if (AudioManager.Instance != null)
                        AudioManager.Instance.PlayButton();
                });
            }
        }
    }
}