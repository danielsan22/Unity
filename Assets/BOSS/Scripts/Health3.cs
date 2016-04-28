using UnityEngine;
using System.Collections;

public class Health3 : MonoBehaviour {
    public float barDisplay = 1; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    Boss03 boss03;
    float health;
    float newHealth;

    void Start() {

        boss03 = GameObject.FindObjectOfType<Boss03>();
        health = boss03.getHealth();
        newHealth = health;
    }

    void OnGUI() {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update() {
    }

    public void Damage(float damage) {

        newHealth -= damage;
        barDisplay = (1 / health) * newHealth;
        boss03.setHealth(newHealth);
    }
}