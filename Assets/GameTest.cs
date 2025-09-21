using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTest : MonoBehaviour
{
    public class Character
    {
        public void Talk(string texto)
        {
            Debug.Log(texto);
        }

        public void Talk(string nombre, string texto)
        {
            Debug.Log(nombre + ": " + texto);
        }

        public void Talk(string nombre, string texto, string emocion)
        {
            Debug.Log(nombre + " (" + emocion + "): " + texto);
        }
    }

    public class Player
    {
        public int vida = 100;

        public void GetDamage(int damage)
        {
            vida -= damage;
            Debug.Log("Vida: " + vida);
        }

        public void GetDamage(int damage, bool critico)
        {
            if (critico) damage *= 2;
            vida -= damage;
            Debug.Log("Vida: " + vida);
        }

        public void GetDamage(int damage, bool critico, bool knockback)
        {
            if (critico) damage *= 2;
            vida -= damage;
            Debug.Log("Vida: " + vida);
            if (knockback) Debug.Log("Knockback!");
        }
    }

    public class Slime
    {
        public int vida;

        public Slime(int v)
        {
            vida = v;
        }

        public static Slime operator +(Slime a, Slime b)
        {
            return new Slime(a.vida + b.vida);
        }
    }

    public class Inventory
    {
        List<string> objetos = new List<string>();

        public void Add(string objeto)
        {
            objetos.Add(objeto);
        }

        public void Add(string objeto, int cantidad)
        {
            for (int i = 0; i < cantidad; i++) objetos.Add(objeto);
        }

        public void Mostrar()
        {
            foreach (string obj in objetos) Debug.Log(obj);
        }
    }

    void Start()
    {
        Character npc = new Character();
        npc.Talk("Hola viajero!");
        npc.Talk("NPC", "Bienvenido a mi tienda");
        npc.Talk("NPC", "Cuidado con los monstruos", "Preocupado");

        Player jugador = new Player();
        jugador.GetDamage(10);
        jugador.GetDamage(15, true);
        jugador.GetDamage(20, false, true);

        Slime slime1 = new Slime(30);
        Slime slime2 = new Slime(50);
        Slime fusionado = slime1 + slime2;
        Debug.Log("Slime fusionado vida: " + fusionado.vida);

        Inventory inventario = new Inventory();
        inventario.Add("Poción");
        inventario.Add("Espada", 3);
        inventario.Mostrar();
    }
}
