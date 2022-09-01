using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public VacuumCollectionSO vacuum;
    public Animator panel1;
    public Animator panel2;
    public Animator panel3;
    void Start()
    {
        panel1.Play("Blink");
        panel2.enabled = false;
        panel3.enabled = false;
    }
    private void FixedUpdate()
    {
        switch (vacuum.badCount)
        {
            case 0:
                panel1.enabled = true;
                panel2.enabled = false;
                panel3.enabled = false;
                break;
            case 1:
                // panel1.enabled = false;
                panel1.gameObject.SetActive(false);
                panel2.enabled = true;
                // panel3.enabled = false;
                break;
            case 2:
                // panel1.enabled = false;
                // panel2.enabled = false;
                panel2.gameObject.SetActive(false);
                panel3.enabled = true;
                break;
            default:
                print("broken health bar");
                break;
        }
    }
}
