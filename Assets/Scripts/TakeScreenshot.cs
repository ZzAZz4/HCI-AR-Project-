using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{
    public void Take ()
    {
        StartCoroutine(Capture());
    }

    IEnumerator Capture()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(GetAndroidExternalStoragePath(), "Furniture" + timeStamp + ".png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

    }

    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }
}
