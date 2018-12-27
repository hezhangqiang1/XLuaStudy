/*
 *  Xlua运行lua脚本测试,
 *  一个LuaEnv最好全局唯一 
 * require内置执行lua程序  通过Loader  加载 Loader可以自定义为了可以从自定义的文件夹加载文件
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

public class RunLuaTest : MonoBehaviour {


    private LuaEnv luaenv;

	void Start () {
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString("print('Hello XLua')");
        luaenv.DoString("CS.UnityEngine.Debug.Log('Hello C#')");  //Lua脚本中调用C#要加CS标识 

        TextAsset ta= Resources.Load<TextAsset>("1.lua");         //读取Lua脚本
        luaenv.DoString(ta.text);                                 //执行Lua程序
        luaenv.AddLoader(MyLoader);                               //添加一个自定义的Loader
        luaenv.DoString("require'2'");                           //require内置执行lua程序  通过Loader 加载 Loader可以自定义

       



        luaenv.Dispose();

    }
    /// <summary>
    /// 自定义的Loader方法
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private byte[] MyLoader(ref string filePath)
    {
        print(filePath);
        //string s = "print(2018)";
        print(Application.streamingAssetsPath);
        string absPath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt"; //从指定的文件夹加载lua文件

        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }
	
	
}
