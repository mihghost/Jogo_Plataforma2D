using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController gc;// para acessar a classe pela variável gc
    public Text coinsText;
    public int coins;

    //Para as instruções serem executadas antes do início do jogo
    void Awake()
    {
        if (gc == null)
        {
            gc = this; //recebe a classe GameController 
        }
        else if (gc != this)
        {
            Destroy(gameObject);//destrói o objeto de jogo(canvas) que contem esse script 
        }

    }

}
