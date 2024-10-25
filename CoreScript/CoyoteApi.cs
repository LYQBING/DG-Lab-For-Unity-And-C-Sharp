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
		private string _CoyotreUrl = "http://127.0.0.1:8920/";
		private string _ApiUrl = "http://127.0.0.1:8920/api/v2/game/";
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
				Instance._CoyotreUrl = "http://" + value;
				Instance._ApiUrl = "http://" + value + "/api/v2/game/";
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
		/// 一键开火 API (新V2)
		/// </summary>
		public string FireApi
		{
			get
			{
				return _ApiUrl + ClientID + "/action/fire";
			}
		}

		/// <summary>
		/// 设置/读取 设置游戏强度配置 API (新V2)
		/// </summary>
		public string StrengthConfigApi
		{
			get
			{
				return _ApiUrl + ClientID + "/strength";
			}
		}

		/// <summary>
		/// 获取波形列表 API (由于 新V2 文档错误，无法对其完成适配！此功能处于严重异常状态！！！)
		/// </summary>
		public string PulseListApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_list";
			}
		}

		/// <summary>
		/// 设置/获取 当前波形ID API (新V2)
		/// </summary>
		public string PulseIdApi
		{
			get
			{
				return _ApiUrl + ClientID + "/pulse";
			}
		}

		/// <summary>
		/// 获取游戏响应数据 API (新V2)
		/// </summary>
		public string GameResponseApi
		{
			get
			{
				return _ApiUrl + ClientID;
			}
		}

		#endregion
	}

	/*
	以下用于解析回执数据（上传无需）
	由于Unity默认不支持高级JSON调用，所以需要手动实现调用
	若使用自定义库，请自行实现跨平台调用
	*/

	#region 波形列表相关
	/// <summary>
	/// 波形列表回执JSON
	/// </summary>
	[System.Serializable]
	public class PulseListJson
	{
		public int status;
		public string code;
		public List<PulseList> pulseList;
	}

	/// <summary>
	/// 波形列表配置文件
	/// </summary>
	[System.Serializable]
	public class PulseList
	{
		[Tooltip("脉冲ID")] public string id;
		[Tooltip("脉冲名称")] public string name;
	}
	#endregion

	#region 波形配置文件
	/// <summary>
	/// 波形配置文件
	/// </summary>
	[System.Serializable]
	public class PulseId
	{
		public int status;
		public string code;
		[Tooltip("当前波形ID")] public string currentPulseId;
		[Tooltip("当前波形列表")] public string[] pulseId;
	}
	#endregion

	#region 强度配置相关
	/// <summary>
	/// 强度配置回执JSON
	/// </summary>
	[System.Serializable]
	public class StrengthConfigJson
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
	}

	/// <summary>
	/// 强度配置文件
	/// </summary>
	[System.Serializable]
	public class StrengthConfig
	{
		[Tooltip("基础强度")] public int strength;
		[Tooltip("随机强度")] public int randomStrength;
	}
	#endregion

	#region 响应数据相关
	/// <summary>
	/// 当前配置数据
	/// </summary>
	[System.Serializable]
	public class GameConfig
	{
		public int[] strengthChangeInterval;
		public bool enableBChannel;
		public float bChannelStrengthMultiplier;
		public string pulseId;
		public string pulseMode;
		public int pulseChangeInterval;
	}

	/// <summary>
	/// 当前用户数据
	/// </summary>
	[System.Serializable]
	public class ClientStrength
	{
		public int strength;
		public int limit;
	}

	/// <summary>
	/// 游戏响应数据回执
	/// </summary>
	[System.Serializable]
	public class GameResponse
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
		public GameConfig gameConfig;
		public ClientStrength clientStrength;
		public string currentPulseId;
	}
	#endregion
}