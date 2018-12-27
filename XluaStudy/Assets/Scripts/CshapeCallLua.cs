/*
 * C#访问LUA脚本的全局变量
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CshapeCallLua : MonoBehaviour {


    void Start() {
        LuaEnv env = new LuaEnv();
        env.DoString("require '3'");
        int a = env.Global.Get<int>("a");           //获取lua脚本的全局变量a
        Debug.Log(a);
        string s = env.Global.Get<string>("str");
        Debug.Log(s);
        bool isDie = env.Global.Get<bool>("isDie");
        Debug.Log(isDie);

        User user = env.Global.Get<User>("user");
        Debug.Log(user.username);



        env.Dispose();
    }

   

}
class User
{
    public int username;
    public int passward;
}
