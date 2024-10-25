using UnityEngine;
using lyqbing.DGLAB;
using System.Collections.Generic;
using Mono.Cecil.Cil;

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



	//获取游戏相应数据
	public async void GetGameResponse()
	{
		GameResponse data = await DGLAB.GetGameResponse();

		// 打印数据太多了，随便写几个，其他懒得写了，自己看文档吧
		// https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub/blob/main/docs/api.md
		Debug.Log(data.strengthConfig.strength);//随机强度
		Debug.Log(data.gameConfig.strengthChangeInterval[0]);// 随机强度变化间隔，单位：秒
		Debug.Log(data.gameConfig.enableBChannel); // 是否启用B通道
	}



	//获取 脉冲列表 -- 严重错误：官方原因 --
	public void GetPulseList()
	{
		//PulseListJson Data = await DGLAB.GetPulseList();
		Debug.Log("等待官方修复");
	}



	//获取当前 脉冲ID 及 列表
	public async void GetPulseID()
	{
		PulseId data = await DGLAB.GetPulseID();

		string currentPulseId = data.currentPulseId;
		string pulseIdList = data.currentPulseId;

		foreach (string id in data.pulseId)
		{
			if (currentPulseId == id) return;
			pulseIdList += "," + id;
		}

		Debug.Log("当前播放的ID: " + currentPulseId + "当前播放列表：" + pulseIdList);
	}



	//获取强度配置 回执 JSON列表
	public async void GetStrengthConfig()
	{
		StrengthConfig data = await DGLAB.GetStrengthConfig();
		Debug.Log(" 当前基础强度：" + data.strength + " 当前随机强度：" + data.randomStrength);
	}



	//一键开火
	public void Fire() => DGLAB.Fire();



	//设置脉冲ID (2个方法)
	public void SetPulseID()
	{
		DGLAB.SetPulseID("ID");

		List<string> list = new()
		{
			"ID1",
			"ID2"
		};
		DGLAB.SetPulseID(list);
	}



	//强度设置
	public void SetStrengthConfigAdd()
	{
		DGLAB.SetStrength.Add();
		DGLAB.SetStrength.Sub();
		DGLAB.SetStrength.Set();
		
		DGLAB.SetRandomStrength.Add();
		DGLAB.SetRandomStrength.Sub();
		DGLAB.SetRandomStrength.Set();
	}
}
