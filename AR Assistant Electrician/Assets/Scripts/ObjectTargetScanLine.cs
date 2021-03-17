using UnityEngine;
using Vuforia;

public class ObjectTargetScanLine : MonoBehaviour
{
    const float SCAN_DURATION = 4; //seconds
    float mTime;
    bool mMovingDown = true;
    Camera m_Camera;
 
    void Start()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        float u = mTime / SCAN_DURATION;
        mTime += Time.deltaTime;
        if (u > 1)
        {
            
            mMovingDown = !mMovingDown;
            u = 0;
            mTime = 0;
        }

        
        float viewAspect = m_Camera.pixelWidth / (float)m_Camera.pixelHeight;
        float fovY = Mathf.Deg2Rad * m_Camera.fieldOfView;
        float depth = 1.02f * m_Camera.nearClipPlane;
        float viewHeight = 2 * depth * Mathf.Tan(0.5f * fovY);
        float viewWidth = viewHeight * viewAspect;

        
        float y = -0.5f * viewHeight + u * viewHeight;
        if (mMovingDown)
        {
            y *= -1;
        }

        transform.localPosition = new Vector3(0, y, depth);

        
        float scaleX = 1.02f * viewWidth;
        float scaleY = scaleX / 32;
        transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }
}
