using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InforAllies : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health = 100;

    public void SetHealth(int current_health)
    {
        Health = current_health;
    }

    public int GetHeath()
    {
        return Health;
    }
}
