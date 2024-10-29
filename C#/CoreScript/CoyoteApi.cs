namespace lyqbing.DGLAB
{
	/// <summary>
	/// 实现 DG-Lab-Coyote-Game-Hub API
	/// </summary>
	public class CoyoteApi
	{
		private static CoyoteApi _instance;
		private bool _DeLogIS = true;
		private string _CoyotreUrl = "http://127.0.0.1:8920/";
		private readonly string _ApiUrl = "api/v2/game/";
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
		public string FireApi => _CoyotreUrl + _ApiUrl + ClientID + "/action/fire";

		/// <summary>
		/// 设置/读取 设置游戏强度配置 API
		/// </summary>
		public string StrengthConfigApi => _CoyotreUrl + _ApiUrl + ClientID + "/strength";

		/// <summary>
		/// 获取获取服务器配置的波形列表 API
		/// </summary>
		public string PulseListApi => CoyotreUrl + "api/v2/pulse_list";

		/// <summary>
		/// 获取完整的波形列表，包括客户端自定义波形 API
		/// </summary>
		public string AllPulseListApi => _CoyotreUrl + _ApiUrl + ClientID + "/pulse_list";

		/// <summary>
		/// 设置/获取 当前波形ID API
		/// </summary>
		public string PulseIdApi => _CoyotreUrl + _ApiUrl + ClientID + "/pulse";

		/// <summary>
		/// 获取游戏响应数据 API
		/// </summary>
		public string GameResponseApi => _CoyotreUrl + _ApiUrl + ClientID;

		#endregion
	}
}