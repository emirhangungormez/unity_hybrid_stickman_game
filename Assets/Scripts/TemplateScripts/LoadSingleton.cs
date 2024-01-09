using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadSingleton<T> : MonoBehaviour where T : LoadSingleton<T>
{
    private static T instance;
    private static object lockObject = new object(); // Thread-safe bir kod yazmak i�in kilit nesnesi

    public static T Instance
    {
        get
        {
            // �lk kontrol, instance'�n null olup olmad���n� kontrol eder. E�er null ise
            // FindObjectOfType ile instance'� bulmaya �al���r. Bulamazsa, CreateInstance metodu ile instance
            // olu�turur.
            if (instance == null)
            {
                lock (lockObject) // Thread-safe bir kod yazmak i�in kilit nesnesi
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            instance = CreateInstance();
                        }
                    }
                }
            }

            return instance;
        }
    }

    private static T CreateInstance()
    {
        GameObject singletonObject = new GameObject();
        T singleton = singletonObject.AddComponent<T>();
        singletonObject.name = typeof(T).ToString();

        return singleton;
    }

    protected virtual void Awake()
    {
        // instance hen�z atanmad�ysa, instance'� bu MonoBehavior nesnesi olarak atar ve sahne de�i�ikliklerinde yok
        // olmamas� i�in DontDestroyOnLoad'u kullan�r.
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        // E�er instance bu MonoBehavior nesnesi de�ilse, bu nesne yok edilir.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        // Bu MonoBehavior nesnesi instance olarak atanm�� ise, instance'� null olarak ayarlar.
        if (instance == this)
        {
            instance = null;
        }
    }
}