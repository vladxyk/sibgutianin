using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject hero;

    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, -10f);
    }
}
