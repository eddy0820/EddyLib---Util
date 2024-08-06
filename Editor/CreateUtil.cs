using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace EddyLib.Util.Editor
{

public static class CreateUtil
{
    public static void CreatePrefabInScene(string resourcePath)
    {
        GameObject gameObject = PrefabUtility.InstantiatePrefab(Resources.Load(resourcePath)) as GameObject;
        PlaceObjectInScene(gameObject);
    }

    public static void CreateGameObjectInScene(string name, params Type[] types)
    {
        GameObject gameObject = new(name, types);
        PlaceObjectInScene(gameObject);
    }

    public static void PlaceObjectInScene(GameObject gameObject)
    {
        SceneView lastView = SceneView.lastActiveSceneView;
        gameObject.transform.position =  lastView ? lastView.pivot : Vector3.zero;

        StageUtility.PlaceGameObjectInCurrentStage(gameObject);
        GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

        Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object {gameObject.name}");
        Selection.activeGameObject = gameObject;

        EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
    }
}

}
