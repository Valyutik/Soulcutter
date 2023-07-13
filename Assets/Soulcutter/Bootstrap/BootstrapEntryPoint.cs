using UnityEngine;
using UnityEngine.SceneManagement;

namespace Soulcutter.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Test Level");
        }
    }
}
