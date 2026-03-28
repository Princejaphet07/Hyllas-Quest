using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitEntrance : MonoBehaviour {

    [SerializeField] private ExitEntranceSO sceneTransitionRule;
    [SerializeField] private Transform entrancePoint;
    [SerializeField] private AudioSource portalAudio; 
    
    // Gi-SerializeField para puyde nimo usbon sa Inspector (e.g., 5 o 7)
    [SerializeField] private float waitToLoadNewScene = 5f; 

    private void Start () {
        if (sceneTransitionRule != null && sceneTransitionRule.sceneExitName == MySceneManagement.Instance.SceneTransitionName) {
            Player.Instance.transform.position = entrancePoint.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            RoutineManager.Instance.SetIsAlive(true);
            FadeScreenUI.Instance.FadeScreen(targetAlpha: 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Player>() || collision.CompareTag("Player")) {
            
            Debug.Log("Player detected! Starting transition...");

            if (portalAudio != null) {
                portalAudio.Play();
                Debug.Log("Playing Portal Sound");
            }

            if (MySceneManagement.Instance != null && FadeScreenUI.Instance != null) {
                MySceneManagement.Instance.SetSceneTransitonName(sceneTransitionRule.sceneLeadToExitName);
                
                // Ang Fade Screen UI mahimong mo-fade sulod sa 1 second (default)
                // Ang loading magpaabot pa sa waitToLoadNewScene value
                FadeScreenUI.Instance.FadeScreen(targetAlpha: 1f);
                StartCoroutine(LoadSceneRoutine());
            }
        }
    }

    private IEnumerator LoadSceneRoutine() {
        // Diri siya magpaabot. Kung 5f, mo-wait siya og 5 seconds.
        yield return new WaitForSeconds(waitToLoadNewScene);
        
        if (RoutineManager.Instance != null) {
            RoutineManager.Instance.SetIsAlive(false); 
        }

        SceneManager.LoadScene(sceneTransitionRule.sceneLeadToInd);
    }
}