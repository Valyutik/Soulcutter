using UnityEngine;
using UnityEngine.SceneManagement;

namespace Soulcutter.Scripts.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Test Level");
        }
    }
}
