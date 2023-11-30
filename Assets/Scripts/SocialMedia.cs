using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SocialMedia : MonoBehaviour
{
    public void OpenInstragramLink()
    {
        Application.OpenURL("https://www.instagram.com/canalugr/");
    }

    public void OpenTwitterLink()
    {
        Application.OpenURL("https://twitter.com/ETSIIT_UGR");
    }
}
