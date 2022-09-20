using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PopUpWindow : MonoBehaviour
{
    public GameObject redirect;
    public string[] links = { "https://wordscramble-technitude.netlify.app/", "https://guesstheword1.netlify.app/", "https://hiddensecret.netlify.app/","https://gist.github.com/shree-1788/62bc418dd937088ca61d096e0ceb15ae"};
    
    public void Redirect()
    {
            foreach (string s in links)
            {
                Application.OpenURL(s);
                int stringIndex = Array.IndexOf(links, s);
                links = links.Where((val, idx) => idx != stringIndex).ToArray();
                break;
            }
            redirect.SetActive(false);
    }
}
