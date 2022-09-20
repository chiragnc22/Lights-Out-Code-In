using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MazeKey : MonoBehaviour {

    
    public void OnTriggerEnter2D() {
        transform.parent.SendMessage("OnKeyFound", SendMessageOptions.DontRequireReceiver);
        FindObjectOfType<GameManager>().pauseLevel();
        GameObject.Destroy(gameObject);
    }
}
