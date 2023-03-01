using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    // Инициализация здоровья
    void Start()
    {
        _health = 10;
    }

    public void Hurt(int damage)
    {
        _health -= damage; // Уменьшение здоровья после получения урона
        Debug.Log("Health: " + _health);
    }
}
