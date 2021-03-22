using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVida : MonoBehaviour
{
    public int salud;
    public void QuitarSalud(int merma)
    {
        salud = salud - merma;
    }
}
