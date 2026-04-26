using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StrikeEffect : MonoBehaviour {

    public Image image;

    public Sprite[] frames;

    public float frameTime = 0.08f;

    void Start() {
        image.enabled = false;
    }

    public void PlayEffect() {
        StartCoroutine(Animate());
    }

    IEnumerator Animate() {
        image.enabled = true;

        for (int i = 0; i < frames.Length; i++) {
            image.sprite = frames[i];
            yield return new WaitForSeconds(frameTime);
        }

        image.enabled = false;
    }
}