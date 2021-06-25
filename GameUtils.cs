using System.Collections.Generic;
using UnityEditor;
public static class GameUtils
{
    public static List<T> GetAllInstances<T>() where T : UnityEngine.Object
    {
        string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);  //FindAssets uses tags check documentation for more info
        List<T> a = new List<T>(guids.Length);
        for(int i =0;i<guids.Length;i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a.Add(AssetDatabase.LoadAssetAtPath<T>(path));
        }
 
        return a;
 
    }
}
