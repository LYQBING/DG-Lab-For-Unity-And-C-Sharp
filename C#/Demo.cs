using lyqbing.DGLAB;
using System.Collections.Generic;
using System;

/*
 让你开发的 Unity游戏 连接到郊狼
BY.LYQBING（Q 3041329025）(群 928175340)

控制器采用：DG-Lab-Coyote-Game-Hub
https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub
 */

public class Demo
{
	//本地数据相关
	public void Start()
	{
		CoyoteApi.CoyotreUrl = "127.0.0.1:8920";		//配置服务器地址 (默认127.0.0.1:8920) (默认无需配置)
		CoyoteApi.ClientID = "all";						//配置控制设备ID 默认控制全部设备 (默认无需配置)
		CoyoteApi.DeLogIS = true;						//是否可以输出日志 (默认true) (默认无需配置)
	}

	//一键开火
	public void Fire() => DGLab.Fire();



	//设置脉冲ID (2个方法)
	public void SetPulseID()
	{
		DGLab.SetPulseID("ID");

		List<string> list = new()
		{
			"ID1",
			"ID2"
		};
		DGLab.SetPulseID(list);
	}



	//强度设置
	public void SetStrengthConfigAdd()
	{
		DGLab.SetStrength.Add();
		DGLab.SetStrength.Sub();
		DGLab.SetStrength.Set();

		DGLab.SetRandomStrength.Add();
		DGLab.SetRandomStrength.Sub();
		DGLab.SetRandomStrength.Set();
	}



	#region 以下内容您仅能获得回执Json，若要详情请自行使用第三方Json进行解析 (建议在DGLab脚本中进行解析)
	//获取游戏相应数据
	public async void GetGameResponse()
	{
		string data = await DGLab.GetGameResponse();
		Console.Write(data);
	}



	//获取 服务器 脉冲列表
	public async void GetPulseList()
	{
		string data = await DGLab.GetPulseList();
		Console.Write(data);
	}



	//获取 完整 脉冲列表 (包括客户端)
	public async void GetGamePulseList()
	{
		string data = await DGLab.GetAllPulseList();
		Console.Write(data);
	}



	//获取当前 脉冲ID 及 列表
	public async void GetPulseID()
	{
		string data = await DGLab.GetPulseID();
		Console.Write(data);
	}



	//获取强度配置 回执 JSON列表
	public async void GetStrengthConfig()
	{
		string data = await DGLab.GetStrengthConfig();
		Console.Write(data);
	}

	#endregion
}
