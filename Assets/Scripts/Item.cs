using UnityEngine;
using UnityEngine.Rendering;

public class Item : MonoBehaviour
{
    const float NOSE_DAMAGE = -20f;
    const float ERROR_IMPULSE = 300f;   // positivo, porque Vector2.down ya apunta abajo
    const float POSITIVE_HEAL = 20f;

    public enum ItemTypes { None, Nose, ErrorCode, PositiveWords }

    [field: SerializeField] public ItemTypes Type { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
        if (jetpack == null) return;

        switch (Type)
        {
            case ItemTypes.ErrorCode:
                if (jetpack.Flying)
                {
                    var rb = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                        rb.AddForce(Vector2.down * ERROR_IMPULSE, ForceMode2D.Impulse);
                }
                else
                {
                    jetpack.transform.Translate(Vector2.down * 2.5f);
                }
                break;

            case ItemTypes.Nose:
               //jetpack.AddEnergy(NOSE_DAMAGE);
                break;

            case ItemTypes.PositiveWords:
                //jetpack.AddEnergy(POSITIVE_HEAL);
                break;
        }

        Destroy(gameObject);
    }
}
