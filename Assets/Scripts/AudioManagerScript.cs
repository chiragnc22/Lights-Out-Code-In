using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    private void Awake(){
        DontDestroyOnLoad(this.gameObject);

        if(instance == null){
            instance = this;
        }  
        else{
            Destroy(gameObject);
        }
    }
}
