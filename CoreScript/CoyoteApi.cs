namespace lyqbing.DGLAB
{
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// 实现 DG-Lab-Coyote-Game-Hub API
	/// </summary>
	public class CoyoteApi
	{
		private static CoyoteApi _instance;
		private bool _DeLogIS = true;
		private string _CoyotreUrl = "http://127.0.0.1:8920/api/game/";
		private string _ClientId = "all";

		public static CoyoteApi Instance
		{
			get
			{
				_instance ??= new CoyoteApi();
				return _instance;
			}
		}

		#region 配置服务器/本机属性
		/// <summary>
		/// Coyote-Game-Hub 服务器地址
		/// </summary>
		public static string CoyotreUrl
		{
			get
			{
				return Instance._CoyotreUrl;
			}
			set
			{
				Instance._CoyotreUrl = "http://" + value + "/api/game/";
			}
		}

		/// <summary>
		/// 客户端ID
		/// </summary>
		public static string ClientID
		{
			get
			{
				return Instance._ClientId;
			}
			set
			{
				Instance._ClientId = value;
			}
		}

		/// <summary>
		/// 是否开启输出日志
		/// </summary>
		public static bool DeLogIS
		{
			get
			{
				return Instance._DeLogIS;
			}
			set
			{
				Instance._DeLogIS = value;
			}
		}

		#endregion

		#region 获取对应功能 Api 地址

		/// <summary>
		/// 一键开火 API 
		/// </summary>
		public string FireApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/fire";
			}
		}

		/// <summary>
		/// 设置/读取 配置文件 API
		/// </summary>
		public string StrengthConfigApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/strength_config";
			}
		}

		/// <summary>
		/// 获取游戏信息 API
		/// </summary>
		public string GetGameApi
		{
			get
			{
				return CoyotreUrl + ClientID;
			}
		}

		/// <summary>
		/// 获取脉冲列表 API
		/// </summary>
		public string PulseListApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_list";
			}
		}

		/// <summary>
		/// 设置/获取 脉冲ID API
		/// </summary>
		public string PulseIdApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_id";
			}
		}

		#endregion
	}

	/*
	以下用于解析回执数据（上传无需）
	由于Unity默认不支持高级JSON调用，所以需要手动实现调用
	若使用自定义库，请自行实现跨平台调用
	*/

	#region 脉冲列表
	[System.Serializable] //脉冲回执JSON
	public class PulseListJson
	{
		public int status;
		public string code;
		public List<PulseList> pulseList;
	}

	[System.Serializable] //脉冲文件列表
	public class PulseList
	{
		[Tooltip("脉冲ID")] public string id;
		[Tooltip("脉冲名称")] public string name;
	}
	#endregion

	#region 当前脉冲ID
	[System.Serializable]
	public class PulseId //当前脉冲ID
	{
		public int status;
		public string code;
		[Tooltip("当前脉冲ID")] public string currentPulseId;
		[Tooltip("脉冲ID")] public string pulseId;
	}
	#endregion

	#region 强度配置
	[System.Serializable]
	public class StrengthConfigJson //强度配置回执JSON
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
	}

	[System.Serializable]
	public class StrengthConfig //强度配置
	{
		[Tooltip("基础强度")] public int strength;
		[Tooltip("随机强度")] public int randomStrength;
		[Tooltip("最小随机间隔")] public int minInterval;
		[Tooltip("最大随机间隔")] public int maxInterval;
	}
	#endregion
}