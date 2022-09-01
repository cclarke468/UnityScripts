using UnityEngine;

[CreateAssetMenu]
public class FloatDataSO : ScriptableObject
{
    public float floatData;
    public float GetFloatData()
    {
        return floatData;
    }
    public void SetFloatData(float var)
    {
        floatData = var;
    }

    public void UpdateFloatData(float num)
    {
        floatData += num;
    }
}
