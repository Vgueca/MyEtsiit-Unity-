using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons; // Array que contiene los botones
    private int currentButton = 0; // Índice del botón actual

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => MarkButton(button));
        }
    }

    void MarkButton(Button button)
    {
        // Restaura el tamaño y el color del botón actual
        buttons[currentButton].transform.localScale = new Vector3(1, 1, 1);
        buttons[currentButton].image.color = Color.white;

        // Encuentra el índice del nuevo botón
        currentButton = System.Array.IndexOf(buttons, button);

        // Aumenta el tamaño del nuevo botón y cambia su color a verde
        buttons[currentButton].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        buttons[currentButton].image.color = Color.green;
    }
}
