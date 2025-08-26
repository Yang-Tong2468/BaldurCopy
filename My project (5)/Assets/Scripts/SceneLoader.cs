using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // 在Inspector中设置要跳转的场景名称
    public string targetSceneName;

    private void Start()
    {
        // 自动获取按钮组件并添加点击事件
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogWarning("SceneLoader脚本所在的物体上没有Button组件！");
        }
    }

    // 按钮点击时调用
    public void OnButtonClicked()
    {
        if (string.IsNullOrEmpty(targetSceneName))
        {
            Debug.LogError("请在Inspector中设置目标场景名称！");
            return;
        }

        // 检查场景是否在Build Settings中
        if (!IsSceneInBuildSettings(targetSceneName))
        {
            Debug.LogError($"场景 {targetSceneName} 未添加到Build Settings中！");
            return;
        }

        LoadTargetScene();
    }

    // 执行场景跳转
    private void LoadTargetScene()
    {
        try
        {
            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"正在跳转到场景: {targetSceneName}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"跳转场景失败: {e.Message}");
        }
    }

    // 检查场景是否已添加到Build Settings
    private bool IsSceneInBuildSettings(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneInBuild = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            
            if (sceneInBuild == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
