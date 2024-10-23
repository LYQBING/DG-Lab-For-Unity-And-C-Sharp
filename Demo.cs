using UnityEngine;
using lyqbing.DGLAB;
using UnityEngine.UI; //使用 DGLAB 命名空间

/*
 让你开发的 Unity游戏 连接到郊狼
BY.LYQBING（Q 3041329025）(群 928175340)

控制器采用：DG-Lab-Coyote-Game-Hub
https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub
 */

public class Demo : MonoBehaviour
{
	public string CoyotreUrl = "127.0.0.1:8920";
	public string ClientID = "all";

	public int strength = 1;
	public string ID = "null";
	public int time = 1000;


	#region 客户端配置 (默认无需配置)
	//配置服务器地址 (默认127.0.0.1:8920) (默认无需配置)
	public void SetCoyotreUrl() => CoyoteApi.CoyotreUrl = CoyotreUrl;

	//配置控制设备ID 默认控制全部设备 (默认无需配置)
	public void SetClientID() => CoyoteApi.ClientID = ClientID;

	//是否可以输出日志 (默认true) (默认无需配置)
	public void DeLogIS() => CoyoteApi.DeLogIS = !CoyoteApi.DeLogIS;
	#endregion

	#region 获取 脉冲列表
	public async void GetPulseList()
	{
		//获取脉冲列表 回执 JSON列表
		PulseListJson Data = await DGLAB.GetPulseList();
		Debug.Log("(仅输出第一个) 脉冲ID：" + Data.pulseList[0].id + " 脉冲名称：" + Data.pulseList[0].name);
	}

	public async void GetPulseID()
	{
		//获取当前脉冲ID 回执 JSON列表
		PulseId data = await DGLAB.GetPulseID();
		Debug.Log("当前脉冲ID(pulseId): " + data.pulseId + " 当前脉冲ID(currentPulseId): " + data.currentPulseId);
	}
	#endregion

	#region 获取 强度配置
	public async void GetStrengthConfig()
	{
		//获取强度配置 回执 JSON列表
		StrengthConfigJson data = await DGLAB.GetStrengthConfig();
		Debug.Log(" 当前基础强度：" + data.strengthConfig.strength + " 当前随机强度：" + data.strengthConfig.randomStrength);
	}
	#endregion

	#region 一键开火
	//一键开火(强度,时间) (留空默认为1,1000)
	public void Fire() => DGLAB.Fire(strength, time);
	#endregion

	#region 脉冲设置
	//设置脉冲ID(ID)
	public void SetPulseID(string ID) => DGLAB.SetPulseID(ID);
	#endregion

	#region 基础强度
	//加 基础强度(强度) (留空默认为1)
	public void SetStrengthConfigAdd() => DGLAB.SetStrength.Add(strength);


	//减 基础强度(强度) (留空默认为1)
	public void SetStrengthConfigSub() => DGLAB.SetStrength.Sub(strength);

	
	//设 基础强度(强度) (留空默认为1)
	public void SetStrengthConfigSet() => DGLAB.SetStrength.Set(strength);
	#endregion

	#region 随机强度
	//加 随机强度(强度) (留空默认为1)
	public void SetRandomStrengthConfigAdd() => DGLAB.SetRandomStrength.Add(strength);


	//减 随机强度(强度) (留空默认为1)
	public void SetRandomStrengthConfigSub() => DGLAB.SetRandomStrength.Sub(strength);


	//设 随机强度(强度) (留空默认为1)
	public void SetRandomStrengthConfigSet() => DGLAB.SetRandomStrength.Set(strength);
	#endregion

	#region 随机间隔
	//设置最小随机间隔(数值)
	public void SetIntervalMin() => DGLAB.SetInterval.Min(strength);

	
	//设置最大随机间隔(数值)
	public void SetIntervalMax() => DGLAB.SetInterval.Max(strength);
	#endregion
}
