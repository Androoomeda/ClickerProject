using UnityEngine;
using UnityEngine.Pool;

public class BanknoteFactory : MonoBehaviour
{
    [SerializeField] private int poolLenght;
    [SerializeField] private Banknote BanknotePrefab;

    private IObjectPool<Banknote> pool;

    private void Awake()
    {
        pool = new ObjectPool<Banknote>(CreateBanknote, 
           OnGet, OnRelease, OnDestroyBanknote, true, poolLenght);

        for (int i = 0; i < poolLenght; i++)
        {
            var banknote = CreateBanknote();
            pool.Release(banknote);
        }
    }

    public void NewBanknote()
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 90));

        Banknote banknote = pool.Get();

        if (banknote != null)
        {
            banknote.transform.position = GetMousePosition();
            banknote.transform.rotation = randomRotation;
        }
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        return mousePosition;
    }

    private Banknote CreateBanknote()
    {
        var banknote = Instantiate(BanknotePrefab);
        banknote.pool = this.pool;
        return banknote;
    }

    private void OnGet(Banknote banknote)
    {
        banknote.gameObject.SetActive(true);
    }

    private void OnRelease(Banknote banknote)
    {
        banknote.gameObject.SetActive(false);
    }

    private void OnDestroyBanknote(Banknote banknote)
    {
        Destroy(banknote.gameObject);
    }
}
